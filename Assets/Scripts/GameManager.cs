using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator backToMenuButtonAnimator;
    public Animator startGameButtonAnimator;


    public void BackToMenu()
    {
        StartCoroutine(Menu());
    }
    
    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    IEnumerator Menu()
    {
        backToMenuButtonAnimator.SetTrigger("enable");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator StartButton()
    {
        startGameButtonAnimator.SetTrigger("enable");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }
}
