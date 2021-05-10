using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Button Pressed");
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel("GameScene"));
    }

    public void PlayAgain()
    {
        StartCoroutine(LoadLevel("GameScene"));
    }

    public void Quit()
    {
        StartCoroutine(LoadLevel("MainMenuScene"));
    }

    IEnumerator LoadLevel(string input)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(input);
    }



}
