/* By: Bulat Sultanov
 * Date: 2017
 * Description: Script makes a paralaxing effect on specifically selected objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BackGround
{
    public Transform _backGround;
    public float _damping = 0.5f;
}

public class Paralax : MonoBehaviour {
    public enum Mode
    {
        Horizontal,
        Vertical,
        HorizontalAndVertical
    }
 
    public Mode parallaxMode;
    public List<BackGround> _backGrounds;

    private float[] scales;
    private Transform cam;
    private Vector3 previousCamPos;
    private Vector3 position;


}
