using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameManager.instance.ShowGameOver();
        }
    }
}
