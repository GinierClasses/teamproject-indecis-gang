using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Core
{
    //1 Image par direction
    public enum FramesIndex
    {
        
        RIGHT_1 = 1,
        RIGHT_2 = 0,
        RIGHT_3 = 4,
        LEFT_1,
        LEFT_2,
        LEFT_3
    }

    class GameObject
    {
        //Position d'ou l'image doit s'afficher (1.4.1)
        public Vector2 Position;
        //L'image à afficher (1.4.1)
        public Texture2D Texture;

        //Zone de l'image à afficher
        public Rectangle Source;
        //Durée depuis que l'image est à l'écran
        public float Time;
        //Durée de visibilité d'une image 
        public float FrameTime = 0.1f;
        //Indice de l'image en cours
        public int FrameIndex;

        private int _totalFrames;
        public int TotalFrames { get { return _totalFrames; } }
        private int _frameWidth;
        public int FrameWidth { get { return _frameWidth; } }
        private int _frameHeight;
        public int FrameHeight { get { return _frameHeight; } }

        public GameObject() { }

        public GameObject(int totalAnimationFrames, int frameWidth, int frameHeight)
        {
            _totalFrames = totalAnimationFrames;
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
        }

        //1.4.2
        public void Draw(SpriteBatch spriteBatch)
        {
            //Pour dessiner on passe a la méthode DRAW(Image à afficher,
            //Position d'ou l'image doit être, Couleur du dessin --> Blanc pour ne pas modifier l'image)
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        //Méthode de rendu
        public void DrawAnimation(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Source, Color.White);
        }
        /// <summary>
        /// Permet de calculer le temps passé depuis notre dernier sprite refresh.
        /// Si temps du sprite dépassé nous passons au prochain indice 
        ///     Remet la var Time à zero
        /// Si l'indice dépasse le nombre de sprite contenu dans la collection
        /// on repasse au premier 
        /// Ensuite nous calculons la position du nouveau sprite en déterminant
        /// sa position par rapport à l'indice en cours (Valeur)
        /// </summary>
        /// <param name="gameTime">pour récuperer le temps en secondes</param>
        public void UpdateFrame(GameTime gameTime)
        {
            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (Time > FrameTime)
            {
                FrameIndex++;
                Time = 0f;
            }
            if (FrameIndex > _totalFrames)
            {
                FrameIndex = 0;
            }

            Source = new Rectangle(0, 0,
                                    FrameWidth, FrameHeight);
        }

        
    }
}
