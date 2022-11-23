using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHistoria : MonoBehaviour
{
    public GameObject pergaminho;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colisão detectada");
            pergaminho.SetActive(true);
            FindObjectOfType<AudioManager>().PlayMenu("HistoriaParte1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Saiu da Colisão");
            pergaminho.SetActive(false);
            FindObjectOfType<AudioManager>().PararPlay("HistoriaParte1");
        }
    }
}
