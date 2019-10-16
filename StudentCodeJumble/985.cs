
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
        _cam = gameObject.GetComponent<Camera>();
    }

    public void FindPlayer()
    {
        lastX = Mathf.RoundToInt(_target.position.x);
        transform.position = new Vector3(_target.position.x + offset.x, _target.position.y + offset.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (_target)
        {
            int currentX = Mathf.RoundToInt(_target.position.x);
            if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
            lastX = Mathf.RoundToInt(_target.position.x);

            Vector3 target;
            if (faceLeft)
            {
                target = new Vector3(_target.position.x - offset.x, _target.position.y + offset.y+dynamicSpeed, transform.position.z);
            }
            else
            {
                target = new Vector3(_target.position.x + offset.x, _target.position.y + offset.y+dynamicSpeed, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

