using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyMovement : MonoBehaviour
{
    [SerializeField] private GameObject Molly;
    public int velocidad;
    public float tolerancia;
    private bool puedeCaminar;
    private bool estaCaminando;
    float angulo;
    float cosa;
    float sina;
    float px;
    float py;

    void Start()
    {
        estaCaminando = false;
        puedeCaminar = true;
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Estorbo") && estaCaminando)
        {
            Molly.transform.position -= new Vector3(px * cosa * velocidad, py * sina * velocidad, 0.0f) * 2;
            StopAllCoroutines();
            estaCaminando = false;
            puedeCaminar = true;
        }
    }

    IEnumerator MuevetePerra(float xx, float yy)
    {
        //////////////////////////////////////////////////////////////////
        ////// ANIMATION
        //////////////////////////////////////////////////////////////////

        angulo = Mathf.Atan2((yy - Molly.transform.position.y), (xx - Molly.transform.position.x));
        cosa = Mathf.Abs(Mathf.Cos(angulo));
        sina = Mathf.Abs(Mathf.Sin(angulo));

        px = Mathf.Sign(xx - Molly.transform.position.x);
        py = Mathf.Sign(yy - Molly.transform.position.y);

        

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
        if (Input.GetMouseButtonDown(0) && puedeCaminar)
        {
            puedeCaminar = false;
            estaCaminando = true;

            Vector3 destino = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destino.z = 0;

            StartCoroutine(MuevetePerra(destino.x, destino.y));
        }
    }
}