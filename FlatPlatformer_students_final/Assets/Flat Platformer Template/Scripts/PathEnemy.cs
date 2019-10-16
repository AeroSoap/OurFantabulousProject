/* By: Ryan Scheppler
 * Date: 10/11/19
 * Description: Add to objects meant move in a pattern you set by the points given to it.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEnemy : MonoBehaviour
{
    //points are an offset from where the object starts so 0,0 is where it is in the editor
    public Vector3[] Points;

    public float Speed = 5;
    //value that we can be within to change to next destianation
    public float CloseEnough = 0.5f;

    private int currentDestination = 0;

    private Rigidbody2D myRB;

    public bool Active = true;



    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] += transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Points.Length > 0 && Active)
        {
            //find direction we are moving and how close we are
            Vector3 toDest = Points[currentDestination] - transform.position;

            if (toDest.magnitude <= CloseEnough)
            {
                currentDestination++;
                if (currentDestination >= Points.Length)
                {
                    currentDestination = 0;
                }
            }
            myRB.velocity = toDest.normalized * Speed;
            if (myRB.velocity.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    //can be used to enable movement if disabled
    public void EnablePath()
    {
        Active = true;
    }
    //can be used to prevent movement
    public void DisablePath()
    {
        print("disable fly");
        Active = false;
        print(Active);
    }




}
