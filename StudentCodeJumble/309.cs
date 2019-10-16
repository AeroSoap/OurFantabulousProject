
		void Start ()
		{
			_audio = GetComponent<AudioSource> ();
			_rigidbody = GetComponent<Rigidbody2D> ();
		}

		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
				MoveLeft ();
			}

			if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) {
				StopMovingLeft ();
			}

			if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				MoveRight ();
			}

			if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
				StopMovingRight ();
			}

			if (Input.GetButtonDown ("Jump")) {
				Jump ();
			}

			int currentScore = (int)Mathf.Floor (transform.position.x) - 7;

			if (currentScore >= 0 && currentScore > score.currentScore) { 
				score.SetScore (currentScore);
				
			}


		}
	
		void FixedUpdate ()
		{	
			var hit = Physics2D.Linecast (transform.position, groundCheck.position, groundMask);

			_isGrounded = hit.collider != null || _rigidbody.velocity.y == 0;

			if (_isGrounded && hit.collider != null && hit.collider != _previousCollision) {
				var platform = hit.collider.gameObject.GetComponent<Platform> ();

				if (platform) {
					platform.playerTouched = true;
				}
				_previousCollision = hit.collider;
			}


			if (_moveLeft) {
				_move = -1f;
			} else if (_moveRight) {
				_move = 1f;
			}

			if (!_isGameOver && (_moveLeft || _moveRight)) {
				_rigidbody.velocity = new Vector2 (_move * maxSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);

			} 

					

			if (_isGrounded && !_groundedLastUpdate) {
				landParticle.Emit (50);

			}

			_groundedLastUpdate = _isGrounded;

			if (walkClips.Length > 0 && _isGrounded && (_moveLeft || _moveRight)) {
				_audio.PlayOneShot (walkClips [Random.Range (0, walkClips.Length)]);
			}

		}

		/// <summary>
		/// Move character left in next call to FixedUpdate. Called on button down.
		/// </summary>
		public void MoveLeft ()
		{
			_moveLeft = true;
		}

		/// <summary>
		/// Stop moving the character left. Called on button up.
		/// </summary>
		public void StopMovingLeft ()
		{
			_moveLeft = false;
			_rigidbody.velocity = new Vector2 (0, _rigidbody.velocity.y);
		}

		/// <summary>
		/// Move character right in next call to FixedUpdate. Called on button down.
		/// </summary>
		public void MoveRight ()
		{
			_moveRight = true;
		}

		/// <summary>
		/// Stop moving the character left. Called on button up.
		/// </summary>
		public void StopMovingRight ()
		{
			_moveRight = false;
			_rigidbody.velocity = new Vector2 (0, _rigidbody.velocity.y);
		}

		/// <summary>
		/// Makes the character jump (if on ground) or double jump (if already in the air and has not already double jumped).
		/// </summary>
		public void Jump ()
		{


			if (_isGrounded && !_isGameOver) {
				_rigidbody.AddForce (new Vector2 (0, jumpForce));
				_canDoubleJump = true;
				
				if (jumpClips.Length > 0)
					_audio.PlayOneShot (jumpClips [Random.Range (0, jumpClips.Length)]);

				StartCoroutine (JumpAnimation ());
			} else if (_canDoubleJump && !_isGameOver) {
				_rigidbody.velocity = new Vector2 (_rigidbody.velocity.x, 0);
				_rigidbody.AddForce (new Vector2 (0, jumpForce));
				_canDoubleJump = false;
				
				if (jumpClips.Length > 0)
					_audio.PlayOneShot (jumpClips [Random.Range (0, jumpClips.Length)]);

				StartCoroutine (JumpAnimation ());
			}
		}

		/// <summary>
		/// Called on death event. Plays <see cref="InfiniteJumper.Player.audioOnDeath"/>, disables player sprite and enables on death particles.
		/// Destroys object after a set amount of time.
		/// </summary>
		public void OnDeath ()
		{
			if (audioOnDeath.Length > 0)
				_audio.PlayOneShot (audioOnDeath [Random.Range (0, audioOnDeath.Length)]);

			playerSpriteContainer.SetActive (false);
			explosionParticleContainer.SetActive (true);
					
			StartCoroutine (Destroy ());
		}


		private IEnumerator Destroy ()
		{
			yield return new WaitForSeconds (0.3f);
			Destroy (gameObject);
		}

		private IEnumerator JumpAnimation ()
		{
			transform.localScale = jumpingScale;

			yield return new WaitForSeconds (0.2f);

			transform.localScale = groundScale;

		}
	}

