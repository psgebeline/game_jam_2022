using UnityEngine;

public class TrampolineGame_CoinRotatorScript : MonoBehaviour
{
    float rotateSpeed = 135;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
