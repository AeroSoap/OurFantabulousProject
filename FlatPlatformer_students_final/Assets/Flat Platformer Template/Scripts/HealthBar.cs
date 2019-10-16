/* By: Ryan Scheppler
 * Date: 10/11/19
 * Description: Add to healthbar and set target to make health
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health Target;

    public float MaxSize = 300;

    RectTransform myRT;

    public void HealthUpdate()
    {

        //Adjusts the bar size based on the target objects health
        myRT.sizeDelta = new Vector2(((float)Target.CurrentHealth / (float)Target.MaxHealth) * MaxSize, myRT.sizeDelta.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        myRT = GetComponent<RectTransform>();
    }

}
