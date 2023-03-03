using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainMenuOpenTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameMangerRootMaster.instance.uIEvents.tryAgainIsActive == false)
        {
            GameMangerRootMaster.instance.uIEvents.InvokeEnableTryAgainMneu();
        }
    }
}
