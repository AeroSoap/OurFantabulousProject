/* By: Ryan Scheppler
 * Date: 10/9/19
 * Description: Add to objects meant to damage health.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DamageOnCollide : MonoBehaviour
{
    int DamageAmount = 10;

    bool DestroyOnCollide = false;
    //functions to run when damage is caused
    public UnityEvent DamageFunctions;
    //functions to run when object is set to destroy itself
    public UnityEvent DestroyFunctions;

    
}
