using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private GameObject robotPrefab;
    [SerializeField] private float SpawnInterval = 3.5f;
    [SerializeField] private Form[] preferredRobot;

    [SerializeField] private int maxRobots = 6;
    [SerializeField] private int amountOfRobots = 0;

    [SerializeField] private float spawnDistanceX;
    [SerializeField] private float spawnDistanceY;

   
    void Start()
    {
        StartCoroutine(spawnEnemy(SpawnInterval, robotPrefab));
    }

    public void SpawnRobot(GameObject enemy, Form form)
    {
        if(amountOfRobots < maxRobots)
        {
        GameObject newEnemy =
           Instantiate(enemy, new Vector3
           (Random.Range(transform.position.x - spawnDistanceX, transform.position.x + spawnDistanceX) + 0.5f,
           Random.Range(transform.position.y - spawnDistanceY, transform.position.y + spawnDistanceY) + 0.5f, 0),
           Quaternion.identity);

            newEnemy.GetComponent<CharacterFormsController>().ChangeForm(preferredRobot[Random.Range(0, preferredRobot.Length)]);

            amountOfRobots++;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if (amountOfRobots < maxRobots)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy =
                Instantiate(enemy, new Vector3
                (Random.Range(transform.position.x - spawnDistanceX, transform.position.x + spawnDistanceX) + 0.5f,
                Random.Range(transform.position.y - spawnDistanceY, transform.position.y + spawnDistanceY) + 0.5f, 0),
                Quaternion.identity);

            //yield return new WaitForSeconds(0.01f);
            yield return new WaitForEndOfFrame();
            //repeat
            newEnemy.GetComponent<CharacterFormsController>().ChangeForm(preferredRobot[Random.Range(0, preferredRobot.Length)]);
            //Debug.Log(newEnemy.GetComponent<CharacterFormsController>());
            
            amountOfRobots++;

            StartCoroutine(spawnEnemy(interval, enemy));
            
        }
    }
    }
