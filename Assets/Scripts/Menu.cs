using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool narrador;

    public void PlayGame(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    private void Awake()
    {
        narrador = (PlayerPrefs.GetInt("Narrador") != 0);
    }

    public void VoltarPararSom()
    {
        FindObjectOfType<AudioManager>().PararPlay("GuiaControles");
    }

    public void TocarSomControles()
    {
        FindObjectOfType<AudioManager>().PlayMenu("GuiaControles");
    }

    public void Narrador()
    {
        //SingletonNarrador.Instance.narrador = !SingletonNarrador.Instance.narrador;
        narrador = !narrador;
        PlayerPrefs.SetInt("Narrador", (narrador ? 1 : 0));
        if (narrador)
        {
            FindObjectOfType<AudioManager>().PararPlay("NarradorDesativado");
            FindObjectOfType<AudioManager>().Narrador("NarradorAtivado");
        }
        else
        {
            FindObjectOfType<AudioManager>().PararPlay("NarradorAtivado");
            FindObjectOfType<AudioManager>().Narrador("NarradorDesativado");
        }
    }

    public void HoverJogar()
    {
        FindObjectOfType<AudioManager>().PararPlay("SomSair");
        FindObjectOfType<AudioManager>().PararPlay("NarradorAtivado");
        FindObjectOfType<AudioManager>().PlayMenu("SomJogar");
        FindObjectOfType<AudioManager>().PararPlay("VozControles");
    }

    public void HoverNarrar()
    {
        FindObjectOfType<AudioManager>().PararPlay("SomSair");
        FindObjectOfType<AudioManager>().PararPlay("SomJogar");
        FindObjectOfType<AudioManager>().PlayMenu("NarradorAtivado");
        FindObjectOfType<AudioManager>().PararPlay("VozControles");
    }

    public void HoverControles()
    {
        FindObjectOfType<AudioManager>().PararPlay("SomSair");
        FindObjectOfType<AudioManager>().PararPlay("SomJogar");
        FindObjectOfType<AudioManager>().PararPlay("NarradorAtivado");
        FindObjectOfType<AudioManager>().PlayMenu("VozControles");
    }

    public void HoverSair()
    {
        FindObjectOfType<AudioManager>().PararPlay("SomJogar");
        FindObjectOfType<AudioManager>().PararPlay("NarradorAtivado");
        FindObjectOfType<AudioManager>().PlayMenu("SomSair");
        FindObjectOfType<AudioManager>().PararPlay("VozControles");
    }

    public void HoverVoltar()
    {
        FindObjectOfType<AudioManager>().PlayMenu("VozVoltar");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            Narrador();
        narrador = (PlayerPrefs.GetInt("Narrador") != 0);
    }
}
