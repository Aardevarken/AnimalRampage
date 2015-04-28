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
			if (entities.Count >= 2) {
				foreach (var entity1 in entities) {
					foreach (var entity2 in entities) {
						if (!entity1.isEqual (entity2)) {
							entity1.Collide (entity2);
						}
					}
				}
			}
		}

		public void Attach(Entity entity) {
			entities.Add (entity);
		}


	}
}

