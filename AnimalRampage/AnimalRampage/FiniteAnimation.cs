using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnimalRampage
{
	public class FiniteAnimation : SpriteSheetAnimation
	{
		private List<FiniteAnimationSubscriber> subscribers;
		int lastFrame;

		new public void LoadContent(ContentManager Content, Texture2D image, Vector2 sheetSize, Vector2 startFrame, int length) {
			base.LoadContent(Content, image, sheetSize, startFrame, length);
			subscribers = new List<FiniteAnimationSubscriber> ();
			isPaused = true;
			draw = false;
			lastFrame = 0;
		}

		public void subscribe(FiniteAnimationSubscriber subscriber) {
			subscribers.Add (subscriber);
		}

		public void Start () {
			isPaused = false;
			draw = true;
		}

		public override void Update (GameTime gametime) {
			IncrementFrame(gametime);
			if (currentFrame.X < lastFrame) {
				foreach (FiniteAnimationSubscriber subscriber in subscribers) {
					subscriber.animationFinished ();
				}
				isPaused = true;
				draw = false;
			}
			lastFrame = (int) currentFrame.X;
		}
	}
}
