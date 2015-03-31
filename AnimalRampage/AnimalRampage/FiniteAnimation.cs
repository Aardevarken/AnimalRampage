using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AnimalRampage
{
	public class FiniteAnimation : SpriteSheetAnimation
	{
		private List<FiniteAnimationSubscriber> subscribers;

		public FiniteAnimation(ContentManager Content, Texture2D image, Vector2 startFrame, int length) {

		}

		public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 startFrame, int length) {
			base.LoadContent(Content, image, text, startFrame, length);
			subscribers = new List<FiniteAnimationSubscriber> ();
		}

		public void subscribe(FiniteAnimationSubscriber subscriber) {
			subscribers.Add (subscriber);
		}

		public void Start () {
			isPaused = false;
			currentFrame.X = start;
		}

		public override void Update (GameTime gametime) {
			IncrementFrame(gametime);
			if (currentFrame.X >= length) {
				foreach (FiniteAnimationSubscriber subscriber in subscribers) {
					subscriber.animationFinished ();
				}
				isPaused = true;
			}
		}
	}
}
