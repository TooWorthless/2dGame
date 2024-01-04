using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potka : MonoBehaviour
{
    public PlayerController player;

    public float hp;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            if(player.HP < player.maxHP) {
                player.HP += hp;
                Destroy(gameObject);
            }
        }
    }
}
