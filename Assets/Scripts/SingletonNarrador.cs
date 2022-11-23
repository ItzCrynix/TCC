using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonNarrador : MonoBehaviour
{

    public static SingletonNarrador Instance { get; private set; }

    public bool narrador = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
