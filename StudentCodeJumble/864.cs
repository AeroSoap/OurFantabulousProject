

		void Awake ()
		{
			SetGameObjectVisibility (controls, true);
			SetGameObjectVisibility (gameOverUI, false);
		}

		void Update ()
		{
			if (_gameOver && Input.anyKeyDown) {
				SceneManager.LoadScene ("Game_Horizontal");
			}
		}

		/// Raised on game over. Shows game over ui and saves high score.
		public void OnGameOver ()
		{
			_gameOver = true;
			uiFlash.GameOverUIFlash ();

			if (DataPersistence.instance)
				DataPersistence.instance.Save (score.currentScore);

			SetGameObjectVisibility (gameOverUI, true);
			SetGameObjectVisibility (controls, false);
		}

		private void SetGameObjectVisibility (GameObject[] objs, bool visibility)
		{
			foreach (var g in objs) {
				g.SetActive (visibility);
			}
		}

	}
