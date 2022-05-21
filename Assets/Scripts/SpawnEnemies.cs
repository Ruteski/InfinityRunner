using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();

    private float timeCount;
    public float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= spawnTimer) {
            SpawnEnemy();   
            timeCount = 0f;
        }
    }

    private void SpawnEnemy() {
        int inimigo = Random.Range(0, enemiesList.Count) ;
        print(inimigo);


        Vector3 position = new Vector3(transform.position.x, Random.Range(0,4f), 0f);
        Instantiate(enemiesList[inimigo], position, transform.rotation);
    }
}
