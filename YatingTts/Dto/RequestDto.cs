using System.Text.Json.Serialization;

namespace YatingTts.Dto
{
    public class RequestDto
    {
        [JsonPropertyName("input")]
        public InputDto Input { get; set; }
        [JsonPropertyName("voice")]
        public VoiceDto Voice { get; set; }
        [JsonPropertyName("audioConfig")]
        public AudioConfigDto AudioConfig { get; set; }

        public RequestDto(string inputText, string inputType, string voiceModel, string audioEncoding, string audioSampleRate)
        {
            this.Input = new InputDto(inputText, inputType);
            this.Voice = new VoiceDto(voiceModel);
            this.AudioConfig = new AudioConfigDto(audioEncoding, audioSampleRate);
        }
    }

    public class VoiceDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        public VoiceDto(string model)
        {
            this.Model = model;
        }
    }

    public class InputDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }

        public InputDto(string text, string type)
        {
            this.Text = text;
            this.Type = type;
        }
    }
    public class AudioConfigDto
    {
        [JsonPropertyName("encoding")]
        public string Encoding { get; set; }
        [JsonPropertyName("sampleRate")]
        public string SampleRate { get; set; }

        public AudioConfigDto(string encoding, string sampleRate)
        {
            this.Encoding = encoding;
            this.SampleRate = sampleRate;
        }
    }
}

