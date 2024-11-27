using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyMovement : MonoBehaviour
{
    [SerializeField] private GameObject Molly;
    [SerializeField] private Controladordesalas admin;

    public int velocidad;
    public float tolerancia;
    
    public bool puedeCaminar;
    public bool estaCaminando;
    public bool estaHablando;
    private Animator anim;

    float angulo;
    float cosa;
    float sina;
    float px;
    float py;

    
    float newXXX;
    float newYYY;

    void Start()
    {
        anim = Molly.GetComponent<Animator>();
        estaHablando = false;
        estaCaminando = false;
        puedeCaminar = true;
    } 

    public void QuietaParaa()
    {
        estaCaminando = false;
        puedeCaminar = true;
    }

    public void PerraQuieta()
    {
        estaCaminando = false;
        puedeCaminar = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Estorbo") && estaCaminando)
        {
            Molly.transform.position -= new Vector3(px * cosa * velocidad, py * sina * velocidad, 0.0f) * 2;
            StopAllCoroutines();
            QuietaParaa();
        }
        if (collision.gameObject.CompareTag("Manita") && estaCaminando)
        {
            admin.mollyChoca = true;
        }
        /*
        if (collision.gameObject.CompareTag("Item") && estaCaminando) //esto no lo he usado ////////////////////////////////////////
        {
            Molly.transform.position -= new Vector3(px * cosa * velocidad, py * sina * velocidad, 0.0f) * 2;
            StopAllCoroutines();
            PerraQuieta();
        }*/
    }

    IEnumerator MuevetePerra(float xx, float yy)
    {
        angulo = Mathf.Atan2((yy - Molly.transform.position.y), (xx - Molly.transform.position.x));
        cosa = Mathf.Abs(Mathf.Cos(angulo));
        sina = Mathf.Abs(Mathf.Sin(angulo));

        px = Mathf.Sign(xx - Molly.transform.position.x);
        py = Mathf.Sign(yy - Molly.transform.position.y);

        Molly.transform.localScale = new Vector3(Mathf.Abs(Molly.transform.localScale.x) * (-1) * px, Molly.transform.localScale.y, Molly.transform.localScale.z);


        while (estaCaminando)
        {
            Molly.transform.position += new Vector3(px * cosa * velocidad, py * sina * velocidad, 0.0f);
            if (Mathf.Abs(Molly.transform.position.x - xx) < tolerancia && Mathf.Abs(Molly.transform.position.y - yy) < tolerancia)
            {
                estaCaminando = false;
            }

            yield return new WaitForSeconds(0.01f);
        }

        puedeCaminar = true;
    } 

    void Update()
    {
        Vector3 destino = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destino.z = 0;
        if (Input.GetMouseButtonDown(0) && puedeCaminar && (destino.y < 850) && !estaHablando)
        {
            puedeCaminar = false;
            estaCaminando = true;

            StartCoroutine(MuevetePerra(destino.x, destino.y));
        }

        if (estaCaminando)
        {
            anim.SetBool("camina", true);
        }else
        {
            anim.SetBool("camina", false);
        }
    }


    public void SetX(float xxx)
    {
        newXXX = xxx;
    }
    public void SetY(float yyy)
    {
        newYYY = yyy;
    }
    public void MollyAparece()
    {
        QuietaParaa();
        Molly.transform.position = new Vector3(newXXX, newYYY, 0.0f);
    }

}