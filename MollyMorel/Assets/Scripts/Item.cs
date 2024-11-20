using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    [Header("Sprite del Item:")]
    public Sprite imagen;
    [Header("Nombre del Item:")]
    public string nombre;

    private bool isDragging;
    private Image imag;

    void Start()
    {
        imag = this.GetComponent<Image>();
        isDragging = false;
    }

    public void CaracteristicasItem(string n, Sprite s)
    {
        imag.sprite = s;
        imagen = s;
        nombre = n;
    }

    public void Clic()
    {
        isDragging = true;        
        /////INTERACCION CON EL PUNTERO
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDragging)
        {
            isDragging = false; 
        }
    }


/*
    public enum ObjetosEquipo
    {
        Conejo,
        Manivela,
        Semillas // puntos suspensivos
        //hay que anyadir mas
    };
    [SerializeField] ObjetosEquipo objetosEquipo;
    public void UsarObjeto()
    {
        //PersonajeScript personaje = GameObject.FindObjectOfType<PersonajeScript>();

        switch (objetosEquipo)
        {
            case ObjetosEquipo.Conejo:
                //personaje.SumaVida();
                //Debug.Log("Cura un punto de salud");
                break;

            case ObjetosEquipo.Manivela:
                //personaje.SumaVida();
                //personaje.SumaVida();
                //Debug.Log("Cura dos punto de salud");
                break;

            case ObjetosEquipo.Semillas:
                //personaje.SumaVelocidad();
                //Debug.Log("Concede velocidad");
                break;
        }
        Destroy(this.gameObject);
    }
    */



}
