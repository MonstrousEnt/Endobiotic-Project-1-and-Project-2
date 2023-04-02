/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: Last Updated: April 2, 2023
 * Description: This is the class for spawner enemies.
 * Resources: 
 *  
 */

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
    private Dictionary<GameObject, Robot> m_trackedRobots = new Dictionary<GameObject, Robot>();
    #endregion

    #region Unity Methods
    private void Start()
    {
        StartCoroutine(initialize());
        loadRobotList();
    }
    #endregion

    #region AI Methods
    public void UpdateCurrentRobotsList(GameObject caller)
    {
        StartCoroutine(spawnRobot(new Robot(m_trackedRobots[caller].formRobot, m_trackedRobots[caller].positionRobot)));
        m_trackedRobots.Remove(caller);
    }

    private IEnumerator initialize()
    {
        yield return new WaitForEndOfFrame();
        loadUserSpawnedRobots();
    }

    private void loadRobotList()
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

    private IEnumerator spawnRobot(Robot a_robot)
    {
        yield return new WaitForSeconds(m_spawnInterval);

        GameObject l_newEnemy = Instantiate(
            m_enemyFormList[(int)a_robot.formRobot],
            new Vector3(
                Random.Range(transform.position.x - m_spawnDistanceX, transform.position.x + m_spawnDistanceX) + 0.5f,
                Random.Range(transform.position.y - m_spawnDistanceY, transform.position.y + m_spawnDistanceY) + 0.5f,
                0
            ),
            Quaternion.identity
        );

        m_trackedRobots.Add(l_newEnemy, a_robot);
        yield return 0;

        l_newEnemy.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        l_newEnemy.GetComponent<EnemyController>().UpdatePreferredPosition(a_robot.positionRobot);

        m_soundEffectUnityEvent?.Invoke();
    }

    private void loadUserSpawnedRobots()
    {
        foreach(GameObject l_robot in m_userSpawnedRobots)
        {
            Form l_robotForm = l_robot.GetComponent<CharacterFormsController>().currForm;

            m_trackedRobots.Add(l_robot, new Robot(l_robotForm, l_robot.transform.position));

            l_robot.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        }
    }
    #endregion
}
