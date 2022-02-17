using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Handler : MonoBehaviour
{ 

  
    public void SceneHandler(string Destination_Scene){
        Application.LoadLevel(Destination_Scene);
    }
}
