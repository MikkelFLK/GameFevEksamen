using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoretext;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("PlayerCurrentScore");
        scoretext.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
