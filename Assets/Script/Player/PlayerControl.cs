using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector] public bool key = false;
    bool bomb = false;
    PlayerVariable player;
    Animator animator;
    LayerMask enemy;
    SpriteRenderer sprite;
    GameObject chest;
    bool isRunning = false;
    float SpeedAwal;
    void Awake() 
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerVariable>();    
        SpeedAwal = player.moveSpeed;
        enemy = player.enemy;
    }
    void Update()
    {
        UiDisplay();
        animController();
        getHit();
        flip();
        dead();
    }
    public void move(InputAction.CallbackContext context)
    {
        isRunning = true;
        getDirection(context.ReadValue<Vector2>());
        if(context.canceled)
        {
            isRunning = false;
        }
    }
    public void attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            FindObjectOfType<Sword>().GetComponent<Animator>().SetTrigger("attack");
        }
    }
    public void placeBomb(InputAction.CallbackContext context)
    {
        if(context.started && bomb)
        {
            Instantiate(player.bomb,transform.position,Quaternion.identity);
            bomb = false;
        }
    }

    public void openChest(InputAction.CallbackContext context)
    {
        if(context.started && key && chest != null)
        {
            chest.GetComponent<Chest>().openChest();
            key = false;
        }
    }
    void  getDirection(Vector2 direction)
    {
        player.direction = direction;
    }
    void animController()
    {
        animator.SetBool("running",isRunning);
    }
    void flip()
    {
        if(player.direction.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(player.direction.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }
    void dead()
    {
        if(player.health <= 0 && player.healthBar.value <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<LevelManager>().Invoke("GameOver",3f);
            PlayerVariable.lastScore = player.coin;
            player.canvas.SetActive(false);
        }
    }
    void getHit()
    {
        if(GetComponent<BoxCollider2D>().IsTouchingLayers(enemy))
        {
            sprite.color = player.invisible;
            enemy = LayerMask.GetMask("ll");
            player.moveSpeed += 5;
            player.health--;
            Invoke("backtoNormal",1);
        }
    }
    void backtoNormal()
    {
        sprite.color = player.normal;
        enemy = player.enemy;
        player.moveSpeed = SpeedAwal;
    }
    void UiDisplay()
    {
        player.healthBar.value = player.health;
        player.coinText.text = player.coin.ToString();
        showKey();
        showBomb();
    }
    void showBomb()
    {
        if(!bomb)
        {
            player.bombUI.color = new Color(0,0,0,1);
        }
        else
            player.bombUI.color = new Color(1,1,1,1);
    }
    void showKey()
    {
        if(!key)
        {
            player.key.color = new Color(0,0,0,1);
        }
        else
            player.key.color = new Color(1,1,1,1);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Key" && !key)
        {
            key = true;
            Destroy(other.gameObject);
        }
        if(other.tag == "Coin")
        {
            player.coin += Random.Range(1,11);
            Destroy(other.gameObject);
        }
        if(other.tag == "Chest")
        {
            chest = other.gameObject;
        }
        if(other.tag == "Bomb")
        {
            bomb = true;
            Destroy(other.gameObject);
        }
        if(other.tag == "Exit")
        {
            FindObjectOfType<LevelManager>().nextScene();
        }   
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Chest")
        {
            chest = null;
        }
    }
}
