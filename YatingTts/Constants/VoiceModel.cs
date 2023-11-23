using System.Linq;

namespace YatingTts.Constants
{
    public class VoiceModel
    {
        public const string ZhEnFemale1 = "zh_en_female_1";
        public const string ZhEnFemale2 = "zh_en_female_2";
        public const string ZhEnMale1 = "zh_en_male_1";
        public const string ZhEnMale2 = "zh_en_male_2";
        public const string TaiFemale1 = "tai_female_1";
        public const string TaiFemale2 = "tai_female_2";
        public const string TaiMale1 = "tai_male_1";

        public static bool Validation(string voiceModel)
        {
            string[] voiceModels = { ZhEnFemale1, ZhEnFemale2, ZhEnMale1, ZhEnMale2, TaiFemale1, TaiFemale2, TaiMale1 };
            return voiceModels.Contains(voiceModel);
        }
    }
}
