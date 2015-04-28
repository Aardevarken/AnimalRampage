using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace AnimalRampage
{
	public class WigglingTurtle : Enemy
	{
		public override void LoadContent (ContentManager content, InputManager inputManager, Vector2 position)
		{
			base.LoadContent (content, inputManager, position);
			animation = new LoopingAnimation ();
			image = content.Load<Texture2D> ("turtle");
			animation.LoadContent (content, image, new Vector2(8, 2), new Vector2(0, 0), 1);
			float scale = 0.5f;
			animation.Scale = scale;
			box = new Rectangle ((int)position.X, (int)position.Y, (int)(animation.FrameWidth * scale), (int)(animation.FrameHeight * scale));
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
			animation.UnloadContent ();
		}

		public override void Update (GameTime gameTime, InputManager input)
		{
			base.Update (gameTime, input);
			animation.Update (gameTime);
			if (isOnGround ()) {
				Jump ();
			}
		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			animation.Draw (spriteBatch, position);
		}
	}
}
