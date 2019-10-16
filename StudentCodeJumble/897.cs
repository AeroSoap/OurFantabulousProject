	void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    private void Update()
    {
        targetPosition = (player.transform.position + (player.transform.forward * followAhead)) + cameraOffset;
        targetPosition.y = Mathf.Min(targetPosition.y, m_minY);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }