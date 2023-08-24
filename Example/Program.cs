using YatingTts;
using YatingTts.Constants;

string ttsApiUrl = "TTS_ENDPOINT";
string ttsApiKey = "PUT_YOUR_API_KEY_HERE";

string inputText = "歡迎使用雅婷文字轉語音。";
string inputType = InputType.Text;
string voiceModel = VoiceModel.Female2;
string audioEncoding = AudioEncoding.Linear16;
string audioSampleRate = AudioSampleRate.SR16k;
string fileName = "example";

try
{
    TtsClient ttsClient = new TtsClient(ttsApiUrl, ttsApiKey);
    ttsClient.Synthesize(inputText, inputType, voiceModel, audioEncoding, audioSampleRate, fileName);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
