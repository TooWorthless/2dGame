using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float distance;
    public int destroy;

    public LayerMask layerMask;
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        // rb.velocity = transform.right * speed;
        Invoke("DestroyTime", destroy);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D other = Physics2D.Raycast(transform.position, transform.up, distance, layerMask);
        if(other.collider != null) {
            if(other.collider.CompareTag("Enemy")) {
                // Debug.Log(other.collider.GetComponent());
                DestroyTime();
                other.collider.GetComponent<Enemy>().TakeDamage(10);
            }
        }
        transform.Translate( Vector2.up * speed * Time.deltaTime );
    }

    void DestroyTime() {
        Destroy(gameObject);
    }

    void onTrigerEnter2D(Collider2D hitInfo) {
        Destroy(gameObject);
    }
}
