using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;

namespace SpaceGame.Entities
{
    public class Laser : Entity
    {
        public Laser(TextureRegion2D textureRegion, Vector2 velocity)
        {
            _timeToLive = 1.0f;
            _sprite = new Sprite(textureRegion)
            {
                Scale = Vector2.One*0.5f
            };

            Velocity = velocity;
        }

        private readonly Sprite _sprite;
        private float _timeToLive;

        public Vector2 Position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }

        public float Rotation
        {
            get { return _sprite.Rotation; }
            set { _sprite.Rotation = value; }
        }

        public Vector2 Velocity { get; set; }

        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity * deltaTime;

            _timeToLive -= deltaTime;

            if (_timeToLive <= 0)
                Destroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite);
        }
    }
}