using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public class PlayScreen : GameScreen
	{
		private Player player;
		private List<Enemy> enemies;

		public override void LoadContent(ContentManager Content, InputManager inputManager)
		{
			base.LoadContent (Content, inputManager);
			player = new Player ();
			player.LoadContent (content, inputManager);
		}

		public override void UnloadContent()
		{
			base.UnloadContent ();
			player.UnloadContent ();
			foreach (Enemy enemy in enemies) {
				
			}
				//.UnloadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			inputManager.Update ();
			player.Update (gameTime, inputManager);
			//test.Update (gameTime, inputManager);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);
			player.Draw (spriteBatch);
			//test.Draw (spriteBatch);
		}


	}
}

