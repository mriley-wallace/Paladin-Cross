using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float xPos;
    public float yPos;
    public float zPos;
    public int enemyCount;
    public int enemyMax;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < enemyMax)
        {
            xPos = Random.Range(20, 177);
            yPos = 165;
            zPos = Random.Range(15, 189);
            Instantiate(enemyToSpawn, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            enemyCount += 1;
            Debug.Log("Spawn Complete");
        }
    }
}
