using Microsoft.Xna.Framework;

namespace AnimalRampage
{
	public class LoopingAnimation : SpriteSheetAnimation
	{
		public void pause () {
			isPaused = true;
		}

		public void unpause () {
			isPaused = false;
		}

		public void jumpToFrame(int frame) {
			currentFrame = new Vector2(frame, currentFrame.Y);
		}

		public override void Update (GameTime gametime) {
			IncrementFrame(gametime);
		}
	}
}

