using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class inextremis : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] GameObject[] objectsToDisable;
    [SerializeField] GameObject[] objectsToEnable;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(LoadScene());
        }
    }
    
    IEnumerator LoadScene()
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }
        anim.Play("FadeIn");
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }
        yield return new WaitForSeconds(8f);
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
