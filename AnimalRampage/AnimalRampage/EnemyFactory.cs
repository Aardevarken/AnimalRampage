using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public static class EnemyFactory
	{
		public static Enemy getInstance(string type, ContentManager content, InputManager inputManager) {
			Enemy enemy;
			if (type.Equals ("spin")) {
				enemy = new EnemyTurtle ();
			} else { // "wiggle"
				enemy = new EnemyTurtle ();
			}
			int width = (int) ScreenManager.Instance.dimensions.X;
			Random random = new Random();
			enemy.LoadContent (content, inputManager, new Vector2(random.Next(width),0));
			return enemy;
		}
	}
}

