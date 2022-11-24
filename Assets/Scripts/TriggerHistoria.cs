using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class TriggerHistoria : MonoBehaviour
{
    public GameObject pergaminho;
    public string cena, historia;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se a colisao ocorrida foi com um jogador e não com o sonar por exemplo
        // assim, seta como ativo o pergaminho referente à história e toca o áudio.
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colisão detectada");
            pergaminho.SetActive(true);
            FindObjectOfType<AudioManager>().PlayMenu(historia);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Saiu da Colisão");
            pergaminho.SetActive(false);
            FindObjectOfType<AudioManager>().PararPlay(historia);
            SceneManager.LoadScene(cena);
            
        }
    }
}
