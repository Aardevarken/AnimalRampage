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
			position = new Vector2 (100, 100);
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
			if (input.KeyDown (Keys.Right, Keys.D)) {
				position.X += 5;
				moveAnimation.isPaused = false;
			} else if (input.KeyDown (Keys.Left, Keys.A)) {
				position.X -= 5;
				moveAnimation.isPaused = false;
			} else {
				moveAnimation.isPaused = true;
			}

			if (input.KeyDown (Keys.X)) {
				holding.Throw ();
			}
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

