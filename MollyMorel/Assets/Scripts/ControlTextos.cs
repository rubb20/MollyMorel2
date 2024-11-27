using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlTextos : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI textoDialogo;
    [SerializeField] private GameObject[] carasHablantes;

    [SerializeField] private MollyMovement Molly;
    
    private string [] arrayTextos;
    private int [] hablantes;
    
    private float typingTime = 0.05f;
    private int lineIndex;
    private bool didDialogueStart;
    
    void Awake()
    {
        //textoDialogo = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        lineIndex = 0;
        dialoguePanel.SetActive(false);
        didDialogueStart = false;
    }

    public void PuesTocaHablar(string[] s, int[] n) //con esto le mando cuando hay que hablar
    {
        Molly.PerraQuieta();
        Molly.estaHablando = true;

        arrayTextos = s;
        hablantes = n;
        StartDialogue();
    }

    void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        //MostrarCaras(); /////////////////////////////////////////////////////////////////////////////////////////////////////////
        StartCoroutine(ShowLine());
    }
    void Update()
    {
        if (didDialogueStart && Input.GetMouseButtonDown(0) && (lineIndex < arrayTextos.Length))
        {
            dialoguePanel.SetActive(true); 
            if(textoDialogo.text == arrayTextos[lineIndex])
            {
                ActivarCartel();
            }else
            {
                StopAllCoroutines();
                textoDialogo.text = arrayTextos[lineIndex];
            }
        }
    }
    void ActivarCartel()
    {
        lineIndex ++;
        if (lineIndex < arrayTextos.Length)
        {
            //MostrarCaras();  //////////////////////////////////////////////////////////////////////////////////////////
            StartCoroutine(ShowLine());
        }
        else
        {
            dialoguePanel.SetActive(false); 
            didDialogueStart = false;

            Molly.estaHablando = false;
            Molly.QuietaParaa();
        }
    }

    private IEnumerator ShowLine()
    {
        textoDialogo.text = string.Empty;
        foreach(char ch in arrayTextos[lineIndex])
        {
            textoDialogo.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    void MostrarCaras()
    {
        for(int i = 0; i < carasHablantes.Length; i++)
        {
            if(i == hablantes[lineIndex])
            {
                carasHablantes[i].SetActive(true); 
            }else
            {
                carasHablantes[i].SetActive(false); 
            }
        }

        /* LISTA DE NUMEROS ASOCIADOS A LAS CARAS
        -1. Ninguno
        0.
        1.
        2.
        3.
        4.
        5.
        6.
        7.
        8.
        9.
        10.
        ...

        */
    }
}
