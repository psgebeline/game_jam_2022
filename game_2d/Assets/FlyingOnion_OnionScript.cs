using UnityEngine;

public class FlyingOnion_OnionScript : MonoBehaviour
{
    [SerializeField] Transform onionTarget;
    float speed = 10;
    bool hasBeenHit = false;
    float randomOffset;

    private void Start()
    {
        randomOffset = Random.Range(0, 1f);
    }

    void Update()
    {
        transform.LookAt(onionTarget.position);
        if (onionTarget.position.x <= transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.x + 90);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.x + 270);
        }

        if (!hasBeenHit)
        {
            transform.position = Vector3.Lerp(transform.position, onionTarget.position, 0.02f);
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        float targetPositionX = Mathf.Sin(Time.time * (speed * 0.2f) + 0.2f + randomOffset) * 12 + 9.6f;
        float targetPositionY = Mathf.Sin(Time.time * speed + randomOffset) * 1.5f + 6.4f;
        onionTarget.transform.position = new Vector3(targetPositionX, targetPositionY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasBeenHit = true;
        collision.GetComponent<FlyingOnion_BulletScript>().hasHit = true;
    }
}
