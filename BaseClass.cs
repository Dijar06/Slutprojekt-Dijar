using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Dijar
{
    public class BaseClass
    {
        protected Texture2D texture;
        protected KeyboardState currentKey;
        protected KeyboardState previousKey;
        public Vector2 position;
        public Color color = Color.White;
        public float speed = 0f;
        public float LifeSpan;
        public bool isRemoved = false;
        public Input input;

        public BaseClass(Texture2D texture)
        {
            this.texture = texture;
        }

        public Rectangle Rectangle
        {
            get{
                if (texture != null){
                    return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
                }
                throw new Exception("Unknown sprite");
            }
        }

        public virtual void Update(GameTime gameTime, List<BaseClass> baseclassList)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, color);
        }
    }
}
