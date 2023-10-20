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

        public RequestDto(string inputText, string inputType, string voiceModel, double voiceSpeed, double voicePitch, double voiceEnergy, string audioEncoding, string audioSampleRate)
        {
            this.Input = new InputDto(inputText, inputType);
            this.Voice = new VoiceDto(voiceModel, voiceSpeed, voicePitch, voiceEnergy);
            this.AudioConfig = new AudioConfigDto(audioEncoding, audioSampleRate);
        }
    }

    public class VoiceDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("pitch")]
        public double Pitch { get; set; }
        [JsonPropertyName("energy")]
        public double Energy { get; set; }

        public VoiceDto(string model, double speed, double pitch, double energy)
        {
            this.Model = model;
            this.Speed = speed;
            this.Pitch = pitch;
            this.Energy = energy;
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

