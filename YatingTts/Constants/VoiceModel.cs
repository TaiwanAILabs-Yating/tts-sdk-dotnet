using System.Linq;

namespace YatingTts.Constants
{
    public class VoiceModel
    {
        public static string Female1 = "zh_en_female_1";
        public static string Female2 = "zh_en_female_2";
        public static string Male1 = "zh_en_male_1";

        public static bool Validation(string voiceModel)
        {
            string[] voiceModels = { Female1, Female2, Male1 };
            return voiceModels.Contains(voiceModel);
        }
    }
}

