using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;


public class ControleMenu : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public bool narrador;
    public Button jogar, voltar, controles;


    // Start is called before the first frame update
    void Start()
    {
        actions.Clear();
        actions.Add("Jogar", Jogar);
        actions.Add("Narrador", Narrador);
        actions.Add("Voltar", Voltar);
        actions.Add("Controles", Controles);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void Awake()
    {
        narrador = (PlayerPrefs.GetInt("Narrador") != 0);
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void Narrador()
    {
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

    private void Jogar()
    {
        jogar.onClick.Invoke();
    }

    private void Voltar()
    {
        voltar.onClick.Invoke();
    }

    private void Controles()
    {
        controles.onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            Narrador();
        narrador = (PlayerPrefs.GetInt("Narrador") != 0);
    }
}
