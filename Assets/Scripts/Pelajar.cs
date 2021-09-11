using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelajar : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    private Transform player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Sekolah").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        anim.SetBool("isRunning", false);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange){
            anim.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed* Time.deltaTime);
        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == ("Suntikan")){
            Debug.Log("Pelajar Selamat");
            Destroy(this.gameObject);
        }
    }
}
