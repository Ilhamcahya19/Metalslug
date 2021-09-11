using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBoss1 : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthPlayer>().darahBerkurangBanyak();
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Suntikan" || collision.tag != "Water")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
