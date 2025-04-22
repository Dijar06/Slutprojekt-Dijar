namespace Slutprojekt_Dijar
{
    public class Bil : Baseclass, ICollidable
    {
        public int Health {get; set;}
        public float speed {get; set;}
        public int Score;

        public bool isDead{
            get{
                return Health <= 0;
            }
        }
        
        public Bil(Texture2D texture) : base(texture){
            speed = 5f;
        }

        public override void Update(GameTime gameTime, List<Baseclass> baseclass){
            if (isDead){
                return;
            }

            Move();
            foreach (var obj in objects){
                if (obj is Car){
                    continue;
                }
                if (obj.Rectangle.Intersects(this.Rectangle)){
                    speed++;
                    sprite.IsRemoved = true;
                }
            }
        }

        private void Move(){
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            if(Keyboard.GetState().IsKeyDown(Keys.A)){
                rotation -= Mathhelper.ToRadians(RotationVelocity);
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.D)){
                rotation += Mathhelper.ToRadians(RotationVelocity);
            }

            Direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.W)){
                Position += Direction * LinearVelocity;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S)){
                Position -= Direction * LinearVelocity;
            }

            Position = Vector2.Clamp(Position, new Vector2(0,0), new Vector2(Game1.ScreenWidth - this.Rectangle.Width, Game1.ScreenHeight - this.Rectangle.Height));
        }

        public virtual void OnCollide(Sprite sprite){
            throw new NotImplementedException();
        }
    }
}