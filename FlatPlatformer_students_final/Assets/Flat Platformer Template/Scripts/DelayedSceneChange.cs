/* By: Ryan Scheppler
* Date: 10/9/19
* Description: Add this to objects you need a scene changing function for with a delay
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedSceneChange : MonoBehaviour
{
    public float Delay = 0.0f;
    //name of level to load
    public string NextScene = "GameOver";


    //function will change scene after a specified delay when run
    public void ChangeScene()
    {
        print("Started");
        StartCoroutine(DelayedChange());
    }

    IEnumerator DelayedChange()
    {
        print("before delay");

        yield return new WaitForSeconds(Delay);

        print("after");
        SceneManager.LoadScene(NextScene);
    }





}
