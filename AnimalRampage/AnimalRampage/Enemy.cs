﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class Enemy : Entity
	{
		public override void LoadContent (ContentManager content, InputManager inputManager)
		{
			base.LoadContent (content, inputManager);
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