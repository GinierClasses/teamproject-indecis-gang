using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    public class Resources
    {
        public static Dictionary<string, Texture2D> Images;
        public static Dictionary<string, SoundEffect> Sounds;

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            List<string> towerSprites = new List<string>()
            {
                "BaseTowerTest",
                "th"
            };

            foreach(var nom in towerSprites)
                Images.Add(nom, content.LoadLocalized<Texture2D>("towerSprites/" + nom));


        }

        public static void LoadSounds(ContentManager content)
        {
            Sounds = new Dictionary<string, SoundEffect>();

            List<string> sounds = new List<string>() 
            {
                
            };

            foreach (var nomS in sounds)
                Images.Add(nomS, content.Load<Texture2D>("towerSounds/"+ nomS));
        }
    }
}
