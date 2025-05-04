using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Dijar
{
    public class Bil : BaseClass
    {
        public int Health { get; set; } = 1;
        public int Score;

        public bool isDead => Health <= 0;

        public Bil(Texture2D texture) : base(texture)
        {
            speed = 5f;
        }

        public override void Update(GameTime gameTime, List<BaseClass> objects)
        {
            if (isDead)
                return;

            Move();

            // Kollisionshantering exempel
            foreach (var obj in objects)
            {
                if (obj == this)
                    continue;

                if (obj.Rectangle.Intersects(this.Rectangle))
                {
                    speed += 1;
                    obj.isRemoved = true;
                }
            }
        }

        private void Move()
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            if (currentKey.IsKeyDown(Keys.A))
                rotation -= MathHelper.ToRadians(RotationVelocity);
            if (currentKey.IsKeyDown(Keys.D))
                rotation += MathHelper.ToRadians(RotationVelocity);

            Direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            if (currentKey.IsKeyDown(Keys.W))
                position += Direction * LinearVelocity;
            if (currentKey.IsKeyDown(Keys.S))
                position -= Direction * LinearVelocity;

            position = Vector2.Clamp(position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - Rectangle.Width, Game1.ScreenHeight - Rectangle.Height));
        }
    }
}
