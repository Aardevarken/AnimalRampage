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

		public override void Update (GameTime gametime) {
			IncrementFrame(gametime);
		}
	}
}

