

	// Use this for initialization
	void Start () {	
		StartCoroutine(DestroyMe());	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 0.8f);
	}

	public void SetMultiplier(int m)
	{
		GetComponent<Text>().text = "Combo x " + m.ToString();
	}

	IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds(1f);

		GameObject.Destroy(gameObject);
	}

