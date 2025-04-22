using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Dijar;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<BaseClass> objects;

    public static int ScreenWidth = 1280;
    public static int ScreenHeight = 720;

    private bool hasStarted = false;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        this.Window.AllowUserResizing = false;
        this.Window.Title = "Racing!";

        ScreenWidth = graphics.PreferredBackBufferWidth;
        ScreenHeight = graphics.PrefferedBackBufferHeight;
        graphics.IsFullScreen = false;
        graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        var carTexture = Content.Load<Texture2D>("car");

        objects = new List<BaseClass>(){
            new Bil(carTexture){
                Position = new Vector2(100, 100),
                Origin = new Vector2(carTexture.Width / 2, carTexture.Height / 2),
        }
        };

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (var obj in objects){
            obj.Update(gameTime, objects);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightGray);

        _spriteBatch.Begin();
        foreach (var obj in objects){
            obj.Draw(_spriteBatch);
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
