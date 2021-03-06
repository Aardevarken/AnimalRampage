﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace AnimalRampage
{
	public class Entity
	{
		protected int invisibleFloor = (int)ScreenManager.Instance.dimensions.Y - 20;
		protected int health;
		protected SpriteSheetAnimation moveAnimation;
		protected float terminalVelocity, jumpSpeed, fallSpeed, horizontalSpeed;
		public Vector2 position;
		protected Texture2D image;
		protected Vector2 velocity;
		protected Rectangle box;
		public bool dying = false;
		public bool dead = false;

		protected ContentManager content;

		public virtual void LoadContent(ContentManager content, InputManager inputManager)
		{
			this.content = new ContentManager (content.ServiceProvider, "Content");
			velocity = Vector2.Zero;
			terminalVelocity = 20;
			jumpSpeed = -15;
			fallSpeed = 0.5f;
			horizontalSpeed = 5;
			dead = false;
			CollisionDetector.getInstance ().Attach (this);
		}

		public virtual void UnloadContent()
		{
			content.Unload ();
		}

		public virtual void Kill() {
			dying = true;
			CollisionDetector.getInstance ().Detach (this);
		}

		public virtual void Update(GameTime gameTime)
		{
			position += velocity;
			if (isOnGround()) {
				velocity.Y = 0;
			}
			else {
				if (velocity.Y < terminalVelocity)
					velocity.Y += fallSpeed;
			}
			box = new Rectangle ((int)position.X, (int)position.Y, box.Width, box.Height);
		}

		public virtual void Update(GameTime gameTime, InputManager input)
		{
			Update (gameTime);
			CollisionDetector.getInstance ().Update();
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
		}

		protected bool isOnGround() {
			box = new Rectangle ((int)position.X, (int)position.Y, box.Width, box.Height);
			// TODO: add implementation with proper collision detection here
			if (box.Bottom <= invisibleFloor) // just checks if above invisible floor for now
				return false;
			else
				return true;
		}

		protected void Jump()
		{
			if (isOnGround()) {
				velocity.Y = jumpSpeed;
			}
		}

		public Rectangle getBox() {
			return box;
		}

		public virtual void Collide (Entity entity) {
		}

	}
}

