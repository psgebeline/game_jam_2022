using UnityEngine;

public class FlyingOnion_BulletScript : MonoBehaviour
{
    public bool hasHit = false;
    public bool hasHasHit = false;

    private void Update()
    {
        if (hasHit && !hasHasHit)
        {
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity * 0.1f;
            hasHasHit = true;
        }
    }
}
