using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnimalRampage {
	public abstract class Animation {
		protected Texture2D image;
		protected string text;
		protected SpriteFont font;
		protected Color color;
		protected Rectangle sourceRect;
		protected float rotation, scale, axis, alpha;
		protected Vector2 origin, position;
		protected ContentManager content;
		public bool isActive { get; set; }
		public bool isPaused { get; set; }

		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}

		public virtual float Alpha {
			get { return alpha; }
			set { alpha = value; }
		}

		public float Scale {
			set { scale = value; }
		}

		public virtual void LoadContent(ContentManager Content, Texture2D image, string text) {
			content = new ContentManager(Content.ServiceProvider, "Content");
			this.image = image;
			this.text = text;
			if (text != String.Empty) {
				font = content.Load<SpriteFont> ("Font1");
				color = new Color (114, 77, 255);
			}
			if (image != null)
				sourceRect = new Rectangle (0, 0, image.Width, image.Height);
			rotation = axis = 0.0f;
			scale = alpha = 1.0f;
			isActive = true;
			isPaused = false;
		}

		public virtual void UnloadContent()
		{
			content.Unload ();
			text = String.Empty;
			position = Vector2.Zero;
			sourceRect = Rectangle.Empty;
			image = null;
		}

		public abstract void Update(GameTime gametime);

		public virtual void Draw(SpriteBatch spriteBatch) {
			if (image != null) {
				origin = new Vector2 (sourceRect.Width / 2, sourceRect.Height / 2);
				spriteBatch.Draw (image, position + origin, sourceRect, Color.White * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
			}
			if (text != String.Empty) 
			{
				origin = new Vector2 (font.MeasureString (text).X / 2, font.MeasureString (text).Y / 2);
				spriteBatch.DrawString (font, text, position + origin, color * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
			}
		}

		public virtual void Draw(SpriteBatch spriteBatch, Vector2 position) {
			this.position = position;
			Draw (spriteBatch);
		}
	}
}

