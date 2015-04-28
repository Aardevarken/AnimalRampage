using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnimalRampage
{
	public abstract class SpriteSheetAnimation : Animation
	{
		private int frameCounter;
		protected int start;
		protected int length;
		private int switchFrame;

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

		public void LoadContent (ContentManager Content, Texture2D image, Vector2 sheetSize, Vector2 startFrame, int length)
		{
			base.LoadContent (Content, image);
			frameCounter = 0;
			switchFrame = 100;
			start = (int) startFrame.X;
			currentFrame = startFrame;
			this.length = length;
			frames = sheetSize;
			sourceRect = new Rectangle ((int)currentFrame.X * FrameWidth, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
		}

		public void IncrementFrame (GameTime gametime)
		{
			if (!isPaused) {
				frameCounter += (int)gametime.ElapsedGameTime.TotalMilliseconds;
				if (frameCounter >= switchFrame) {
					frameCounter = 0;
					currentFrame = new Vector2 (currentFrame.X + 1, currentFrame.Y);

					if (currentFrame.X * FrameWidth >= image.Width) {
						currentFrame = new Vector2 (start, currentFrame.Y);
					}
				}
			}
			sourceRect = new Rectangle ((int)currentFrame.X * FrameWidth, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
		}
	}
}

