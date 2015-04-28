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
			enemies = new List<Enemy> ();
		}

		public override void UnloadContent()
		{
			base.UnloadContent ();
			player.UnloadContent ();
			foreach (Enemy enemy in enemies) {
				enemy.UnloadContent ();
			}
		}

		public override void Update(GameTime gameTime)
		{
			inputManager.Update ();
			player.Update (gameTime, inputManager);
			if (enemies.Count < 50) {
				enemies.Add (EnemyFactory.getInstance ("spin", content, inputManager));
			}
			foreach (Enemy enemy in enemies) {
				enemy.Update (gameTime, inputManager);
				if (enemy.position.X < 0 || enemy.position.X > ScreenManager.Instance.dimensions.X) {
					enemies.Remove (enemy);
					enemy.UnloadContent ();
					break;
				}
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw (spriteBatch);
			player.Draw (spriteBatch);
			foreach (Enemy enemy in enemies) {
				enemy.Draw (spriteBatch);
			}
		}


	}
}

