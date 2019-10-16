

	void OnEnable()
	{		
		isPainting = false;
		lineRenderer = GetComponent<LineRenderer>();
		
		pointCount = 0;
		points = new Vector3[maxPaintablePoints];
	}

	/// <summary>
	/// Update the painter
	/// </summary>
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{			
			if(!isPainting)
			{
				InitPaintMode();
			}
		}

		if(Input.GetMouseButtonUp(0))
		{			
			ClosePolygon();

			if(pointCount >= 3)
			{
				if(PolygonPainted != null)
				{
					PolygonPainted(new PolygonPainterEventArgs(points, pointCount));
				}
			}

			Reset();
		}

		if(CanPaint())
		{
			Paint();
		}
	}

	/// <summary>
	/// Reset all parameters.
	/// </summary>
	void Reset()
	{
		pointCount = 0;	
		lineRenderer.SetVertexCount(pointCount);
		isPainting = false;
	}

	/// <summary>
	/// check if the max point count is reached.
	/// </summary>
	/// <returns><c>true</c> if this instance can paint; otherwise, <c>false</c>.</returns>
	bool CanPaint()
	{
		return pointCount < maxPaintablePoints;
	}

	/// <summary>
	/// Initialize the paint mode
	/// </summary>
	void InitPaintMode ()
	{
		pointCount = 1;
		points[pointCount - 1] = Get2DMousePosition();
		lineRenderer.SetVertexCount(pointCount);
		lineRenderer.SetPosition(0, Get2DMousePosition());

		lastPointPosition = Get2DMousePosition();
		isPainting = true;
	}

	/// <summary>
	/// Add new points to the line
	/// </summary>
	void Paint ()
	{
		if(!isPainting)
		{
			return;
		}

		if (Vector2.Distance(Get2DMousePosition(), lastPointPosition) >= dotDistance) 
		{
			pointCount++;
			points[pointCount - 1] = Get2DMousePosition();
			lineRenderer.SetVertexCount(pointCount);
			lineRenderer.SetPosition(pointCount - 1, Get2DMousePosition());

			lastPointPosition = Get2DMousePosition();
		}
	}

	/// <summary>
	/// Closes the polygon.
	/// </summary>
	void ClosePolygon()
	{
		if(pointCount >= 2)
		{
			pointCount++;
			points[pointCount - 1] = Get2DMousePosition();
			lineRenderer.SetVertexCount(pointCount);
			lineRenderer.SetPosition(pointCount - 1, points[0]);

			lastPointPosition = Get2DMousePosition();
		}
	}

	/// <summary>
	/// Get the 2D position of the mouse or touch
	/// </summary>
	/// <returns>The D mouse position.</returns>
	Vector3 Get2DMousePosition()
	{
		var result = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		result.z = 0f;
		return result;
	}

