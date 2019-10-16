/* By: Ryan Scheppler
 * Date: 10/9/19
 * Description: Add to objects meant to have a health.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    public bool DestroyAtZero = true;

    public UnityEvent DamageFunctions;
    public UnityEvent DeathFunctions;
    public UnityEvent HealFunctions;
    private bool DeathOccured = false;
    
}
