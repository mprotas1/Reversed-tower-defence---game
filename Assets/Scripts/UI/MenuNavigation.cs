using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    private GameObject MainMenu;
    private GameObject Options;

    private void Start()
    {
        MainMenu = GameObject.Find("MainButtons");
        Options = GameObject.Find("OptionsParent");
        Options.SetActive(false);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenOptions()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void BackToMenu()
    {
        Options.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
