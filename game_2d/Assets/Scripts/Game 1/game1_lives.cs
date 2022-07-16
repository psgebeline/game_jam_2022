using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game1_lives : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x - 10, transform.position.y, transform.position.z); //sets sprite 10 units to left of camera in every frame
    }
}
