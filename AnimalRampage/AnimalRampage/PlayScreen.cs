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
		SpriteSheetAnimation stereo1Animation;
		SpriteSheetAnimation stereo2Animation;
		Vector2 positionDj;
		Vector2 positionStereo1;
		Vector2 positionSteroe2;

		public override void LoadContent(ContentManager Content, InputManager inputManager)
		{
			base.LoadContent (Content, inputManager);
			player = new Player ();
			player.LoadContent (content, inputManager);
			enemies = new List<Enemy> ();
			moveAnimation = new LoopingAnimation ();
			stereo1Animation = new LoopingAnimation();
			stereo2Animation  = new LoopingAnimation();

			Texture2D dj = content.Load<Texture2D> ("wolfman_jack_sprite_sheet");
			Texture2D image1 = content.Load<Texture2D> ("stereo_sprite_sheet");


			positionDj = new Vector2 (ScreenManager.Instance.dimensions.X/2, 100);
			moveAnimation.LoadContent (content, dj, new Vector2(5, 1), new Vector2(0, 0), 4);
			moveAnimation.Scale = 0.5f;

			positionStereo1 = new Vector2 (ScreenManager.Instance.dimensions.X/2 + 40, 50);
			stereo1Animation.LoadContent (content, image1, new Vector2(5, 1), new Vector2(0, 0), 4);
			stereo1Animation.Scale = 0.5f;

			positionSteroe2 = new Vector2 (ScreenManager.Instance.dimensions.X/2 - 180, 50);
			stereo2Animation.LoadContent (content, image1, new Vector2(5, 1), new Vector2(0, 0), 4);
			stereo2Animation.Scale = 0.5f;
		}

		public override void UnloadContent()
		{
			moveAnimation.UnloadContent ();
			stereo1Animation.UnloadContent ();
			stereo2Animation.UnloadContent ();
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
			stereo1Animation.Update (gameTime);
			stereo2Animation.Update (gameTime);
			player.Update (gameTime, inputManager);
			if (enemies.Count < 50 && turtleGenRefresh < 1) {
				enemies.Add (EnemyFactory.getInstance ("spin", content, inputManager));
				turtleGenRefresh = 20;
			}
			foreach (Enemy enemy in enemies) {
				enemy.Update (gameTime, inputManager);
				if (enemy.getBox().Right < 0 || enemy.position.X > ScreenManager.Instance.dimensions.X) {
					enemies.Remove (enemy);
					enemy.UnloadContent ();
					break;
				}
			}
			turtleGenRefresh--;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			moveAnimation.Draw(spriteBatch,positionDj);
			stereo1Animation.Draw (spriteBatch, positionStereo1);
			stereo2Animation.Draw (spriteBatch, positionSteroe2);


			base.Draw (spriteBatch);
			player.Draw (spriteBatch);
			foreach (Enemy enemy in enemies) {
				enemy.Draw (spriteBatch);
			}
		}


	}
}

