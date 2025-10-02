using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibTest;

namespace Derailed
{
    public class Game1 : Core
    {

        public Game1() : base("Derailed", 1280,720,false)
        {

        }
        private Texture2D _Mymy;
        private float tiltRange = 3.2f;
        private float curTilt = 0.0f;
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _Mymy = Content.Load<Texture2D>("src/img/72e8f9dbae541b3769dd531c5627b6e1");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            if ((curTilt + 0.1f * gameTime.ElapsedGameTime.TotalSeconds) > MathHelper.ToRadians(360))
            {
                curTilt = 0.0f;
            }
            else
            {
                curTilt += 0.1f;
            }

            SpriteBatch.Draw(
                _Mymy,
                new Vector2(
                    Window.ClientBounds.Width * 0.5f,
                    Window.ClientBounds.Height * 0.5f),
                null,
                Color.White,
                MathHelper.ToRadians(45 + MathF.Sin(curTilt)*tiltRange),
                new Vector2(_Mymy.Width * 0.5f, _Mymy.Height * 0.5f),
                1.0f * MathF.Cos(curTilt) +2,
                SpriteEffects.None,
                0.0f);
            
            SpriteBatch.End();
            // TODO: Add your drawing code here



            base.Draw(gameTime);
        }
    }
}
