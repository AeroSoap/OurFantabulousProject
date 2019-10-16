
    public void HealthUpdate()
    {
        
        //Adjusts the bar size based on the target objects health
        myRT.sizeDelta =  new Vector2(((float)Target.CurrentHealth / (float)Target.MaxHealth) * MaxSize, myRT.sizeDelta.y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myRT = GetComponent<RectTransform>();
    }


