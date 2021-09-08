using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Animator anim;
    
    public float speed = 5f;
    private Vector2 movement;
      
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(inputX, inputY);

        //Diagonals

        if (inputX != 0 && inputY != 0)
        {
            if (movement.y == 1 && movement.x == -1)
            {
                anim.SetTrigger("WalkMLeft");
            }

            if (movement.y == 1 && movement.x == 1)
            {
                anim.SetTrigger("WalkM");
            }

            if (movement.y == -1 && movement.x == -1)
            {
                //anim.SetTrigger("move_down_left");
            }

            if (movement.y == -1 && movement.x == 1)
            {
                //anim.SetTrigger("move_down_right");
            }
        }

        else
        {

            //left/right/up/down
            if (movement.x == -1)
            {
                anim.SetTrigger("WalkMPerfilLeft");
            }

            if (movement.x == 1)
            {
                anim.SetTrigger("WalkMPerfil");
            }


            if (movement.y == 1)
            {
                //anim.SetTrigger("Up");
            }


            if (movement.y == -1)
            {
                anim.SetTrigger("WalkDown");
            }
        }

  




        transform.Translate(movement * speed * Time.deltaTime);
    }

}
