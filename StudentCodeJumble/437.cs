
	public static bool Intersect(Vector3[] points, int pointCount, Vector3 position)
	{
		Vector3 p1, p2;
		bool intersect = false;

		if(pointCount < 3)
		{
			return intersect;
		}

		Vector3 oldPoint = points[pointCount - 1];

		for(int i = 0; i < pointCount; i++)
		{
			Vector3 newPoint = points[i];

			if(newPoint.x > oldPoint.x)
			{
				p1 = oldPoint;
				p2 = newPoint;
			}
			else
			{
				p1 = newPoint;
				p2 = oldPoint;
			}

			if((newPoint.x < position.x) == (position.x <= oldPoint.x) &&
			   ((long)position.y - (long)p1.y) * (long)(p2.x - p1.x) <
				((long) p2.y - (long)p1.y) * (long)(position.x - p1.x))
			{
				intersect = !intersect;
			}

			oldPoint = newPoint;
		}

		return intersect;
	}


