using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeSceneWithButton : MonoBehaviour
{
    //just allows you to attach the script to a button with the OnClick method using TextMeshPro and then you input the scene name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
