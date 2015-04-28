using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class Enemy : Entity, FiniteAnimationSubscriber
	{
		protected FiniteAnimation death;

		public virtual void LoadContent (ContentManager content, InputManager inputManager, Vector2 position)
		{
			base.LoadContent (content, inputManager);
			this.position = position;
			Texture2D explode = content.Load<Texture2D> ("turtle_death");
			death = new FiniteAnimation ();
			death.LoadContent (content, explode, new Vector2(6, 1), new Vector2(0, 0), 5);
			death.subscribe (this);
			death.Scale = 0.4f;
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
			death.UnloadContent ();
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
			death.Update (gameTime);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			if (dying) {
				death.Draw (spriteBatch, position);
			} else {
				moveAnimation.Draw (spriteBatch, position);
			}
		}

		public virtual void randomize () {
			Random random = new Random();
			terminalVelocity = (float) (random.NextDouble ()*5.0 + 5.0);
			jumpSpeed = (float) (random.NextDouble ()*-25.0 - 5.0);
			fallSpeed = (float)(random.NextDouble ()*0.1 + 0.5);
			velocity = new Vector2 ((float) (random.NextDouble()*4.0 - 2.0), velocity.Y);
			if (velocity.X < 0) {
				moveAnimation.flippedHorizontally = true;
			}
		}

		public override void Kill() {
			base.Kill ();
			death.Start ();
			jumpSpeed = 0;
			fallSpeed = 0;
			velocity = new Vector2 (0,0);
			position = new Vector2 ((float) (position.X - 20.0), (float) (position.Y - 35.0));
		}

		#region FiniteAnimationSubscriber implementation

		public void animationFinished () {
			dead = true;
		}

		#endregion
	}
}