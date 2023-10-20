namespace YatingTts.Constants
{
    public class VoicePitch
    {
        public static double Max = 1.5;
        public static double Min = 0.5;

        public static bool Validation(double voicePitch)
        {
            return (voicePitch <= Max && voicePitch >= Min);
        }
    }
}

