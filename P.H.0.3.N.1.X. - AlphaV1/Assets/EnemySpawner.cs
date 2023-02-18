using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject robotPrefab;
    [SerializeField] private float spawnInterval = 3.5f;

    [SerializeField] private float spawnDistanceX;
    [SerializeField] private float spawnDistanceY;

    [SerializeField] private Form[] requiredRobotsForms;
    [SerializeField] private int[] requiredRobotAmounts;
    [SerializeField] private List<GameObject> userSpawnedRobots = new List<GameObject>();

    private Dictionary<Form, int> requiredRobots = new Dictionary<Form, int>();
    private Dictionary<Form, int> currentRobots = new Dictionary<Form, int>();

   
    private void Start()
    {
        //StartCoroutine(spawnEnemy(SpawnInterval, robotPrefab));
        LoadRequiredRobots();
        //print("----------");
        LoadUserSpawnedRobots();
        //print("----------");
        InvokeRepeating("SpawnRobotsIfNeeded", 0.0f, spawnInterval);
    }

    /// <summary>
    /// Added as a listening to robots death event
    /// </summary>
    /// <param name="form"></param>
    /// <param name="amount"></param>
    public void UpdateCurrentRobotsList(Form form, int amount)
    {
        //print("robot list updated");
        currentRobots[form] += amount;
    }

    /// <summary>
    /// Spawns robots.  Waits for end of frame to avoid the form glitch.
    /// </summary>
    /// <param name="robotsToSpawn"></param>
    /// <returns></returns>
    private IEnumerator SpawnRobots(Dictionary<Form, int> robotsToSpawn)
    {
        foreach (KeyValuePair<Form, int> value in robotsToSpawn)
        {
            int amountToSpawn = value.Value;
            while (amountToSpawn > 0)
            {
                GameObject newEnemy = Instantiate(
                    robotPrefab,
                    new Vector3(
                        Random.Range(transform.position.x - spawnDistanceX, transform.position.x + spawnDistanceX) + 0.5f,
                        Random.Range(transform.position.y - spawnDistanceY, transform.position.y + spawnDistanceY) + 0.5f,
                        0
                    ),
                    Quaternion.identity
                );

                yield return new WaitForEndOfFrame();

                newEnemy.GetComponent<CharacterFormsController>().ChangeForm(value.Key);
                newEnemy.GetComponent<EnemyObject>().deathEvent.AddListener(UpdateCurrentRobotsList);

                amountToSpawn--;

                if (currentRobots.ContainsKey(value.Key))
                {
                    currentRobots[value.Key] += 1;
                }
                else
                {
                    currentRobots.Add(value.Key, 1);
                }
                //print(string.Format("Spawned {0} {1} robots", value.Value, value.Key));
            }
        }
    }

    /// <summary>
    /// Sets up dictionary from user settings
    /// </summary>
    private void LoadRequiredRobots()
    {
        for (int i = 0; i < requiredRobotsForms.Length; i++)
        {
            requiredRobots.Add(requiredRobotsForms[i], requiredRobotAmounts[i]);
        }

        //print("Loaded required robots dictionary");
        //foreach(KeyValuePair<Form, int> value in requiredRobots)
        //{
        //    print(string.Format("Requires {0} {1} robot", value.Value, value.Key));
        //}
    }

    /// <summary>
    /// Puts any robots user had placed and assigned to this spawner into the currentRobots dictionary
    /// </summary>
    private void LoadUserSpawnedRobots()
    {
        foreach(GameObject robot in userSpawnedRobots)
        {
            Form robotForm = robot.GetComponent<CharacterFormsController>().currForm;

            if (currentRobots.ContainsKey(robotForm))
            {
                currentRobots[robotForm] += 1;
            }
            else
            {
                currentRobots.Add(robotForm, 1);
            }

            robot.GetComponent<EnemyObject>().deathEvent.AddListener(UpdateCurrentRobotsList);
        }

        //print("Loaded user spawned robots");
        //foreach (KeyValuePair<Form, int> value in currentRobots)
        //{
        //    print(string.Format("Found {0} {1} robots", value.Value, value.Key));
        //}
    }

    /// <summary>
    /// Compares requiredRobots dict to the currentRobots dict, and call the SpawnRobots coroutine.
    /// </summary>
    private void SpawnRobotsIfNeeded()
    {
        Dictionary<Form, int> tempDict = new Dictionary<Form, int>();

        foreach (KeyValuePair<Form, int> value in currentRobots)
        {
            int missingAmount = Mathf.Clamp(requiredRobots[value.Key] - value.Value, 0, int.MaxValue);
            if (missingAmount > 0)
            {
                tempDict[value.Key] = missingAmount;
            }
        }

        //print("Finding robots if needed");
        //foreach (KeyValuePair<Form, int> value in tempDict)
        //{
        //    print(string.Format("Found {0} {1} needing to be spawned", value.Value, value.Key));
        //}
        //print("----------");

        StartCoroutine(SpawnRobots(tempDict));
    }
}
