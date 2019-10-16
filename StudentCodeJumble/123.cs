
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if(otherHealth != null)
        {
            otherHealth.Damage(DamageAmount);
            DamageFunctions.Invoke();
        }
        if(DestroyOnCollide)
        {
            DestroyFunctions.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.Damage(DamageAmount);
            DamageFunctions.Invoke();
        }
        if (DestroyOnCollide)
        {
            DestroyFunctions.Invoke();
            Destroy(gameObject);
        }
    }


