using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class TitleScreen: GameScreen
	{
		SpriteFont font;

		public override void LoadContent(ContentManager Content, InputManager inputManager)
		{
			base.LoadContent (Content, inputManager);
			if (font == null)
				font = content.Load<SpriteFont> ("Font1");
		}

		public override void UnloadContent()
		{
			base.UnloadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update (gameTime);
			if (inputManager.KeyPressed(Keys.Z))
				ScreenManager.Instance.AddScreen (new PlayScreen (), inputManager);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString (font, "TitleScreen", new Vector2 (100, 100), Color.Black);
		}


	}
}

