using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodeTocar : MonoBehaviour
{
    public AudioSource audioInicio;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Narrador") == 1)
            audioInicio.Play();
    }
}
