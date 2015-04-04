using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public class Player : Entity
	{
		private Weapon holding;
		private List<Weapon> backpack;
		InputManager input;

		public override void LoadContent (ContentManager content, InputManager inputManager)
		{
			holding = new Turtle ();
			holding.LoadContent (content);
			backpack = new List<Weapon> ();
			base.LoadContent (content, inputManager);
			moveAnimation = new LoopingAnimation ();
			input = inputManager;
			image = content.Load<Texture2D> ("mc_upperbody");
			position = new Vector2 (0, 100);
			moveAnimation.LoadContent (content, image, new Vector2(8, 3), new Vector2(0, 0), 8);
			moveAnimation.Scale = 0.5f;
		}



		public override void UnloadContent ()
		{
			base.UnloadContent ();
			moveAnimation.UnloadContent ();
		}

		public override void Update (GameTime gameTime, InputManager input)
		{
			base.Update (gameTime, input);
			if (input.KeyDown (Keys.Right, Keys.D)) {
				velocity.X = horizontalSpeed;
				moveAnimation.isPaused = false;
			} else if (input.KeyDown (Keys.Left, Keys.A)) {
				velocity.X = -horizontalSpeed;
				moveAnimation.isPaused = false;
			} else {
				velocity.X = 0;
				moveAnimation.isPaused = true;
			}
			//running
			if (input.KeyDown (Keys.LeftShift))
				velocity.X *= 1.5f;

			if (input.KeyDown (Keys.X)) {
				holding.Throw ();
			}
			if (input.KeyDown (Keys.Space))
				this.Jump ();
			holding.Update (gameTime);
			moveAnimation.Update (gameTime);
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			moveAnimation.Draw (spriteBatch, position);
			holding.Draw (spriteBatch, position);
		}
	}
}

