using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodeTocar : MonoBehaviour
{
    public AudioSource audioInicio, audioFase;
    // Start is called before the first frame update
    void Start()
    {
        audioFase.Play();
        if (PlayerPrefs.GetInt("Narrador") == 1)
        {
            audioInicio.PlayDelayed(audioFase.clip.length);
        }
    }
}
