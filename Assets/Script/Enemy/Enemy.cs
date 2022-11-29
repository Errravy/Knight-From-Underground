using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float distance;
    public int health;
    [SerializeField] Vector2 speedVar;
    [SerializeField] GameObject coin;
    [SerializeField] Color gethit;
    [SerializeField] Color normal;
    [SerializeField] float turbo;
    [SerializeField] int size = 1;
    float speed;
    int checkEnemy;
    GameObject room;
    Transform player;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(speedVar.x,speedVar.y);
    }
    private void Start() {
        player = FindObjectOfType<PlayerVariable>().transform;
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        if(room != null)
        {
            move();
        }
        dead();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Sword")
        {
            spriteRenderer.color = gethit;
            rb.velocity = new Vector2(-turbo * transform.localScale.x,Random.Range(-1,1));
            Invoke("backNormal",0.2f);
            health--;
        }
        if(other.tag == "Room")
        {
            room = other.gameObject;
        }
        if(other.tag == "Explosion")
        {
            health = 0;
        }
    }
    void dead()
    {
        if(health <= 0)
        {
            dropResource();
            room.GetComponent<EnemySpawner>().checkEnemy--;
            Destroy(gameObject);
        }
    }
    void move()
    {   
        if(player != null && room.GetComponent<PlayerDetect>().playerInRoom)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.position,speed * Time.fixedDeltaTime);
            flip();
        }
        else 
        {
            player = FindObjectOfType<PlayerVariable>().transform;
        }
            

    }
    void flip()
    {
        if(transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(1 * size,1 * size,1);
        }
        else if(transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(-1 * size,1 * size,1);
        }
    }

    void backNormal()
    {
        rb.velocity = Vector2.zero;
        spriteRenderer.color = normal;
    }
    void dropResource()
    {
        float chance = Random.Range(0,10.1f);
        if(chance <= 4)
        {
            Instantiate(coin,transform.position,Quaternion.identity);
        }
        
    }
}
