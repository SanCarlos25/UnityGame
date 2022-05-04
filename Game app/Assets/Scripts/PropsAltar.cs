using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]

//when something get into the altar, make the runes glow
public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        public GameObject levelCompleteUI;
        private AudioSource audioSrc;
        public AudioClip LevelCompleteAudio;
        public bool FirstLevelComplete = false;
        public GameObject glow;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // when the user puts the block with the light up characters in the altar, the level is complete
    private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            // trigger the end of the level
            if (other.gameObject.CompareTag("TRIGGER_STONE"))
            {
                FirstLevelComplete = true;
                StartCoroutine(Wait());

            }


        }

        // creates a delay before the LevelComplete UI is displayed
        IEnumerator Wait()
        {
            // returns all the one time triggers back to default
            glow.SetActive(true);
            yield return new WaitForSeconds(1f);
            audioSrc.PlayOneShot(LevelCompleteAudio, .5f);
            levelCompleteUI.SetActive(true);
            FirstLevelComplete = false;
        }
        
        // turns off the lights in the block
        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
        }
        
        // creates the slow fading/blinking light animation in the block
        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }

