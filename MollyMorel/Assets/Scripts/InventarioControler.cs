using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class InventarioControler : MonoBehaviour
{
    [SerializeField] private GameObject[] array = new GameObject[6];
    [SerializeField] private GameObject puntero;
    
    private MollyMovement Molly;

    void Start()
    {
        Molly = GameObject.FindObjectOfType<MollyMovement>();
        for(int i = 0; i< 6; i++)
        {
            array[i].SetActive(false);
        }
    }

    public void AgregaItem(string nombre, Sprite imagen)
    {
        bool encontrado = false;
        for(int i = 0; (i< 6) && !encontrado; i++)
        {
            if (!array[i].activeSelf)
            {
                array[i].SetActive(true);
                encontrado = true;
                Debug.Log("Se ha agregado al inventario ");

                Item it = array[i].GetComponent<Item>();
                it.CaracteristicasItem(nombre, imagen);
            }
            
        }
        Molly.QuietaParaa();
    }


    void Update()
    {
        
    }
}
