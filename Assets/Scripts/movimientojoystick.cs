using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientojoystick : MonoBehaviour
{
    Animator anim;
    public float speed;
    private Rigidbody rb;
    private Vector3 control;
    public Joystick joy;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mover = new Vector3(joy.Horizontal, joy.Vertical,0);
        control = mover.normalized * speed;

        if (joy.Horizontal != 0f && joy.Vertical != 0f)
        {
            if (joy.Vertical >= 0f && joy.Horizontal == 0f)
            {
                anim.SetTrigger("WalkMLeft");
            }
            if (joy.Vertical >= 0f && joy.Horizontal >= 0f)
            {
                anim.SetTrigger("WalkMLeft");
            }

            if (joy.Vertical == 0f && joy.Horizontal >=0f)
            {
                anim.SetTrigger("WalkM");
            }
            if (joy.Vertical <=0f  && joy.Horizontal >=0f)
            {
                anim.SetTrigger("WalkM");
            }

            if (joy.Vertical <= 0f && joy.Horizontal == 0f)
            {
                //anim.SetTrigger("move_down_left");
            }
            if (joy.Vertical <=0f && joy.Horizontal <= 0f)
            {
                //anim.SetTrigger("move_down_left");
            }

            if (joy.Vertical == 0f && joy.Horizontal <= 0f)
            {
                //anim.SetTrigger("move_down_right");
            }
            if (joy.Vertical >= 0f && joy.Horizontal <= 0f)
            {
                //anim.SetTrigger("move_down_right");
            }
        }
        else
        {

            //left/right/up/down
            if (mover.x == -1)
            {
                anim.SetTrigger("WalkMPerfilLeft");
            }

            if (mover.x == 1)
            {
                anim.SetTrigger("WalkMPerfil");
            }


            if (mover.y == 1)
            {
                //anim.SetTrigger("Up");
            }


            if (mover.y == -1)
            {
                anim.SetTrigger("WalkDown");
            }
        }

        rb.MovePosition(rb.position + control * Time.deltaTime);
    }
    


}
