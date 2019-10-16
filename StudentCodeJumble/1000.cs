

	public Vector3[] Points {
		get {
			return points;
		}
	}

	private int pointCount;

	public int PointCount {
		get {
			return pointCount;
		}
	}

	public PolygonPainterEventArgs(Vector3[] points, int pointCount)
	{
		this.points = points;
		this.pointCount = pointCount;
	}

