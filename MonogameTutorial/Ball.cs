using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameTutorial;

public class Ball
{
    Texture2D texture;
    Vector2 position;
    private float speed;

    public Ball(float speed)
    {
        this.speed = speed;
    }

    public void Initialize(GraphicsDeviceManager graphics)
    {
        position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
    }

    public void LoadContent(ContentManager content)
    {
        texture = content.Load<Texture2D>("ball");
    }

    public void Update(GraphicsDeviceManager graphics, GameTime gameTime)
    {
        float updatedBallSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.W))
        {
            position.Y -= updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.S))
        {
            position.Y += updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.A))
        {
            position.X -= updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.D))
        {
            position.X += updatedBallSpeed;
        }

        if (position.X > graphics.PreferredBackBufferWidth - texture.Width / 2)
        {
            position.X = graphics.PreferredBackBufferWidth - texture.Width / 2;
        }
        else if (position.X < texture.Width / 2)
        {
            position.X = texture.Width / 2;
        }

        if (position.Y > graphics.PreferredBackBufferHeight - texture.Height / 2)
        {
            position.Y = graphics.PreferredBackBufferHeight - texture.Height / 2;
        }
        else if (position.Y < texture.Height / 2)
        {
            position.Y = texture.Height / 2;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, 
            position,
            null,
            Color.White,
            0f,
            new Vector2(texture.Width / 2, texture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f);
    }
}