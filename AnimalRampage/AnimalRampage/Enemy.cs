using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class Enemy : Entity
	{
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
	}
}