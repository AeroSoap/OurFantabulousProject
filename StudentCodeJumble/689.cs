	void Awake ()
    {
        // Setting up the reference.
        bombHUD = GameObject.Find("ui_bombHUD").guiTexture;
    }


    void Update ()
    {
        // If the bomb laying button is pressed, the bomb hasn't been laid and there's a bomb to lay...
        if(Input.GetButtonDown(bombButton) && bombCount > 0)
        {
            // Decrement the number of bombs.
            bombCount--;

            // Play the bomb laying sound.
            AudioSource.PlayClipAtPoint(bombsAway,transform.position);

            // Instantiate the bomb prefab.
            Instantiate(bomb, transform.position, transform.rotation);
        }

        // The bomb heads up display should be enabled if the player has bombs, other it should be disabled.
        bombHUD.enabled = bombCount > 0;
    }