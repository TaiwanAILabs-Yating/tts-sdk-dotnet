using System;
using System.Collections.Generic;
using System.Linq;

namespace YatingTts.Constants
{
    public class AudioSampleRate
    {
        public static string SR16k = "16K";
        public static string SR22k = "22K";

        public static bool Validation(string voiceModel, string audioSampleRate)
        {
            List<string> list = new List<string>();

            switch (voiceModel)
            {
                case VoiceModel.ZhEnFemale1:
                case VoiceModel.ZhEnFemale2:
                case VoiceModel.ZhEnMale1:
                    list.Add(SR16k);
                    list.Add(SR22k);
                    break;
                case VoiceModel.ZhEnMale2:
                    list.Add(SR22k);
                    break;
                case VoiceModel.TaiFemale1:
                case VoiceModel.TaiFemale2:
                case VoiceModel.TaiMale1:
                    list.Add(SR16k);
                    break;
            }

            string[] audioSampleRates = list.ToArray();
            return audioSampleRates.Contains(audioSampleRate);
        }
    }
}

