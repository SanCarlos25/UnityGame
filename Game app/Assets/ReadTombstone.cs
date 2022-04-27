using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTombstone : MonoBehaviour
{
    public GameObject TombstoneMessage;

    private void OnTriggerEnter2D()
    {
        Debug.Log("We hit it");
        TombstoneMessage.SetActive(true);
    }

    public void CloseTombstone()
    {
        // undisplays the inventory UI
        TombstoneMessage.SetActive(false);
        // unpauses time
    }
}
