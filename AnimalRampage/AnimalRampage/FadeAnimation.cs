using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnimalRampage
{
	public class FadeAnimation : Animation
	{
		bool increase; 
		public float fadeSpeed { get; set; }
		TimeSpan defaultTime;
		TimeSpan timer; 
		bool stopUpdating;
		public float activateValue { get; set; }
		float defaultAlpha;

		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}

		public override float Alpha {
			get {
				return alpha;
			}
			set {
				alpha = value;
				if (alpha == 1.0f)
					increase = false;
				else if (alpha == 0.0f)
					increase = true;
			}
		}

		public TimeSpan Timer
		{ 
			get { return timer; }
			set { defaultTime = value; timer = defaultTime; } 
		}

		public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
		{
			base.LoadContent (Content, image, text, position);
			increase = false;
			fadeSpeed = 1.0f;
			defaultTime = new TimeSpan (0, 0, 1);
			timer = defaultTime;
			activateValue = 0.0f;
			stopUpdating = false;
			defaultAlpha = alpha;
			this.position = position;
		}

		public override void Update (GameTime gametime)
		{
			if (isActive) {
				if (!stopUpdating) {
					if (!increase)
						alpha -= fadeSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
					else
						alpha += fadeSpeed * (float)gametime.ElapsedGameTime.TotalSeconds;
					if (alpha <= 0.0f)
						alpha = 0.0f;
					else if (alpha >= 1.0f) {
						alpha = 1.0f;
						increase = false;
					}
				}

				if (alpha == activateValue) {
					stopUpdating = true;
					timer -= gametime.ElapsedGameTime;
					if (timer.TotalSeconds <= 0) {
//						increase = !increase;
						timer = defaultTime;
						stopUpdating = false;
					}
				}
			} 
			else 
			{
				alpha = defaultAlpha;
			}

		}
	}
}

