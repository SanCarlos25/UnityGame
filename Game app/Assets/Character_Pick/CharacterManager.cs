using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start() {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else {
            loadCharacter();
        }

   
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        saveCharacter();
    }



    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;

        }

        UpdateCharacter(selectedOption);
        saveCharacter();

    }

    private void loadCharacter() {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void saveCharacter() {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    private void ChangeScene(int sceneID) {
        SceneManager.LoadScene(sceneID);
    } 
  
}
