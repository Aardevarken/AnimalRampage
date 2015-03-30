using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnimalRampage
{
	public class SpriteSheetAnimation : Animation
	{
		int frameCounter;
		int switchFrame;

		public Vector2 frames { get; set; }
		public Vector2 currentFrame { get; set; }

		public int FrameWidth 
		{ 
			get { return image.Width / (int)frames.X; }
		}
		public int FrameHeight 
		{
			get { return image.Height / (int)frames.Y; }
		}

		public override void LoadContent (ContentManager Content, Texture2D image, string text, Vector2 position)
		{
			base.LoadContent (Content, image, text, position);
			frameCounter = 0;
			switchFrame = 100;
			frames = new Vector2 (4, 4);
			currentFrame = new Vector2 (0, 0);
			sourceRect = new Rectangle ((int)currentFrame.X * FrameWidth, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
		}

		public override void UnloadContent ()
		{
			base.UnloadContent ();
		}

		public override void Update (GameTime gametime)
		{
			if (isActive) 
			{
				frameCounter += (int)gametime.ElapsedGameTime.TotalMilliseconds;
				if (frameCounter >= switchFrame) 
				{
					frameCounter = 0;
					currentFrame = new Vector2(currentFrame.X + 1, currentFrame.Y);

					if (currentFrame.X * FrameWidth >= image.Width)
						currentFrame = new Vector2(0, currentFrame.Y);;
				}
			} 
			else 
			{
				frameCounter = 0;
				currentFrame = new Vector2 (1, currentFrame.Y);
			}
			sourceRect = new Rectangle ((int)currentFrame.X * FrameWidth, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
		}
	}
}

