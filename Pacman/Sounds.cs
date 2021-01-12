using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Pacman
{
    class Sounds
    {
        public static SoundPlayer menuSound = new SoundPlayer();
        public static SoundPlayer eatSound = new SoundPlayer();
        public static SoundPlayer eatSuperSound = new SoundPlayer();
        public static SoundPlayer eatGhostSound = new SoundPlayer();
        public static SoundPlayer loseSound = new SoundPlayer();
        public static SoundPlayer gameOverSound = new SoundPlayer();
        public static SoundPlayer winSound = new SoundPlayer();
        public static SoundPlayer optionSound = new SoundPlayer();

        public static void InitializePlayer(SoundPlayer player, string name)
        {
            string path = Path.GetFullPath(Path.Combine(System.Windows.Forms.Application.StartupPath, @"../../Resources/"));
            player.SoundLocation = path + name + ".wav";
            player.Load();
        }

        public static void InitializeSounds()
        {
            InitializePlayer(menuSound, "Menu");
            InitializePlayer(eatSound, "Mlem");
            InitializePlayer(eatSuperSound, "SuperMlem");
            InitializePlayer(eatGhostSound, "GhostMlem");
            InitializePlayer(loseSound, "Eaten");
            InitializePlayer(gameOverSound, "Dead");
            InitializePlayer(winSound, "Win");
            InitializePlayer(optionSound, "Option");
        }
    }
}
