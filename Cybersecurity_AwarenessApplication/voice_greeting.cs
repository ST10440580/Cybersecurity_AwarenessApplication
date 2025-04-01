using System;
using System.Media;

namespace Cybersecurity_AwarenessApplication
{
    internal class voice_greeeting
    {
        public voice_greeeting()
        {
            string audio_location = AppDomain.CurrentDomain.BaseDirectory;


            Console.WriteLine(audio_location);

            string new_audio_location = audio_location.Replace("bin\\Debug\\", "");

            string full_audio_path = new_audio_location + "voicegreeting.wav";


            play_intro(full_audio_path);

        }
        private void play_intro(string full_audio_path)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_audio_path);
                player.PlaySync();
            }
            }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
   