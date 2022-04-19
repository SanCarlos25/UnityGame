using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    public static int character_choice;

    public void ChangeCharacter(int index)
    {
        character_choice = index;
        //Debug.Log("Character Choice = " + character_choice);
    }


    
}
