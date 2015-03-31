using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public class Turtle : Weapon
	{
		protected SpriteSheetAnimation throwAnimation;
		protected Texture2D image;
		private bool thrown;
		private int throwProgress;

		#region implemented abstract members of Weapon
		public override void LoadContent (ContentManager content)
		{
			throwAnimation = new SpriteSheetAnimation ();
			image = content.Load<Texture2D> ("secondary_attack");
			throwAnimation.LoadContent (content, image, "", Vector2.Zero, new Vector2(5, 1));
			throwAnimation.Scale = 0.5f;
			thrown = false;
			throwProgress = 0;
		}

		public override void Throw () {
			thrown = true;
		}
			
		public override void Draw (SpriteBatch spriteBatch, Vector2 position)
		{
			if (thrown) {
				throwAnimation.isPaused = false;
				throwAnimation.Draw (spriteBatch, position);
			} else {
				throwAnimation.isPaused = true;
			}
		}
			
		public override void Update (GameTime gameTime)
		{
			if (throwProgress == 5) {
				thrown = false;
				throwProgress = 0;
			}
			throwProgress += 1;
			throwAnimation.Update (gameTime);
		}
		#endregion
	}
};

