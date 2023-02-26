using System.Collections;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float duration;

    void Start()
    {
        StartCoroutine(DestroyAfter(duration));
    }

    IEnumerator DestroyAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
