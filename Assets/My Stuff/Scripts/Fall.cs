using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fall : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOver.gameObject.SetActive(true);
        }
    }
}
