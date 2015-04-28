using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public abstract class Weapon
	{
		public abstract void LoadContent (ContentManager content);
		public abstract void Draw (SpriteBatch spriteBatch, Vector2 position);
		public abstract void Throw ();
		public abstract void Update (GameTime gameTime);
	}
}

