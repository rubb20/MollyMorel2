using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject Objeto;
    [SerializeField] private GameObject puntero;
    private MollyMovement Molly;

    [Header("Sprite del Item:")]
    public Sprite imagen;
    [Header("Nombre del Item:")]
    public string nombre;

    private bool isDragging;
    private Image imag;
    private Image punt;

    void Start()
    {
        Molly = GameObject.FindObjectOfType<MollyMovement>();
    }

    void Awake()
    {
        imag = Objeto.GetComponent<Image>();
        punt = puntero.GetComponent<Image>();
        puntero.SetActive(false);
        isDragging = false;
    }

    public void CaracteristicasItem(string n, Sprite s)
    {
        nombre = n;
        imagen = s;
        imag.sprite = s;
    }

    /// <summary>
    ///  samba du brasil
    /// </summary>

    public void Clic()
    {
        Debug.Log("Has clicado en el item ");
        if(!puntero.activeSelf)
        {   
            Debug.Log("Se ha activado el puntero ");
            Molly.PerraQuieta();
            puntero.SetActive(true);
            punt.sprite = imagen;
            isDragging = true;

            /////INTERACCION CON EL PUNTERO
        }
    }

    Vector3 mouse;
    void Update()
    {
        mouse = Input.mousePosition;
        if (isDragging)
        {
            puntero.transform.position = mouse;
        }

        if (Input.GetMouseButtonDown(0) && isDragging)
        {
            isDragging = false; 
            puntero.SetActive(false);
            Molly.QuietaParaa();
            //Interactua con el otro objeto
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Esta funcion se colocara al hacer clic sobre la zona en la que se quiere utilizar el objeto:
    ////////////////////////////////////////////////////////////////////////////////////////////////////////    
    public void InteractuarConElObjeto(string nom)  
    {
        if(puntero.activeSelf && (punt.sprite == imagen) && (nom == nombre))
        {   
            UsarObjeto();
        }
    }


    //Aqui se pondran los efectos que ocurriran cuando se utilice el objeto
    public void UsarObjeto()
    {
        //PersonajeScript personaje = GameObject.FindObjectOfType<PersonajeScript>();

        switch (nombre)
        {
            case "Conejo":
                //personaje.SumaVida();
                //Debug.Log("Cura un punto de salud");
                break;

            case "Manivela":
                //personaje.SumaVida();
                //personaje.SumaVida();
                //Debug.Log("Cura dos punto de salud");
                break;

            case "Semillas":
                //personaje.SumaVelocidad();
                //Debug.Log("Concede velocidad");
                break;
        }
        //Destroy(this.gameObject);
    }



}
