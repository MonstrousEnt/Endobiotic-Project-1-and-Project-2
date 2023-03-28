using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    #region Class Variables
    [Header("Form Prefab")]
    [SerializeField] private GameObject ManipulatorPrefab;
    [SerializeField] private GameObject TransportPrefab;
    [SerializeField] private GameObject MagneticPrefab;
    [SerializeField] private GameObject ElectricPrefab;
    [SerializeField] private GameObject DestroyerPrefab;
    [SerializeField] private GameObject BatteryPrefab;
    [SerializeField] private GameObject CrabPrefab;

    [Header("Spawner Data")]
    [SerializeField] private float spawnInterval = 5.0f;
    [SerializeField] private float spawnDistanceX;
    [SerializeField] private float spawnDistanceY;

    [Header("Robots List")]
    [SerializeField] private List<GameObject> userSpawnedRobots = new List<GameObject>();
    private Dictionary<GameObject, Robot> trackedRobots = new Dictionary<GameObject, Robot>();

    [Header("Sound Unity Event")]
    [SerializeField] private UnityEvent soundEffectUnityEvent;

    //Prefabs
    private List<GameObject> EnemyFormList;

    #region Struts
    public struct Robot
    {
        public Robot(Form form, Vector3 position)
        {
            m_form = form;
            m_position = position;
        }

        public Form m_form;
        public Vector3 m_position;
    }
    #endregion

    #endregion

    #region Unity Methods
    private void Start()
    {
        StartCoroutine(initialize());
        LoadRobotList();
    }
    #endregion

    #region AI Methods
    public void UpdateCurrentRobotsList(GameObject caller)
    {
        StartCoroutine(SpawnRobot(new Robot(trackedRobots[caller].m_form, trackedRobots[caller].m_position)));
        trackedRobots.Remove(caller);
    }

    private IEnumerator initialize()
    {
        yield return new WaitForEndOfFrame();
        LoadUserSpawnedRobots();
    }

    private void LoadRobotList()
    {
        EnemyFormList = new List<GameObject>();

        EnemyFormList.Add(ManipulatorPrefab);
        EnemyFormList.Add(TransportPrefab);
        EnemyFormList.Add(MagneticPrefab);
        EnemyFormList.Add(ElectricPrefab);
        EnemyFormList.Add(DestroyerPrefab);
        EnemyFormList.Add(BatteryPrefab);
        EnemyFormList.Add(CrabPrefab);
    }

    private IEnumerator SpawnRobot(Robot robot)
    {
        yield return new WaitForSeconds(spawnInterval);

        GameObject newEnemy = Instantiate(
            EnemyFormList[(int)robot.m_form],
            new Vector3(
                Random.Range(transform.position.x - spawnDistanceX, transform.position.x + spawnDistanceX) + 0.5f,
                Random.Range(transform.position.y - spawnDistanceY, transform.position.y + spawnDistanceY) + 0.5f,
                0
            ),
            Quaternion.identity
        );

        trackedRobots.Add(newEnemy, robot);
        yield return 0;

        newEnemy.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        newEnemy.GetComponent<EnemyController>().UpdatePreferredPosition(robot.m_position);

        soundEffectUnityEvent.Invoke();
    }

    private void LoadUserSpawnedRobots()
    {
        foreach(GameObject robot in userSpawnedRobots)
        {
            Form robotForm = robot.GetComponent<CharacterFormsController>().currForm;

            trackedRobots.Add(robot, new Robot(robotForm, robot.transform.position));

            robot.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        }
    }
    #endregion
}
