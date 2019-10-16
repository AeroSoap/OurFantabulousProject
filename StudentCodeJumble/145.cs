

		void Start ()
		{
			var renderer = GetComponent<Renderer> ();

			if (renderer) {
				var c = renderer.material.color;

				renderer.material.color = new Color (c.r, c.g, c.b, 0.9f);
			}
		}

		void LateUpdate ()
		{
			if (player) {
				_currentMovement = movementSpeed + ((player.position.x) * 0.008f);
			}
			
			if (player && player.transform.position.x > 10 && !canMove) {
				canMove = true;
			}
			
			if (canMove) {
				var pos = new Vector2 (_currentMovement * Time.deltaTime, 0f);
				transform.Translate (pos, Space.World);
			}
			
			if (!player && !_deathHappened) {
				OnDeath ();
			}
			
		}

				
		private void OnDeath ()
		{
			_deathHappened = true;
			gameOverHandler.OnGameOver ();
		}

