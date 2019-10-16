private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Health -= DamageAmount;
            
        }
        if (DestroyOnCollide)
        {
           
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Health -= DamageAmount;

        }
        if (DestroyOnCollide)
        {

            Destroy(gameObject);
        }
    }