using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public class SpinningTurtle : Enemy
	{
		public override void LoadContent (ContentManager content, InputManager inputManager, Vector2 position)
		{
			base.LoadContent (content, inputManager, position);
			moveAnimation = new LoopingAnimation ();
			image = content.Load<Texture2D> ("turtle");
			moveAnimation.LoadContent (content, image, new Vector2(8, 2), new Vector2(0, 1), 8);
			float scale = 0.5f;
			moveAnimation.Scale = scale;
			box = new Rectangle ((int)position.X, (int)position.Y, (int)(moveAnimation.FrameWidth * scale), (int)(moveAnimation.FrameHeight * scale));
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
			moveAnimation.UnloadContent ();
		}

		public override void Update (GameTime gameTime, InputManager input)
		{
			base.Update (gameTime, input);
			moveAnimation.Update (gameTime);
			if (isOnGround ()) {
				Jump ();
			}
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);
			//moveAnimation.Draw (spriteBatch, position);
		}
	}
}

