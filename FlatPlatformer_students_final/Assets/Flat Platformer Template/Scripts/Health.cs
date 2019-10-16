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

    //call this to deal damage
    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        //check if death occuring
        if (CurrentHealth <= 0 && !DeathOccured)
        {
            CurrentHealth = 0;
            //run any effects and functions to happen when death occurs
            DeathFunctions.Invoke();
            DeathOccured = true;
            if (DestroyAtZero)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            //run any effects and functions to happen when damage occurs, not kept so it never happens at death
            DamageFunctions.Invoke();
        }
    }
    //call this to heal
    public void Heal(int health)
    {
        CurrentHealth += health;
        //check if too healthy
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        HealFunctions.Invoke();
    }





}
