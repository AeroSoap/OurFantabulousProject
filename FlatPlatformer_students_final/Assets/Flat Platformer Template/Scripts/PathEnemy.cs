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

    

}
