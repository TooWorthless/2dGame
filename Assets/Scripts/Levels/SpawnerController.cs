using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] EnemyFollow enemy;
    [SerializeField] PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == player.name) 
        {
            CreateEnemy();
            this.gameObject.SetActive(false);
        }
    }
    private void CreateEnemy() 
    {
        EnemyFollow e = Instantiate(enemy, this.transform.position, Quaternion.identity);
        e.playerController = player;
    }
}
