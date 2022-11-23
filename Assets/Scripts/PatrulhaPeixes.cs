using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulhaPeixes : MonoBehaviour
{
    public float velocidade = 1f;
    public float minX, maxX;
    public float tempoDeEspera = 2f;
    private GameObject _meta;

    private void AtualizarMeta()
    {
        if (_meta == null)
        {
            _meta = new GameObject("Alvo");
            _meta.transform.position = new Vector2(minX, transform.position.y);
            return;
        }

        if (_meta.transform.position.x == minX)
        {
            _meta.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3((float)0.08315865, (float)0.08315865, (float)0.08315865);
        }
        else
            if (_meta.transform.position.x == maxX)
            {
                _meta.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-(float)0.08315865, (float)0.08315865, (float)0.08315865);
            }
    }

    IEnumerator PatrulhaAteMeta()
    {
        while (Vector2.Distance(transform.position, _meta.transform.position) > 0.05f)
        {
            Vector2 direcao = _meta.transform.position - transform.position;
            float direcaoX = direcao.x;
            transform.Translate(direcao.normalized * velocidade * Time.deltaTime);
            yield return null;
        }
        //Debug.Log("Meta encontrada!");
        transform.position = new Vector2(_meta.transform.position.x, transform.position.y);

        //Debug.Log($"Esperando por {tempoDeEspera} segundos");
        yield return new WaitForSeconds(tempoDeEspera);

        //Debug.Log("Esperou tempo bastante, vamos atualizar a meta e andar de novo");
        AtualizarMeta();
        StartCoroutine("PatrulhaAteMeta");
    }

    // Start is called before the first frame update
    void Start()
    {
        AtualizarMeta();
        StartCoroutine("PatrulhaAteMeta");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
