using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            return;
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
