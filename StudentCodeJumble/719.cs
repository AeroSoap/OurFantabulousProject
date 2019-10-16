

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //run any extra effects
            OnHit.Invoke();
            SceneManager.LoadScene(NextScene);
        }
    }



