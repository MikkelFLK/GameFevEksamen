using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageName;

    private void Start()
    {
        DisplayStage();
    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisplayStage()
    {
        stageName.text = SceneManager.GetActiveScene().name;
    }
}
