

	void Update ()
	{
		if (transform.position.y < -4) {
			player.OnDeath ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Darkness")) {
			player.OnDeath ();
		}
	}