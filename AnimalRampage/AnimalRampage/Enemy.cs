using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class Enemy : Entity
	{
		protected LoopingAnimation animation;

		public virtual void LoadContent (ContentManager content, InputManager inputManager, Vector2 position)
		{
			base.LoadContent (content, inputManager);
			this.position = position;
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);
		}

		public virtual void randomize () {
			Random random = new Random();
			terminalVelocity = (float) (random.NextDouble ()*5.0 + 5.0);
			jumpSpeed = (float) (random.NextDouble ()*-25.0 - 5.0);
			fallSpeed = (float)(random.NextDouble ()*0.1 + 0.5);
			velocity = new Vector2 ((float) (random.NextDouble()*4.0 - 2.0), velocity.Y);
			if (velocity.X < 0) {
				animation.flippedHorizontally = true;
			}
		}
	}
}