using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyhsicPlayer : MonoBehaviour
{
    public static int terselamatkan = 0;
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.transform.tag == "Enemy")
        {
            GetComponent<HealthPlayer>().darahBerkurangDikit();
        }
        if (target.transform.tag == "BosEnemy")
        {
            GetComponent<HealthPlayer>().darahHabis();
        }
        if (target.transform.tag == "Help")
        {
            target.transform.GetComponent<HelpPeople>().selamat();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "ItemWater")
        {
            GetComponent<HealthPlayer>().tambahEnergiBig();
            Destroy(target.gameObject);
        }
        if (target.tag == "ItemHealth")
        {
            GetComponent<HealthPlayer>().tambahDarah();
            Destroy(target.gameObject);
        }
    }
}
