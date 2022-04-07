using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;

    public void ChangeCharacter(int index)
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[index].SetActive(true);
    }


    
}
