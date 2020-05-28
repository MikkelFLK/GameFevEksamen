using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilteMenu : MonoBehaviour
{
    public int playerScore;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

        PlayerPrefs.SetInt("PlayerCurrentScore", playerScore);
    }

    public void Quit()
    {
        PlayerPrefs.DeleteKey("PlayerCurrentScore");
        Application.Quit();
        Debug.Log("Quit");
    }
}
