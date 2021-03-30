using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace tower_defense
{
    public abstract class MenuBase
    {
        private Sprite _baseTower;
        public MenuBase() 
        {
            this._baseTower = new Sprite(0, 0, "BaseTowerTest");
        }

        public virtual void Update() { }

        public virtual void Draw(SpriteBatch spriteBatch) 
        {
            this._baseTower.Draw(spriteBatch);
        }


    }
}
