using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public class Turtle : Weapon, FiniteAnimationSubscriber
	{
		protected FiniteAnimation throwAnimation;
		protected Texture2D image;

		#region implemented abstract members of Weapon
		public override void LoadContent (ContentManager content)
		{
			throwAnimation = new FiniteAnimation ();
			image = content.Load<Texture2D> ("secondary_attack");
			throwAnimation.LoadContent (content, image, new Vector2(5, 1), new Vector2(0, 0), 5);
			throwAnimation.Scale = 0.5f;
			throwAnimation.subscribe (this);
		}

		public override void Throw () {
			throwAnimation.Start ();
		}
			
		public override void Draw (SpriteBatch spriteBatch, Vector2 position) {
			throwAnimation.Draw (spriteBatch, position);
		}
			
		public override void Update (GameTime gameTime)
		{
			throwAnimation.Update (gameTime);
		}
		#endregion

		#region FiniteAnimationSubscriber implementation

		public void animationFinished () {}

		#endregion
	}
};

