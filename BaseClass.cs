using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Dijar
{
    public class BaseClass
    {
        public Vector2 Origin;
        public Vector2 Direction;
        protected Texture2D texture;
        protected KeyboardState currentKey;
        protected KeyboardState previousKey;
        public Vector2 position;
        public Color color = Color.White;
        public float speed = 0f;
        public float LifeSpan;
        public bool isRemoved = false;
        public Input input;
        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;
        protected float rotation;

        public float Rotation
        {
            {}
            set => rotation = value;
        }

        public Matrix Transform =>
            Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
            Matrix.CreateRotationZ(rotation) *
            Matrix.CreateTranslation(new Vector3(position, 0));

        public BaseClass(Texture2D texture)
        {
            this.texture = texture;
        }

        public Rectangle Rectangle =>
            texture != null
                ? new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height)
                : throw new Exception("Unknown sprite");

        public virtual void Update(GameTime gameTime, List<BaseClass> baseclassList)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                spriteBatch.Draw(texture, position, null, color, rotation, Origin, 1, SpriteEffects.None, 0);
            }
        }
    }
}
