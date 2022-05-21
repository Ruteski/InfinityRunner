using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform firePoint;

    public float throwTime;
    private float _throwCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _throwCount += Time.deltaTime;

        if (_throwCount >= throwTime) {
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            _throwCount = 0;
        }
    }
}
