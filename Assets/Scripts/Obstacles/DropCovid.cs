using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCovid : MonoBehaviour
{
    public GameObject covids;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            covids.SetActive(true);
            Destroy(gameObject);
        }
    }
}
