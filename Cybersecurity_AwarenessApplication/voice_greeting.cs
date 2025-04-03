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
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the audio file, assuming it's in the same directory as the executable
            string audioFilePath = Path.Combine(baseDirectory, "voicegreeting.wav");

            // Print the full audio path for debugging purposes
            Console.WriteLine("Audio file path: " + audioFilePath);

            // Call the method to play the audio
            PlayIntro(audioFilePath);
        }

        private void PlayIntro(string fullAudioPath)
        {
            try
            {
                // Check if the audio file exists before trying to play it to assist in debugging
                if (File.Exists(fullAudioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(fullAudioPath))
                    {
                        player.PlaySync();  // Play the audio
                    }
                }
                else
                {
                    // If the file doesn't exist, log an error message
                    Console.WriteLine("Error: The audio file does not exist at " + fullAudioPath);
                }
            }
            catch (Exception e)
            {
                // Catch and log any exceptions
                Console.WriteLine("Error playing the audio: " + e.Message);
            }
        }
    }
}
