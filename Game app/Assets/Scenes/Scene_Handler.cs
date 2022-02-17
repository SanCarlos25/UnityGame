using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Button_Manger : MonoBehaviour
{

    
    public void ChangeScene(string Destination_Scene)
    {
        Application.LoadLevel(Destination_Scene);
        
    }
}
