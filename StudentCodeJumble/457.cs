

	// Use this for initialization
	void Start () {		
		if(Camera.main == null)
		{			
			Debug.Log("Found no Main Camera in the scene and added it automatically.");			
			GameObject.Instantiate(mainCameraPrefab);
		}

        collectables = FindAllCollectablesInScene ();

        foreach(var e in collectables)
        {
            e.CollectableCollected += OnCollectableCollected;
        }
	}

	private Collectable[] FindAllCollectablesInScene ()
	{
		return (Collectable[])GameObject.FindObjectsOfType (typeof(Collectable));
	}

	/// Is raised by the enemy when it's killed.
    void OnCollectableCollected(Collectable sender, CollectableEventArgs e)
	{	
		UpdateComboMultiplier(e);

        points += e.Points * comboMultiplier; //add the player points multiplied by the combo multiplier
        
        if(pointsText != null)
        {
            pointsText.text = string.Format("Points:{0}", points);
        }
		else
		{
			Debug.Log("No point text object is attached, can't set the text.");
		}

		lastTimeCollected = e.CollectedTime;
        sender.CollectableCollected -= OnCollectableCollected;
    }

	/// If the enemy is killed in combo time add a combo multiplier.
	/// The more enemies you kill in a combo the bigger the multiplier gets.
	void UpdateComboMultiplier(CollectableEventArgs e)
	{
		if (e.CollectedTime <= lastTimeCollected + comboTimerSeconds) {
			comboMultiplier++;
		}
		else {
			comboMultiplier = 1;
		}

		if(comboMultiplier > 1 && 
		   comboTextPrefab != null && 
		   HUD != null)
		{
			var comboText = GameObject.Instantiate(comboTextPrefab);
			comboText.GetComponent<ComboText>().SetMultiplier(comboMultiplier);
			comboText.transform.position = Camera.main.WorldToScreenPoint(e.Position);

			comboText.transform.SetParent(HUD.transform);
		}
	}

	// Update is called once per frame
	void Update () {
        
		bool levelFinished = LevelFinished();

		if(levelFinished)
        {
            levelDoneText.gameObject.SetActive(levelFinished);
        }
	
	}

	/// Returns true if the level is finished
	bool LevelFinished()
	{
		bool levelFinished = true;
		
		foreach(var e in collectables)
		{
			if(e != null)
			{
				levelFinished = false;
				break;
			}
		}

		return levelFinished;
	}

