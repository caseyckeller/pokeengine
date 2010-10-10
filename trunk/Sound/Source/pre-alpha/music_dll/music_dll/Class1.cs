/*
 * A very basic sound library
 * for the IAPL open source game
 * 
 * Usage- play_sound(path-to-sound);
 * What it does- Plays music in the background
 * Usefulness- 6/10. It saves a few lines of code anyways :p
 * 
 * by bigplrbear
 * 10/9/2010
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAPL.Sound
{
    public class Sound
    {
        string sound_location; //location of the sound you want to play

        public static void play_sound(string sound_location)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = sound_location;
            wplayer.controls.play();
        }
    }
}
