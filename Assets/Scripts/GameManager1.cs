using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float heightvalue = 7;

    //public float enemySpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
    }

    public void GameOver()
    {
        CancelInvoke("SpawnEnemy");
    }

    public void SpawnEnemy()
    {
        //transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
        float randomYValue = Random.Range(-heightvalue, heightvalue); 
        Vector3 pos = new Vector3(8.5f, randomYValue, 0);
        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

        EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
        enemyScript.speed = Random.Range(-10, -8);

        Invoke("SpawnEnemy", Random.Range(0.05f, 0.1f));
        //transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
    }
}
