namespace YatingTts.Constants
{
    public class VoiceSpeed
    {
        public static double Max = 1.5;
        public static double Min = 0.5;

        public static bool Validation(double voiceSpeed)
        {
            return (voiceSpeed <= Max && voiceSpeed >= Min);
        }
    }
}

