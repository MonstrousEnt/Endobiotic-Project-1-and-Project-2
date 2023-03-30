using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    #region Class Variables
    [Header("Form Prefab")]
    [SerializeField] private GameObject m_manipulatorPrefab;
    [SerializeField] private GameObject m_transportPrefab;
    [SerializeField] private GameObject m_magneticPrefab;
    [SerializeField] private GameObject m_electricPrefab;
    [SerializeField] private GameObject m_destroyerPrefab;
    [SerializeField] private GameObject m_batteryPrefab;
    [SerializeField] private GameObject m_crabPrefab;

    [Header("Spawner Data")]
    [SerializeField] private float m_spawnInterval = 5.0f;
    [SerializeField] private float m_spawnDistanceX;
    [SerializeField] private float m_spawnDistanceY;

    [Header("Robots List")]
    [SerializeField] private List<GameObject> m_userSpawnedRobots = new List<GameObject>();
    

    [Header("Sound Unity Event")]
    [SerializeField] private UnityEvent m_soundEffectUnityEvent;

    //Prefabs
    private List<GameObject> m_enemyFormList;

    //Robots List Dictionary
    private Dictionary<GameObject, robot> m_trackedRobots = new Dictionary<GameObject, robot>();

    #region Struts
    public struct robot
    {
        public robot(Form form, Vector3 position)
        {
            formRobot = form;
            positionRobot = position;
        }

        public Form formRobot;
        public Vector3 positionRobot;
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
        StartCoroutine(SpawnRobot(new robot(m_trackedRobots[caller].formRobot, m_trackedRobots[caller].positionRobot)));
        m_trackedRobots.Remove(caller);
    }

    private IEnumerator initialize()
    {
        yield return new WaitForEndOfFrame();
        LoadUserSpawnedRobots();
    }

    private void LoadRobotList()
    {
        m_enemyFormList = new List<GameObject>();

        m_enemyFormList.Add(m_manipulatorPrefab);
        m_enemyFormList.Add(m_transportPrefab);
        m_enemyFormList.Add(m_magneticPrefab);
        m_enemyFormList.Add(m_electricPrefab);
        m_enemyFormList.Add(m_destroyerPrefab);
        m_enemyFormList.Add(m_batteryPrefab);
        m_enemyFormList.Add(m_crabPrefab);
    }

    private IEnumerator SpawnRobot(robot robot)
    {
        yield return new WaitForSeconds(m_spawnInterval);

        GameObject newEnemy = Instantiate(
            m_enemyFormList[(int)robot.formRobot],
            new Vector3(
                Random.Range(transform.position.x - m_spawnDistanceX, transform.position.x + m_spawnDistanceX) + 0.5f,
                Random.Range(transform.position.y - m_spawnDistanceY, transform.position.y + m_spawnDistanceY) + 0.5f,
                0
            ),
            Quaternion.identity
        );

        m_trackedRobots.Add(newEnemy, robot);
        yield return 0;

        newEnemy.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        newEnemy.GetComponent<EnemyController>().UpdatePreferredPosition(robot.positionRobot);

        m_soundEffectUnityEvent?.Invoke();
    }

    private void LoadUserSpawnedRobots()
    {
        foreach(GameObject robot in m_userSpawnedRobots)
        {
            Form robotForm = robot.GetComponent<CharacterFormsController>().currForm;

            m_trackedRobots.Add(robot, new robot(robotForm, robot.transform.position));

            robot.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        }
    }
    #endregion
}
