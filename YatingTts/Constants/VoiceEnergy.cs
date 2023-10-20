namespace YatingTts.Constants
{
    public class VoiceEnergy
    {
        public static double Max = 1.5;
        public static double Min = 0.5;

        public static bool Validation(double voiceEnergy)
        {
            return (voiceEnergy <= Max && voiceEnergy >= Min);
        }
    }
}

