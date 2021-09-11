using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HelpPeople : MonoBehaviour
{
    private Animator anim;
    private bool isSelamat;

    private Rigidbody2D rB;

    [SerializeReference]
    private float speedMove;
    private void Start()
    {
        isSelamat = false;
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isSelamat) 
        { 
            transform.position = new Vector2(rB.position.x - 8 * Time.deltaTime, rB.position.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void selamat()
    {
        StartCoroutine(mulaiSelamat());
    }

    IEnumerator mulaiSelamat()
    {
        yield return new WaitForSeconds(.5f);
        isSelamat = true;
        anim.SetBool("Selamat", true);
    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Batas")
        {
            Destroy(gameObject);
        }
    }
}
