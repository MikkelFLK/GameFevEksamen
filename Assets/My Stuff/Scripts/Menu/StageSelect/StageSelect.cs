using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageSelect : MonoBehaviour
{
    public void Stage0()
    {
        SceneManager.LoadScene(2);
    }

    public void Stage1()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        PlayerPrefs.DeleteKey("PlayerCurrentScore");
        Application.Quit();
        Debug.Log("Quit");
    }
}
