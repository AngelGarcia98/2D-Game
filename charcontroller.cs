using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charcontroller : MonoBehaviour
{

    public float velocidad;
    public float fuerzaSalto;
    private Rigidbody2D rigidBody;
    public LayerMask capaSuelo;
    public float saltosMaximos;
    private BoxCollider2D boxcolider;
    private bool mirandoDerecha = true;
    private float saltosRstantes;
    private Animator animator;


    // Update is called once per frame
    private void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        boxcolider = GetComponent<BoxCollider2D>();
        saltosRstantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    bool EstaEnElSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcolider.bounds.center, new Vector2(boxcolider.bounds.size.x, boxcolider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    void ProcesarSalto()
    {
        if (EstaEnElSuelo())
        {
            saltosRstantes = saltosMaximos;
        }
        if (Input.GetKeyDown(KeyCode.Space) && saltosRstantes > 0)
        {
            saltosRstantes = saltosRstantes - 1;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }



    void Update()
    {
        movimiento();
        ProcesarSalto();
    }



    void movimiento()
    {

        float inputMovimiento = Input.GetAxis("Horizontal");
        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        gestionarOrientacion(inputMovimiento);
    }
    void gestionarOrientacion(float inputMovimiento)
    {
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


}
