using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class AndarTiles : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public GameObject pergaminho;

    public LayerMask pararMovimento;

    public float cooldownSomHoriz = 1f;
    private float cooldownTimerHoriz = Mathf.Infinity;

    public float cooldownSomVert = 1f;
    private float cooldownTimerVert = Mathf.Infinity;

    public bool direita = false;
    public bool esquerda = false;
    public bool cima = false;
    public bool baixo = false;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public bool narrador;

    // Start is called before the first frame update
    void Start()
    {
        actions.Clear();
        actions.Add("Direita", Direita);
        actions.Add("Esquerda", Esquerda);
        actions.Add("Cima", Cima);
        actions.Add("Baixo", Baixo);
        actions.Add("Narrador", Narrador);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        movePoint.parent = null;        

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

    private void Direita()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0, 0f), .02f, pararMovimento))
        {
            movePoint.position += new Vector3(1f, 0f, 0f);
            if (!direita)
            {
                FindObjectOfType<AudioManager>().PlayMenu("VozDireita");
                direita = true;
                esquerda = false;
                cima = false;
                baixo = false;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
            FindObjectOfType<AudioManager>().Play("SomParede", movePoint.transform);
    }

    private void Esquerda()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .02f, pararMovimento))
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
            if (!esquerda)
            {
                FindObjectOfType<AudioManager>().PlayMenu("VozEsquerda");
                direita = false;
                esquerda = true;
                cima = false;
                baixo = false;
            }
            transform.rotation = Quaternion.Euler(180f, 0f, 180f);
        }
        else
            FindObjectOfType<AudioManager>().Play("SomParede", movePoint.transform);
    }

    private void Cima()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .02f, pararMovimento))
        {
            movePoint.position += new Vector3(0f, 1, 0f);
            if (!cima)
            {
                FindObjectOfType<AudioManager>().PlayMenu("VozCima");
                direita = false;
                esquerda = false;
                cima = true;
                baixo = false;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else
            FindObjectOfType<AudioManager>().Play("SomParede", movePoint.transform);
    }

    private void Baixo()
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .02f, pararMovimento))
        {
            movePoint.position += new Vector3(0f, -1f, 0f);
            if (!baixo)
            {
                FindObjectOfType<AudioManager>().PlayMenu("VozBaixo");
                direita = false;
                esquerda = false;
                cima = false;
                baixo = true;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else
            FindObjectOfType<AudioManager>().Play("SomParede", movePoint.transform);
    }

    public void Narrador()
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

        // Update is called once per frame
        void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.5f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .02f, pararMovimento))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    if (Input.GetAxisRaw("Horizontal") == 1f)
                    {
                        if (!direita)
                        {
                            FindObjectOfType<AudioManager>().PlayMenu("VozDireita");
                            direita = true;
                            esquerda = false;
                            cima = false;
                            baixo = false;
                        }
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    else
                    {
                        if (!esquerda)
                        {
                            FindObjectOfType<AudioManager>().PlayMenu("VozEsquerda");
                            direita = false;
                            esquerda = true;
                            cima = false;
                            baixo = false;
                        }
                        transform.rotation = Quaternion.Euler(180f, 0f, 180f);
                    }
                }
                else
                {
                    if (cooldownTimerHoriz > cooldownSomHoriz)
                    {
                        FindObjectOfType<AudioManager>().Play("SomParede", movePoint.transform);
                        cooldownTimerHoriz = 0;
                    }
                }
            }
            else
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .02f, pararMovimento))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    if (Input.GetAxisRaw("Vertical") == 1f)
                    {
                        if (!cima)
                        {
                            FindObjectOfType<AudioManager>().PlayMenu("VozCima");
                            direita = false;
                            esquerda = false;
                            cima = true;
                            baixo = false;
                        }
                        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                    }
                    else
                    {
                        if (!baixo)
                        {
                            FindObjectOfType<AudioManager>().PlayMenu("VozBaixo");
                            direita = false;
                            esquerda = false;
                            cima = false;
                            baixo = true;
                        }
                        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                    }
                }
                else
                {
                    if (cooldownTimerVert > cooldownSomVert)
                    {
                        FindObjectOfType<AudioManager>().Play("SomParede", movePoint.transform);
                        cooldownTimerVert = 0;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Narrador();
        }
        cooldownTimerVert += Time.deltaTime;
        cooldownTimerHoriz += Time.deltaTime;
    }
}
