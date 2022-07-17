using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSc : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = (transform.right * speed);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        EnemySc enemy = hitInfo.GetComponent<EnemySc>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
        if(hitInfo.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }   

}
