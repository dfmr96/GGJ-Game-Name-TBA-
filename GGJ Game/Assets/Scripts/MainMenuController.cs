using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject creditPanel;
    [SerializeField] GameObject pressStart;
    [SerializeField] GameObject[] objectsToEnable;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            HidePressStart();
        }   
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

    void HidePressStart()
    {
        pressStart.SetActive(false);
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }
        EventSystem.current.firstSelectedGameObject = objectsToEnable[0];
    }
}
