using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform player;

    private float time;
    public float startTime;
    private bool isMove = true;
    public float damage;

    [SerializeField] Animator anim;






    public PlayerController playerController;

    private bool isFacingRight = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(isMove) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }
        else {
            anim.SetBool("isMoving", false);
        }

        if(time <= 0f) {
            isMove = true;
        }
        else {
            time -= Time.deltaTime;
        }

        if(transform.position.x >= playerController.transform.position.x) {
            if(isFacingRight == true) {
                isFacingRight = false;
                Flip();
            }
        }
        else if(transform.position.x < playerController.transform.position.x) {
            if(isFacingRight == false) {
                isFacingRight = true;
                Flip();
            }
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if(col.gameObject.tag == "Player" && isMove != false) {
            time = startTime;
            isMove = false;
            anim.SetBool("isMoving", false);
            anim.SetBool("attack", true);
            playerController.HP -= damage;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player" && isMove != false) {
            time = startTime;
            isMove = false;
            anim.SetBool("isMoving", false);
            anim.SetBool("attack", true);
            playerController.HP -= damage;
        }
    }


    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
