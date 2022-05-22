using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 15f;
    public int damage = 1;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rb.velocity = Vector2.right * speed;
        Destroy(_rb, 5f);
    }

    public void OnHit() {
        GameObject e = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 0.3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 6) {
            OnHit();
        }
    }
}
