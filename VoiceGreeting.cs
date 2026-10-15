using System.Media;

namespace CybersecurityBot
{
    public class VoiceGreeting
    {
        public static void PlayGreeting(string filePath)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.Play();
            }
            catch
            {
                // Audio file missing - continue silently
            }
        }
    }
}
