using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace AnimalRampage
{
	public class Entity
	{
		protected int health;
		protected SpriteSheetAnimation moveAnimation;
		protected float moveSpeed;
		protected Vector2 position;
		protected Texture2D image;

		protected ContentManager content;

		public virtual void LoadContent(ContentManager content, InputManager inputManager)
		{
			this.content = new ContentManager (content.ServiceProvider, "Content");
		}

		public virtual void UnloadContent()
		{
			content.Unload ();
		}

		public virtual void Update(GameTime gameTime)
		{
		}
		public virtual void Update(GameTime gameTime, InputManager input)
		{
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
		}
	}
}

