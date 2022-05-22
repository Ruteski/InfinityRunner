using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    public virtual void ApplyDamage(int dano) {
        health -= dano;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet")) {
            ApplyDamage(collision.GetComponent<Projectile>().damage);
        }
    }
}
