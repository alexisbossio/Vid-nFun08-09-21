﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioxtrigger4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<cambioesena>().CambioDeNivel(cambioesena.Levels.Paris);
        }
    }
}
