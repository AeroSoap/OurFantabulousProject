
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //run any extra effects
            OnHit.Invoke();
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        //pause for the delay
        yield return new WaitForSeconds(changeDelay);
        //finally change level
        SceneManager.LoadScene(NextScene);
    }


