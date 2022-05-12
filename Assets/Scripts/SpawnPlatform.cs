using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> _platforms = new List<GameObject>(); // lista dos prefabs das plataformas

    private List<Transform> _currPlatforms = new List<Transform>(); // lista das plataformas geradas na cena
    private float _offset;
    private Transform _player;
    private Transform _currentPlatformPoint;
    private int _platformIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < _platforms.Count; i++) {
            Transform p = Instantiate(_platforms[i], new Vector2(i * 30, 0), transform.rotation).transform;
            _currPlatforms.Add(p);
            _offset += 30f;
        }

        _currentPlatformPoint = _currPlatforms[_platformIndex].GetComponent<Platform>().finalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        float distance = _player.position.x - _currentPlatformPoint.position.x;

        if (distance >= 1) {
            Recycle(_currPlatforms[_platformIndex].gameObject);
            _platformIndex++;

            if (_platformIndex >= _currPlatforms.Count - 1) {
                _platformIndex = 0;
            }

            _currentPlatformPoint = _currPlatforms[_platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    public void Recycle(GameObject platform) {
        platform.transform.position = new Vector2(_offset, 0);
        _offset += 30f;
    }
}
