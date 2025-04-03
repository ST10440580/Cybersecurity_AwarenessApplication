using System;
using System.Media;
using System.IO;

namespace Cybersecurity_AwarenessApplication
{
    public class voice_greeeting
    {
        public voice_greeeting()
        {
            // Get the base directory where the application is running to ensure image displays on other devi
            string Main_voice_directoy = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the audio file by combining main_voice_directory with the actual wav
            string voice_greeting_path = Path.Combine(Main_voice_directoy, "voicegreeting.wav");

            // Prints out the full audio path of the voice greeting
            Console.WriteLine("Audio file path: " + voice_greeting_path);

            // Method is called to be implemented
            PlayIntro(voice_greeting_path);
        }

        private void PlayIntro(string audio_path)
        {
            try
            {
                // Check if the audio file exists before trying to play it to assist in debugging
                if (File.Exists(audio_path))
                {
                    using (SoundPlayer player = new SoundPlayer(audio_path))
                    {
                        player.PlaySync();  // Play the audio
                    }
                }
                else
                {
                    // If the file doesn't exist, log an error message
                    Console.WriteLine("Error:Your audio cannot be played at this following directory as it does not exist:" + audio_path);
                }
            }
            catch (Exception error)
            {
               
                Console.WriteLine("Audio could not be played: " + error.Message);
            }
        }
    }
}
