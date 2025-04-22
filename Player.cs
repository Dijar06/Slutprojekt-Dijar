using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Dijar
{
    public class Player : BaseClass
    {
        public bool HasDied = false;

        public Player(Texture2D texture) : base(texture)
        {
            position = new Vector2(30, 40);
            speed = 5f;
        }

        public override void Update(GameTime gameTime, List<BaseClass> baseclass)
        {
            Move();
        }

        public void Move()
        {
            KeyboardState key = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.W)){
            position.Y -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S)){
            position.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)){
            position.X -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D)){
            position.X += 3;
            }
        }
    }
}
