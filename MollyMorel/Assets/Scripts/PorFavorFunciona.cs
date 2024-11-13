using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorFavorFunciona : MonoBehaviour
{
    [SerializeField] private GameObject Molly;
    [SerializeField] private MollyMovement MollyCosas;
    [SerializeField] private Controladordesalas admin;

    [Header("Nueva sala:")]
    public int Sala;

    [Header("Direccion de Molly")]
    public float newX;
    public float newY;




    private bool puedeCambiar;
    
    void Start()
    {
        puedeCambiar = false;
    }

    void OnMouseDown()
    {
        puedeCambiar = true;
        Debug.Log("Has hecho clic en la manita");
    }

    //private void OnTriggerEnter(Collider other)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Player")) && puedeCambiar)
        {
            MollyCosas.QuietaParaa();
            admin.CambiaSala(Sala);
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Molly.transform.position = new Vector3(newX, newY, 0.0f);
            puedeCambiar = false;
        }
    }


}