using UnityEngine;

public class FlyingOnionScript : MonoBehaviour
{
    float speed = 10;
    [SerializeField] Transform cannonAnchor;
    [SerializeField] Transform cannonHole;
    [SerializeField] GameObject bullet;
    float shootFrequency = 2;
    float timer = 2;

    void Update()
    {
        //set move direction of target
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        Vector3.Normalize(direction);

        //move target
        transform.position += direction * speed * Time.deltaTime;

        //restrict target to within game view
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }
        if (transform.position.x > 19.2f)
        {
            transform.position = new Vector3(19.2f, transform.position.y, 0);
        }
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        if (transform.position.y > 10.8f)
        {
            transform.position = new Vector3(transform.position.x, 10.8f, 0);
        }

        //make cannon look at target
        cannonAnchor.LookAt(transform.position);
        if (transform.position.x <= 9.6f)
        {
            cannonAnchor.eulerAngles = new Vector3(0, 0, cannonAnchor.eulerAngles.x + 90);
        }
        else
        {
            cannonAnchor.eulerAngles = new Vector3(0, 0, -cannonAnchor.eulerAngles.x + 270);
        }

        //spawn bullet from hole every x seconds
        if (!bullet.GetComponent<FlyingOnion_BulletScript>().hasHit)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                bullet.transform.position = cannonHole.position;
                bullet.transform.rotation = cannonHole.rotation;
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 25, ForceMode2D.Impulse);
                timer = shootFrequency;
            }
        }
    }
}
