using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientojoystick : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 control;
    public Joystick joy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mover = new Vector3(joy.Horizontal, joy.Vertical);
        control = mover.normalized * speed;

        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + control * Time.deltaTime);
    }
}
