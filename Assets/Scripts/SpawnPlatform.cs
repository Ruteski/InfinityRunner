using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> _platforms = new List<GameObject>();

    private float _offset;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _platforms.Count; i++) {
            Instantiate(_platforms[i], new Vector2(i * 30, 0), transform.rotation);
            _offset += 30f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Recycle(GameObject platform) {
        platform.transform.position = new Vector2(_offset, 0);
        _offset += 30f;
    }
}
