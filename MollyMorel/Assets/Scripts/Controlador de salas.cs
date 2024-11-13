using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controladordesalas : MonoBehaviour
{
    [SerializeField] private GameObject[] Salas;
    [SerializeField] private GameObject[] Manos;
    
    [SerializeField] private MollyMovement MollyCosas;
    
    public int salaActiva;
    public int cambio;
    public bool puedeCambio;
    public bool mollyChoca;


    void Start()
    {
        puedeCambio = false;
        mollyChoca = false;
    }

    public void CambiaSala(int n)
    {
        MollyCosas.QuietaParaa();
        salaActiva = n;
        for(int i = 0; i<7 ; i++)
        {
            if((i+1) == n)
            {
                Salas[i].SetActive(true);
                Manos[i].SetActive(true);
            }else{
                Salas[i].SetActive(false);
                Manos[i].SetActive(false);
            }
        }
        
        puedeCambio = false;
        mollyChoca = false;
    }

    public void ClicEnLaManita(int n)
    {
        cambio = n;
        puedeCambio = true;
    }

    void Update()
    {
        if((MollyCosas.estaCaminando == false) && puedeCambio)
        {
            puedeCambio = false;
            mollyChoca = false;
        }

        if(puedeCambio && mollyChoca)
        {
            MollyCosas.MollyAparece();
            CambiaSala(cambio);
        }
    }
}
