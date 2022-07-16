using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_camera_movement : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, -10); //sets camera to x position of target (the player) in every frame
    }
}
