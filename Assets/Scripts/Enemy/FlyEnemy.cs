using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    private Rigidbody2D _rb;
    public float speed = 5f;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7f);
    }

    private void FixedUpdate() {
        _rb.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            player.OnHit(damage);
        }
    }
}
