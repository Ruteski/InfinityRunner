using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private Animator _anim;

    public int health = 10;

    private Rigidbody2D _rb;
    private bool _isJumping = false;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping) {
            OnJump();
        }
    }

    public void OnShoot() {
        var e = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(e, 3f);
    }

    public void OnJump() {
        _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _anim.SetBool("Jumping", true);
        _isJumping = true;
    }

    public void OnHit(int dmg) {
        health -= dmg;

        if (health <= 0) {
            GameManager.instance.ShowGameOver();
        }
    }

    private void FixedUpdate() {
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {//ground
            _isJumping = false;
            _anim.SetBool("Jumping", false);
        }
    }
}
