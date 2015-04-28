using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnimalRampage
{
	public class Player : Entity, FiniteAnimationSubscriber
	{
		private List<Weapon> backpack;
		InputManager input;
		private LoopingAnimation walkAnimation;
		private FiniteAnimation throwAnimation;
		private Boolean throwing;

		public override void LoadContent (ContentManager content, InputManager inputManager)
		{
			input = inputManager;
			position = new Vector2 (0, 100);
			throwing = false;

			backpack = new List<Weapon> ();
			base.LoadContent (content, inputManager);

			image = content.Load<Texture2D> ("bear_man_sprite_sheet");
			walkAnimation = new LoopingAnimation ();
			walkAnimation.LoadContent (content, image, new Vector2(8, 5), new Vector2(0, 0), 7);
			throwAnimation = new FiniteAnimation ();
			throwAnimation.LoadContent (content, image, new Vector2(8, 5), new Vector2(0, 1), 4);
			throwAnimation.subscribe (this);

			box = new Rectangle ((int)position.X, (int)position.Y, walkAnimation.FrameWidth, walkAnimation.FrameHeight);
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
			walkAnimation.UnloadContent ();
			throwAnimation.UnloadContent ();
		}

		public override void Update (GameTime gameTime, InputManager input)
		{
			base.Update (gameTime, input);
			if (input.KeyDown (Keys.Right, Keys.D)) {
				velocity.X = horizontalSpeed;
				walkAnimation.isPaused = false;
				walkAnimation.flippedHorizontally = false;
				throwAnimation.flippedHorizontally = false;
			} else if (input.KeyDown (Keys.Left, Keys.A)) {
				velocity.X = -horizontalSpeed;
				walkAnimation.isPaused = false;
				walkAnimation.flippedHorizontally = true;
				throwAnimation.flippedHorizontally = true;
			} else {
				velocity.X = 0;
				walkAnimation.isPaused = true;
			}
			//running
			if (input.KeyDown (Keys.LeftShift)) {
				velocity.X *= 1.5f;
			}

			if (input.KeyDown (Keys.X)) {
				throwing = true;
				throwAnimation.Start ();
			}

			if (input.KeyDown (Keys.Space)) {
				this.Jump ();
			}

			walkAnimation.Update (gameTime);
			throwAnimation.Update (gameTime);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			if (throwing) {
				throwAnimation.Draw (spriteBatch, position);
			} else {
				walkAnimation.Draw (spriteBatch, position);
			}
		}

		#region FiniteAnimationSubscriber implementation

		public void animationFinished () {
			throwing = false;
		}

		#endregion
	}
}