using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCovid : MonoBehaviour
{
    [SerializeReference]
    private int darah;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (darah <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            darah -= 30;
        }
        if(collision.tag == "Suntikan")
        {
            darah -= 70;
        }
    }
}
