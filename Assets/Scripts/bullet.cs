using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject luzColisao;
    float tempoLimite = 5f;

    SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer = GetComponent <SpriteRenderer>();

        FindObjectOfType<AudioManager>().Play("AudioColisao", this.transform);
        Destroy(gameObject);

        GameObject luzTemporaria = Instantiate(luzColisao, transform.position, transform.rotation);
        

        Destroy(luzTemporaria, tempoLimite);
    }
}
