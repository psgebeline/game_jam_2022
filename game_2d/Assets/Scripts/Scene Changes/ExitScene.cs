using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitScene : MonoBehaviour
{

public string sceneToEnter; //allows us to enter scene to travel into
public string exitName;

private void OnTriggerEnter(Collider other) //loads the above scene when player collides with door
{
    PlayerPrefs.SetString("Last Exit Name", exitName);
    SceneManager.LoadScene(sceneToEnter);
}


}

