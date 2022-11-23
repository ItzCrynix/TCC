using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Emissao : MonoBehaviour
{
    public Transform firePoint;
    public GameObject sonarPrefab;

    [SerializeField]
    public float forcaSonar;
    [SerializeField]
    public float cooldown;
    private float cooldownTimer = Mathf.Infinity;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Clear();
        actions.Add("Sonar", Sonar);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Sonar()
    {
        cooldownTimer = 0;
        GameObject sonar = Instantiate(sonarPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = sonar.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * forcaSonar, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer > cooldown)     
            Sonar();
        cooldownTimer += Time.deltaTime;
    }

}
