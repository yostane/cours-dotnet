using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace first_game;

public class Game1 : Game
{
    private Point _p = new();

    private int _size = 100;
    private bool _isColliding = false;
    private Point _enemyPosition = new(50, 50);
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _texture, _enemyTexture;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

    }

    protected override void Initialize()
    {

        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _texture = Content.Load<Texture2D>("mickeyswildadventue");
        _enemyTexture = Content.Load<Texture2D>("pat-hibulaire");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _p.Y += 1;
        }
        else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _p.Y -= 1;
        }

        if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _p.X -= 1;
        }
        else if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _p.X += 1;
        }

        _enemyPosition.X = (GraphicsDevice.Viewport.Width - _size) / 2;
        _enemyPosition.Y = (GraphicsDevice.Viewport.Height - _size) / 2;

        bool isCollisionX = _p.X >= _enemyPosition.X && _p.X <= _enemyPosition.X + _size
                || _p.X + _size >= _enemyPosition.X && _p.X + _size <= _enemyPosition.X + _size;
        bool isCollisionY = _p.Y >= _enemyPosition.Y && _p.Y <= _enemyPosition.Y + _size ||
            _p.Y + _size >= _enemyPosition.Y && _p.Y + _size <= _enemyPosition.Y + _size;
        if (isCollisionX && isCollisionY)
        {
            _isColliding = true;
        }
        else
        {
            _isColliding = false;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_isColliding ? Color.DarkRed : Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_texture, new Rectangle(_p.X, _p.Y, _size, _size), Color.White);
        _spriteBatch.Draw(_enemyTexture, new Rectangle(_enemyPosition.X, _enemyPosition.Y, _size, _size), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
