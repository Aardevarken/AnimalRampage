using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class ScreenManager
	{
		Dictionary<string, GameScreen> screens = new Dictionary<string, GameScreen>();
		Stack<GameScreen> screenStack = new Stack<GameScreen>();
		public Vector2 dimensions { get; set; }
		private static ScreenManager instance;
		GameScreen currentScreen, newScreen;
		ContentManager content;
		bool transition;
		FadeAnimation fade;
		Texture2D fadeTexture;

	
		// this is a singleton
		public static ScreenManager Instance {
			get {
				if (instance == null) 
					instance = new ScreenManager ();
				return instance;
			}
		}

		public void AddScreen(GameScreen screen)
		{
			newScreen = screen;
			transition = true;
			fade.isActive = true;
			fade.Alpha = 0.0f;
			fade.activateValue = 1.0f;
		}

		public void Initialize() 
		{
			currentScreen = new SplashScreen ();
			fade = new FadeAnimation ();
		}
		public void LoadContent(ContentManager Content) 
		{
			content = new ContentManager (Content.ServiceProvider, "Content");
			currentScreen.LoadContent (Content);

			fadeTexture = content.Load<Texture2D> ("fade");
			fade.LoadContent (content, fadeTexture, "", Vector2.Zero);
			fade.Scale = dimensions.X;
		}
		public void Update (GameTime gameTime) 
		{ 
			if (!transition)
				currentScreen.Update (gameTime);
			else
				Transition (gameTime);
		}

		public void Draw(SpriteBatch spriteBatch) 
		{ 
			currentScreen.Draw (spriteBatch);
			if (transition)
				fade.Draw (spriteBatch);
		}


		private void Transition(GameTime gameTime)
		{
			fade.Update (gameTime);
			if (fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f) {
				screenStack.Push (newScreen);
				currentScreen.UnloadContent ();
				currentScreen = newScreen;
				currentScreen.LoadContent (content);
			} else if (fade.Alpha == 0.0f) {
				transition = false;
				fade.isActive = false;
			}
		}

	}
}

