using System.Linq;

namespace YatingTts.Constants
{
    public class AudioSampleRate
    {
        public static string SR16k = "16K";
        public static string SR22k = "22K";

        public static bool Validation(string audioSampleRate)
        {
            string[] audioSampleRates = { SR16k, SR22k };
            return audioSampleRates.Contains(audioSampleRate);
        }
    }
}

