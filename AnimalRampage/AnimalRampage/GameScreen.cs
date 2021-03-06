﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class GameScreen
	{
		protected ContentManager content;
		protected InputManager inputManager;

		public virtual void LoadContent (ContentManager Content, InputManager inputManager)
		{
			content = new ContentManager (Content.ServiceProvider, "Content");
			this.inputManager = inputManager;
		}

		public virtual void UnloadContent() 
		{
			content.Unload ();
			inputManager = null;
		}

		public virtual void Update (GameTime gameTime){
			inputManager.Update ();
		}
		public virtual void Draw(SpriteBatch spriteBatch){}
	}
}