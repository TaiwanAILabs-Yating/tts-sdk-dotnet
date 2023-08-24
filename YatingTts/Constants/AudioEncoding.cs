using System.Linq;

namespace YatingTts.Constants
{
    public class AudioEncoding
    {
        public static string Linear16 = "LINEAR16";
        public static string Mp3 = "MP3";

        public static bool Validation(string audioEncoding)
        {
            string[] audioEncodings = { Linear16, Mp3};
            return audioEncodings.Contains(audioEncoding);
        }
    }
}

