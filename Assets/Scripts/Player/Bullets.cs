using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeReference]
    private float speedBullet;
    [SerializeReference]
    private Rigidbody2D rB;

    [SerializeField]
    private int damage;
    [SerializeReference]
    private GameObject effectBullet;
    void Start()
    {
        rB.velocity = transform.up * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(effectBullet, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
