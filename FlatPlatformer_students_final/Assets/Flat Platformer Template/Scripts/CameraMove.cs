/* By: Bulat Sultanov
 * Date: 2017
 * Description: Script finds the player and follows it meant for the main camera.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float damping = 1.5f;
    public Transform _target;
    public Vector2 offset = new Vector2(2f, 1f);

    private bool faceLeft;
    private int lastX;
    private float dynamicSpeed = 0;
    private Camera _cam;

    
}
