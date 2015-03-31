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
		InputManager inputManager;

	
		// this is a singleton
		public static ScreenManager Instance {
			get {
				if (instance == null) 
					instance = new ScreenManager ();
				return instance;
			}
		}

		public void AddScreen(GameScreen screen, InputManager inputmanager)
		{
			newScreen = screen;
			transition = true;
			fade.isActive = true;
			fade.Alpha = 0.0f;
			fade.activateValue = 1.0f;
			this.inputManager = inputmanager;
		}

		public void Initialize() 
		{
//			currentScreen = new SplashScreen ();
			// dev mode engage
			currentScreen = new PlayScreen ();
			fade = new FadeAnimation ();
		}
		public void LoadContent(ContentManager Content) 
		{
			content = new ContentManager (Content.ServiceProvider, "Content");
			inputManager = new InputManager ();
			currentScreen.LoadContent (Content, inputManager);

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
				currentScreen.LoadContent (content, inputManager);
			} else if (fade.Alpha == 0.0f) {
				transition = false;
				fade.isActive = false;
			}
		}

	}
}

