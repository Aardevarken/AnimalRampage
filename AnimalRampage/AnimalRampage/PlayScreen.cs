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
		SpriteSheetAnimation floorAnimaition;
		Vector2 positionDj;
		Vector2 positionStereo1;
		Vector2 positionSteroe2;
		Vector2 positionFloor;
		Vector2 positionFloor2;
		Vector2 positionFloor3;

		public override void LoadContent(ContentManager Content, InputManager inputManager)
		{
			base.LoadContent (Content, inputManager);
			player = new Player ();
			player.LoadContent (content, inputManager);
			enemies = new List<Enemy> ();
			moveAnimation = new LoopingAnimation ();
			stereo1Animation = new LoopingAnimation();
			stereo2Animation  = new LoopingAnimation();
			floorAnimaition = new LoopingAnimation ();

			Texture2D floor =  content.Load<Texture2D> ("floor");

			Texture2D dj = content.Load<Texture2D> ("wolfman_jack_sprite_sheet");
			Texture2D image1 = content.Load<Texture2D> ("stereo_sprite_sheet");

			positionFloor = new Vector2 (-200, 400);
			positionFloor2 = new Vector2 (100, 400);
			positionFloor3 = new Vector2 (300, 400);
			floorAnimaition.LoadContent (content, floor, new Vector2(1, 1), new Vector2(0, 0), 1);
			floorAnimaition.Scale = 0.6f;

			positionDj = new Vector2 (ScreenManager.Instance.dimensions.X/2 -100, 350);
			moveAnimation.LoadContent (content, dj, new Vector2(5, 1), new Vector2(0, 0), 4);
			moveAnimation.Scale = 0.65f;

			positionStereo1 = new Vector2 (ScreenManager.Instance.dimensions.X/2 + 40 , 300);
			stereo1Animation.LoadContent (content, image1, new Vector2(5, 1), new Vector2(0, 0), 4);
			stereo1Animation.Scale = 0.8f;

			positionSteroe2 = new Vector2 (ScreenManager.Instance.dimensions.X/2 - 380, 300);
			stereo2Animation.LoadContent (content, image1, new Vector2(5, 1), new Vector2(0, 0), 4);
			stereo2Animation.Scale = 0.8f;
		}

		public override void UnloadContent()
		{
			floorAnimaition.UnloadContent ();
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
			floorAnimaition.Draw (spriteBatch, positionFloor);
			floorAnimaition.Draw (spriteBatch, positionFloor2);
			floorAnimaition.Draw (spriteBatch, positionFloor3);
			moveAnimation.Draw(spriteBatch,positionDj);
			stereo1Animation.Draw (spriteBatch, positionStereo1);
			stereo2Animation.Draw (spriteBatch, positionSteroe2);


			base.Draw (spriteBatch);
			foreach (Enemy enemy in enemies) {
				enemy.Draw (spriteBatch);
			}
			player.Draw (spriteBatch);
		}


	}
}

