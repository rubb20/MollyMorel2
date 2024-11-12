using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeSala : MonoBehaviour
{
    [SerializeField] private GameObject Molly;
    [SerializeField] private MollyMovement MollyCosas;

    [Header("Direccion de la camara")]
    public int pX;
    public int pY;

    [Header("Direccion de Molly")]
    public float newX;
    public float newY;


    private float W = 6600.0f;
    private float H = 3600.0f;


    private bool puedeCambiar;
    
    void Start()
    {
        puedeCambiar = false;
    }

    void OnMouseDown()
    {
        puedeCambiar = true;
        Debug.Log("Has hecho clic en la manita");
        Debug.Log("Has hecho clic en la manita" + puedeCambiar);
    }

    //private void OnTriggerEnter(Collider other)
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("La molly choca con el collider");
        if ((other.gameObject.CompareTag("Player")) && puedeCambiar)
        {
            MollyCosas.QuietaParaa();
            Camera.main.transform.position += new Vector3(pX * W, pY * H, 0.0f);
            //Fondo.transform.position += new Vector3(pX * W, pY * H, 0.0f);
            Molly.transform.position = new Vector3(newX, newY, 0.0f);
            puedeCambiar = false;
        }
    }


    void Update()
    {
        
    }
}
