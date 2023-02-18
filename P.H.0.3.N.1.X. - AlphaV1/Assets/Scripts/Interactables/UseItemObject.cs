using UnityEngine;

public class UseItemObject : MonoBehaviour
{
    public void UseItem()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterItemHolder>().UseItem();
    }
}
