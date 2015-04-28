using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AnimalRampage
{
	public class CollisionDetector
	{
		List<Entity> entities;
		CollisionDetector instance;
		private CollisionDetector ()
		{
			entities = new List<Entity> ();
		}

		public static CollisionDetector getInstance(){
			if (instance == null) {
				instance = new CollisionDetector();
			} else {
				return instance;
			}
		}

		public void Update(){

	}
}

