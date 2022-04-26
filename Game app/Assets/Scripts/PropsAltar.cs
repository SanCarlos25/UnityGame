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

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

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
            //audioSrc = GetComponent<AudioSource>();
            
            yield return new WaitForSeconds(1f);
            audioSrc.PlayOneShot(LevelCompleteAudio, .5f);
            levelCompleteUI.SetActive(true);
            FirstLevelComplete = false;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }

