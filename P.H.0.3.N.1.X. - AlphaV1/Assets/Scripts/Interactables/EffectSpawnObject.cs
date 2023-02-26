using UnityEngine;

public class EffectSpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject m_objectPrefab;
    [SerializeField] private Vector3 m_locationOffset = new Vector3(0, 0, 0);

    public void SpawnObject()
    {
        Instantiate(m_objectPrefab, transform.position, Quaternion.identity, this.transform);
    }
}
