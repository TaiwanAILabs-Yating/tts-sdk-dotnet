using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.IO;
using YatingTts.Dto;
using YatingTts.Constants;

namespace YatingTts
{
    public class TtsClient
    {
        private readonly string TtsApiUrl;
        private readonly string TtsApiKey;

        public TtsClient(string ttsApiUrl, string ttsApiKey)
        {
            this.TtsApiUrl = ttsApiUrl;
            this.TtsApiKey = ttsApiKey;
        }

        public void Synthesize(string inputText, string inputType, string voiceModel, string audioEncoding, string audioSampleRate, string filePath)
        {
            try
            {
                // parameter validation
                Validation(inputType, voiceModel, audioEncoding, audioSampleRate);

                // mapping http request body
                StringContent bodyString = BodyGenerator(inputText, inputType, voiceModel, audioEncoding, audioSampleRate);

                // send http post request
                ResponseDto responseDto = SendHttpRequest(bodyString);

                // get audio content and decode
                byte[] bytes = Convert.FromBase64String(responseDto.AudioContent);

                // save to file
                SaveToFile(filePath, audioEncoding, bytes);

                return;
            }
            catch
            {
                throw;
            }
        }

        private void SaveToFile(string filePath, string audioEncoding, byte[] bytes)
        {
            string fileExtension = "";
            if (audioEncoding == "MP3")
            {
                fileExtension = ".mp3";
            }
            else
            {
                fileExtension = ".wav";
            }

            filePath = filePath + fileExtension;

            File.WriteAllBytes(filePath, bytes);
            Console.WriteLine($"Save file success, file path: {filePath}");
        }

        private ResponseDto SendHttpRequest(StringContent bodyString)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("key", TtsApiKey);

            try
            {
                HttpResponseMessage httpResponseMessage = httpClient.PostAsync(TtsApiUrl, bodyString).Result;

                // Get request
                int statusCode = (int)httpResponseMessage.StatusCode;
                Console.WriteLine($"Http status code: {statusCode}");
                if (statusCode != 200 && statusCode != 201)
                {
                    throw new HttpRequestException($"http request error, error code: {statusCode}");
                }

                string content = httpResponseMessage.Content.ReadAsStringAsync().Result;

                // Decode body result
                ResponseDto? responseDto = JsonSerializer.Deserialize<ResponseDto>(content);
                if (responseDto is null)
                {
                    throw new ArgumentNullException(nameof(responseDto));
                }

                return responseDto;
            }
            catch
            {
                throw;
            }
        }

        private StringContent BodyGenerator(string inputText, string inputType, string voiceModel, string audioEncoding, string audioSampleRate)
        {
            RequestDto request = new RequestDto(inputText, inputType, voiceModel, audioEncoding, audioSampleRate);
            string jsonString = JsonSerializer.Serialize(request);
            Console.WriteLine($"Post Body Json String: {jsonString}");

            StringContent jsonEncodeString = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return jsonEncodeString;
        }

        private void Validation(string inputType, string voiceModel, string audioEncoding, string audioSampleRate)
        {
            if (!InputType.Validation(inputType))
            {
                throw new Exception("inputType: " + inputType + " is not allowed.");
            }
            if (!VoiceModel.Validation(voiceModel))
            {
                throw new Exception("voiceModel: " + voiceModel + " is not allowed.");
            }
            if (!AudioEncoding.Validation(audioEncoding))
            {
                throw new Exception("audioEncoding: " + audioEncoding + " is not allowed.");
            }
            if (!AudioSampleRate.Validation(audioSampleRate))
            {
                throw new Exception("audioSampleRate: " + audioSampleRate + " is not allowed.");
            }
        }
    }
}

