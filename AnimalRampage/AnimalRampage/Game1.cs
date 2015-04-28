#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace AnimalRampage
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		float R = .5f;
		float G = .2f;
		float B = .9f;
		float ramount = .005f;
		float gamount = -.008f;
		float bamount = -.009f;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;		
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			ScreenManager.Instance.Initialize ();

			ScreenManager.Instance.dimensions = new Vector2 (800, 600);
			graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.dimensions.X;
			graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.dimensions.Y;
			graphics.ApplyChanges ();

			base.Initialize ();
				
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			ScreenManager.Instance.LoadContent (Content);
		}

		protected override void UnloadContent()
		{
			// TODO: unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif
			// TODO: Add your update logic here		
			ScreenManager.Instance.Update (gameTime);	
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{

			//graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
			if (R >= 1 || R <= 0)
				ramount = -ramount;
			if (G >= 1 || G <= 0)
				gamount = -gamount;
			if (B >= 1 || B<= 0)
				bamount = -bamount;
			R += ramount;
			G += gamount;
			B += bamount;

			graphics.GraphicsDevice.Clear (new Color (R, G, B));
		
			//TODO: Add your drawing code here
			spriteBatch.Begin ();
			ScreenManager.Instance.Draw (spriteBatch);
			spriteBatch.End ();
			base.Draw (gameTime);

		}
	}
}

