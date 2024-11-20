using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class OpcionesItems : MonoBehaviour
{
    [SerializeField] private GameObject Molly;
    [SerializeField] private GameObject KovalskiOpciones;
    //[SerializeField] private GameObject Inventario;
    [SerializeField] private InventarioControler Inventario;
    [SerializeField] private MollyMovement MollyCosas;
    //[SerializeField] private GameObject equipo;


    //public bool estaActivo;
    [Header("Sprite del Item:")]
    [SerializeField] public Sprite imagen;
    [Header("Nombre del Item:")]
    public string nombre;


    [Header("Variables de 'agarrar':")]
    public bool cojible;
    [SerializeField] private string [] textoNoSeCoje;
    [Header("Variables de 'hablar':")]    
    [SerializeField] private string [] textosHablar;


    private bool puedeInteractuar;
    
    void Start()
    {
        
        puedeInteractuar = false;
    }

    void OnMouseDown()
    {
        puedeInteractuar = true;
        Debug.Log("Has hecho clic en " + nombre);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Player")) && puedeInteractuar)
        {
            MollyCosas.QuietaParaa();
            /////////////////////////////////////se despliegan las opciones
            KovalskiOpciones.SetActive(true);

            puedeInteractuar = false;
        }
    }
    /// <summary>
    /// apt apt apt apt apt apt mm aja aja
    /// </summary>


    public void TeVoyACojer()
    {
        if (cojible)
        {
            ///
            //AdquirirObjeto();
            Inventario.AgregaItem(nombre, imagen);
        }else{
            ///
        }
    }

    public void AdquirirObjeto()
    {        
        //GameObject equipo = (GameObject)Resources.Load<GameObject>("Objeto");
        //Instantiate(equipo, Vector3.zero, Quaternion.identity, Inventario.transform);


        //Item it = equipo.GetComponent<Item>();
        //it.CaracteristicasItem(nombre, imagen);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && KovalskiOpciones.activeSelf)
        {
            KovalskiOpciones.SetActive(false);
        }
        
    }


}
