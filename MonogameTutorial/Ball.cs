using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameTutorial;

public class Ball
{
    Texture2D Texture;
    Vector2 Position;
    private float Speed;

    public Ball(float speed)
    {
        this.Speed = speed;
    }

    public void Initialize(GraphicsDeviceManager graphics)
    {
        Position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
    }

    public void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("ball");
    }

    public void Update(GraphicsDeviceManager graphics, GameTime gameTime)
    {
        float updatedBallSpeed = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.W))
        {
            Position.Y -= updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.S))
        {
            Position.Y += updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.A))
        {
            Position.X -= updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.D))
        {
            Position.X += updatedBallSpeed;
        }

        if (Position.X > graphics.PreferredBackBufferWidth - Texture.Width / 2)
        {
            Position.X = graphics.PreferredBackBufferWidth - Texture.Width / 2;
        }
        else if (Position.X < Texture.Width / 2)
        {
            Position.X = Texture.Width / 2;
        }

        if (Position.Y > graphics.PreferredBackBufferHeight - Texture.Height / 2)
        {
            Position.Y = graphics.PreferredBackBufferHeight - Texture.Height / 2;
        }
        else if (Position.Y < Texture.Height / 2)
        {
            Position.Y = Texture.Height / 2;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, 
            Position,
            null,
            Color.White,
            0f,
            new Vector2(Texture.Width / 2, Texture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f);
    }
}