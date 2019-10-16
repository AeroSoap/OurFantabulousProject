
    //function will change scene after a specified delay when run
    public void ChangeScene()
    {
        print("Started");
        StartCoroutine(DelayedChange());
    }

    IEnumerator DelayedChange()
    {
        print("before delay");
        
        yield return new WaitForSeconds(Delay);

        print("after");
        SceneManager.LoadScene(NextScene);
    }
    


