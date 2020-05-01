using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool lastGame = false;

    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLast(int index)
    {
        lastGame = true;
        PlayerPrefs.SetString("lastGame", lastGame.ToString());
        SceneManager.LoadScene(index);
    }
}
