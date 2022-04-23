using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool muted = false;

    public void OnButtonPress()
    {
        if(muted == true)
        {
            muted = false;
            AudioListener.pause = false;
        }
    }

    public void OffButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
    }


    
}
