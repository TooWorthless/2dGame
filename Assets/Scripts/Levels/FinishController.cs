using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] int SceneBuildNumber;
    [SerializeField] PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == player.name) 
        {
            SceneManager.LoadScene(SceneBuildNumber);
        }
    }
}
