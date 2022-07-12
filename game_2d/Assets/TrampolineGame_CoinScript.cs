using UnityEngine;

public class TrampolineGame_CoinScript : MonoBehaviour
{
    [SerializeField] bool isMoving = false;
    [SerializeField] float moveSpeed = 15;

    private void Update()
    {
        if (isMoving)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, 0);

            //teleport coin to other side of the screen if it moves too far
            if (transform.position.x > 21.5f)
            {
                transform.position = new Vector3(transform.position.x - 22.5f, transform.position.y, 0);
            }
            else if (transform.position.x < -1)
            {
                transform.position = new Vector3(transform.position.x + 22.5f, transform.position.y, 0);
            }
        }
    }

    //destroy on collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
