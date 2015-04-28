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
		public bool draw { get; set; }
		public bool flippedHorizontally;

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

		public virtual void LoadContent(ContentManager Content, Texture2D image) {
			content = new ContentManager(Content.ServiceProvider, "Content");
			this.image = image;
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
			draw = true;
			text = "";
			flippedHorizontally = false;
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
			SpriteEffects effect;
			if (flippedHorizontally) {
				effect = SpriteEffects.FlipHorizontally;
			} else {
				effect = SpriteEffects.None;
			}
			if (draw) {
				if (image != null) {
					origin = new Vector2 (sourceRect.Width / 2, sourceRect.Height / 2);
					spriteBatch.Draw (image, position+origin, sourceRect, Color.White * alpha, rotation, origin, scale, effect, 0.0f);
				}
				if (text != String.Empty) {
					origin = new Vector2 (font.MeasureString (text).X / 2, font.MeasureString (text).Y / 2);
					spriteBatch.DrawString (font, text, position, color * alpha, rotation, origin, scale, effect, 0.0f);
				}
			}
		}

		public virtual void Draw(SpriteBatch spriteBatch, Vector2 position) {
			if (draw) {
				this.position = position;
			}
			Draw (spriteBatch);
		}
	}
}

