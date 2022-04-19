using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Sprite_renderer : MonoBehaviour
{

    private SpriteRenderer rend;
    private Sprite Female1, Female2, Male1, Male2, Male3;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Female1= Resources.Load<Sprite>("Female1_9");
        Female2= Resources.Load<Sprite>("Female2_10");
        Male1 = Resources.Load<Sprite>("Male1_13");
        Male2 = Resources.Load<Sprite>("Male1_61");
        Male3 = Resources.Load<Sprite>("Male1_83");
        int index = SkinManager.character_choice;
        Debug.Log("Selected_character = " + index);
        
        switch (index){
            case 0:
                rend.sprite = Female1;
                break;
            case 1:
                rend.sprite = Female2;
                break;
            case 2:
                rend.sprite = Male1;
                break;
            case 3:
                rend.sprite = Male2;
                break;
            case 4:
                rend.sprite = Male3;
                break;
        }
        
    }

}
