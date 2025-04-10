using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Dijar;

public class Game1 : Game
{

    Texture2D texture;
    Vector2 position;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        texture = Content.Load<Texture2D>("car");
        position = new Vector2(0,0);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

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


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightGray);

        _spriteBatch.Begin();
        _spriteBatch.Draw(texture, position, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
