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
    [SerializeField] private GameObject Dialogos;


    //public bool estaActivo;
    //[Header("Sprite del Item:")]
    //public Sprite imagen;
    [Header("Nombre del Item:")]
    public string nombre;


    [Header("Variables de 'agarrar':")]
    public bool cojible;
    [SerializeField] private string [] textoNoSeCoje;
    [Header("Variables de 'hablar':")]    
    [SerializeField] private string [] textosHablar;
    [SerializeField] private int [] HablantesNumeros;


    private bool puedeInteractuar;
    private Sprite imag;

    void Start()
    {
        imag = GetComponent<Image>().sprite;
        puedeInteractuar = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && KovalskiOpciones.activeSelf)   //me cago en el button up y la madre que lo pario amen
        {
            KovalskiOpciones.SetActive(false);
            MollyCosas.QuietaParaa();
        }
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
            //MollyCosas.QuietaParaa();
            /////////////////////////////////////se despliegan las opciones
            KovalskiOpciones.SetActive(true);

            puedeInteractuar = false;
            MollyCosas.StopAllCoroutines();
            MollyCosas.PerraQuieta();
            //MollyCosas.QuietaParaa();
        }
    }
    /// <summary>
    /// apt apt apt apt apt apt mm aja aja
    /// </summary>


    public void TeVoyACojer()
    {
        if (cojible)
        {
            MollyCosas.PerraQuieta();
            ///
            //AdquirirObjeto();
            Debug.Log("Has cojido un " + nombre);
            Inventario.AgregaItem(nombre, imag);
        }else{
            ///
            int[] n = new int[] { -1, -1, -1, -1, -1, -1, -1 };
            Dialogos.SetActive(true);
            ControlTextos c = Dialogos.GetComponent<ControlTextos>();
            c.PuesTocaHablar(textoNoSeCoje, n);
            
        }
    }

    public void CuentameElChisme()
    {
        Dialogos.SetActive(true);
        ControlTextos c = Dialogos.GetComponent<ControlTextos>();
        c.PuesTocaHablar(textosHablar, HablantesNumeros);
    }

    public void AdquirirObjeto()
    {        
        //GameObject equipo = (GameObject)Resources.Load<GameObject>("Objeto");
        //Instantiate(equipo, Vector3.zero, Quaternion.identity, Inventario.transform);


        //Item it = equipo.GetComponent<Item>();
        //it.CaracteristicasItem(nombre, imagen);
    }

}
