using UnityEngine;

public class tempEnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
            return;

        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
