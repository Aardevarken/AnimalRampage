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
		private int turtleGenRefresh = 20;
		SpriteSheetAnimation moveAnimation;
		Vector2 position;

		public override void LoadContent(ContentManager Content, InputManager inputManager)
		{
			base.LoadContent (Content, inputManager);
			player = new Player ();
			player.LoadContent (content, inputManager);
			enemies = new List<Enemy> ();
			moveAnimation = new LoopingAnimation ();

			Texture2D image = content.Load<Texture2D> ("stereo_sprite_sheet");

			position = new Vector2 (ScreenManager.Instance.dimensions.X/2, 100);
			moveAnimation.LoadContent (content, image, new Vector2(5, 1), new Vector2(0, 0), 4);
			moveAnimation.Scale = 0.5f;
		}

		public override void UnloadContent()
		{
			moveAnimation.UnloadContent ();
			base.UnloadContent ();
			player.UnloadContent ();
			foreach (Enemy enemy in enemies) {
				enemy.UnloadContent ();
			}
		}

		public override void Update(GameTime gameTime)
		{
			inputManager.Update ();
			moveAnimation.Update (gameTime);
			player.Update (gameTime, inputManager);
			if (enemies.Count < 50 && turtleGenRefresh < 1) {
				enemies.Add (EnemyFactory.getInstance ("spin", content, inputManager));
				turtleGenRefresh = 20;
			}
			foreach (Enemy enemy in enemies) {
				enemy.Update (gameTime, inputManager);
				if (enemy.position.X < 0 || enemy.position.X > ScreenManager.Instance.dimensions.X) {
					enemies.Remove (enemy);
					enemy.UnloadContent ();
					break;
				}
			}
			turtleGenRefresh--;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			moveAnimation.Draw(spriteBatch,position);
			base.Draw (spriteBatch);
			player.Draw (spriteBatch);
			foreach (Enemy enemy in enemies) {
				enemy.Draw (spriteBatch);
			}
		}


	}
}

