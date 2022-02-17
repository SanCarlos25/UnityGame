using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_button_Manger : MonoBehaviour
{

    // Update is called once per frame
    public void ChangeScene(int Destination_Scene)
    {
        Application.LoadLevel(Destination_Scene);
        
    }
}
