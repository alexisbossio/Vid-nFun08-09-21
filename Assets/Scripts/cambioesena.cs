using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioesena : MonoBehaviour
{
    public enum Levels { Puerta = 0, Pinball = 1, Vidonjump = 2 ,Galeria = 3}
    public void CambioDeNivel(Levels level)
    {
       SceneManager.LoadScene((int)level); 

    }
    public void CambioDeNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
