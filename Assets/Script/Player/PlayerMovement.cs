using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerVariable player;
    Rigidbody2D rb;
    void Start()
    {
        player = GetComponent<PlayerVariable>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        run();
    }

    void run()
    {
        float x = player.moveSpeed * player.direction.x;
        float y = player.moveSpeed * player.direction.y;
        rb.velocity = new Vector2(x,y);
    }

}
