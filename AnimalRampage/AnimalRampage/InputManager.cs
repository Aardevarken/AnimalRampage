using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimalRampage
{
	public class InputManager
	{
		public KeyboardState prevKeyState { get; set; }
		public KeyboardState keyState { get; set; }

		public void Update()
		{
			prevKeyState = keyState;
			keyState = Keyboard.GetState ();
		}

		public bool KeyPressed(Keys key)
		{
			if (keyState.IsKeyDown (key) && prevKeyState.IsKeyUp (key))
				return true;
			return false;
		}

		public bool KeyPressed(params Keys[] keys)
		{
			foreach (Keys key in keys)
			{
				if (keyState.IsKeyDown (key) && prevKeyState.IsKeyUp (key))
					return true;
			}
			return false;
		}

		public bool KeyReleased(Keys key)
		{
			if (keyState.IsKeyUp (key) && prevKeyState.IsKeyDown (key))
				return true;
			return false;
		}

		public bool KeyReleased(params Keys[] keys)
		{
			foreach (Keys key in keys)
			{
				if (keyState.IsKeyUp (key) && prevKeyState.IsKeyDown (key))
					return true;
			}
			return false;
		}

		public bool KeyDown(Keys key)
		{
			if (keyState.IsKeyDown (key))
				return true;
			return false;
		}

		public bool KeyDown(params Keys[] keys)
		{
			foreach (Keys key in keys) {
				if (keyState.IsKeyDown (key))
					return true;
			}
			return false;
		}
	}
}

