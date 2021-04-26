using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace tower_defense
{
    public class Sprite
    {
        private Vector2 _position;
        private Texture2D _texture;
        private Rectangle _sourceRectangle;
        private Color _color;

        public void SetColor(Color color)
        {
            this._color = color;
        }

        public Sprite(float x,float y, string imgKey)
        {
            this._position = new Vector2(x,y);
            this._texture = Resources.Images[imgKey];
            this._sourceRectangle = Rectangle.Empty;
            this._color = Color.White;
        }

        public Sprite(float x, float y, string imgKey, Rectangle sourceRect)
        {
            this._position = new Vector2(x,y);
            this._texture = Resources.Images[imgKey];
            this._sourceRectangle = sourceRect;
            this._color = Color.White;
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            if (_sourceRectangle.Equals(Rectangle.Empty))
                spriteBatch.Draw(this._texture, this._position, this._color);
            else
                spriteBatch.Draw(this._texture, this._position, this._sourceRectangle, this._color);
        }

    }
}
