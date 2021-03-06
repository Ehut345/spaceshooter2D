using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y = -4.3f, max_Y = 4.3f;
    public GameObject[] asteroid_Prefab;
    public GameObject enemy_Prefab;

    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawEnemies", timer);
    }
    void spawEnemies()
    {
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;
        if(Random.Range(0,2)>0)
        {
            Instantiate(asteroid_Prefab[Random.Range(0, asteroid_Prefab.Length)],temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy_Prefab, temp, Quaternion.Euler(0f, 0f, 90f));
        }
        Invoke("spawEnemies", timer);
    }
}
