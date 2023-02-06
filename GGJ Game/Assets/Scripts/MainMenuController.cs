using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditPanel.SetActive(false);
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditPanel.SetActive(true);
    }
}
