using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameTutorial;

public class Game : Microsoft.Xna.Framework.Game
{
    private Ball ball;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        ball = new Ball(300f);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ball.Initialize(_graphics);
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        ball.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        ball.Update(_graphics, gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        ball.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}