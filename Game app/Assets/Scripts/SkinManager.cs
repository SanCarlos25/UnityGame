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
        // choses the character to the choice of the user.
        // This lags a bit in the initial run but works when moving the player
        character_choice = index;


        //Debug.Log("Character Choice = " + character_choice);
    }


    
}
