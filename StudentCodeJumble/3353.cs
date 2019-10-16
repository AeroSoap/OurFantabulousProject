
    public void OnDeath()
    {
        myAnimator.SetBool("Dead", true);
        //remove ablity to damage while dying
        Destroy(gameObject.GetComponent<DamageOnCollide>());
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {

        yield return new WaitForSeconds(DeathDelay);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }


