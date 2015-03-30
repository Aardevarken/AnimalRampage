using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class Player : Entity
	{
		InputManager input;

		public override void LoadContent (ContentManager content, InputManager inputManager)
		{
			base.LoadContent (content, inputManager);
			moveAnimation = new SpriteSheetAnimation ();
			input = inputManager;
			Vector2 tempFrames = Vector2.Zero;
			image = content.Load<Texture2D> ("mc_upperbody_ss");
			postion = new Vector2 (100, 100);
			moveAnimation.LoadContent (content, image, "", postion);
			moveAnimation.Scale = 0.5f;
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
			moveAnimation.UnloadContent ();
		}

		public override void Update (GameTime gameTime, InputManager input)
		{
			moveAnimation.isActive = true;
			if (input.KeyDown (Keys.Right, Keys.D)) {
				moveAnimation.currentFrame = new Vector2 (moveAnimation.currentFrame.X, 0);
				moveAnimation.Position = new Vector2 (moveAnimation.Position.X + 10, moveAnimation.Position.Y);
			} 
			else if (input.KeyDown (Keys.Left, Keys.A)) 
			{
				moveAnimation.currentFrame = new Vector2 (moveAnimation.currentFrame.X, 1);
				moveAnimation.Position = new Vector2 (moveAnimation.Position.X - 10, moveAnimation.Position.Y);
			}
			else
				moveAnimation.isActive = false;
			moveAnimation.Update (gameTime);

		}

		public override void Draw (SpriteBatch spriteBatch)
		{
			moveAnimation.Draw (spriteBatch);
		}
	}
}

