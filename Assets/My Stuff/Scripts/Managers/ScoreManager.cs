using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoretext;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("PlayerCurrentScore");
        scoretext.text = "Score: " + score;
    }

    public void SaveData()
    {
        SaveManager.SaveData(this);
    }

    public void LoadData()
    {
        SaveData data = SaveManager.LoadData();

        PlayerPrefs.SetInt("PlayerCurrentScore", data.score);

        SceneManager.LoadScene(1);
    }

}
