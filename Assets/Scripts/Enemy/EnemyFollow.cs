using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform player;

    private float time;
    public float startTime;
    private bool isMove = true;
    public float damage;

    [SerializeField] Animator anim;

    public Slider slider;




    public PlayerController playerController;

    private bool isFacingRight = false;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent <Rigidbody2D>();
    }

    void Update()
    {
        if(isMove) {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            Vector2 directionOfTravel = player.position - transform.position;
            directionOfTravel.Normalize();
            rb.velocity = directionOfTravel * speed;
            //Debug.Log(player.position);
            //Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            //rb.MovePosition(currentPosition + (directionOfTravel * speed * Time.deltaTime));
            //Debug.Log((directionOfTravel * speed * Time.deltaTime).ToString());

            //Vector2 directionOfTravel = player.position - transform.position;
            //directionOfTravel.Normalize();
            //rb.AddForce(directionOfTravel * speed * Time.deltaTime, ForceMode2D.Impulse);   


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
            rb.velocity = new Vector2(0,0);
            //Debug.Log(rb.velocity.ToString());
            time = startTime;
            isMove = false;
            anim.SetBool("isMoving", false);
            anim.SetBool("attack", true);
            playerController.HP -= damage;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player" && isMove != false) {
            rb.velocity = new Vector2(0, 0);
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


        Vector3 sliderScale = slider.transform.localScale;
        sliderScale.x *= -1f;
        slider.transform.localScale = sliderScale;
    }
}
