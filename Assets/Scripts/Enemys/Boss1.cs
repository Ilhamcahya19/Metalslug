using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss1 : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject Winner;
    public float health;
    public Slider healthBar;
    public GameObject healthUI;

    public Transform target;

    public Transform shootPos;

    public GameObject childCovid;

    //bool detected;

    Vector2 direction;


    [SerializeReference]
    private float fireTimeDelay;
    private float fireUpdate;
    [SerializeReference]
    private float speedShoot;


    void Start()
    {
        healthUI.SetActive(true);
        fireUpdate = fireTimeDelay;
        //detected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            gameplay.SetActive(false);
            Time.timeScale = 0;
            Winner.SetActive(true);
        }
        healthBar.value = health;

        Vector2 targetPos = target.position;

        direction = targetPos - (Vector2) transform.position;

        //RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);
        fireUpdate -= Time.deltaTime;
        if (fireUpdate <= 0)
        {
            shoot();
            fireUpdate = fireTimeDelay;
        }

    }

    void shoot()
    {
        GameObject bulletInst = Instantiate(childCovid, shootPos.position, Quaternion.identity);
        bulletInst.GetComponent<Rigidbody2D>().AddForce(direction * speedShoot);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(transform.position, range); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            health -= 50;
        }
        if(collision.tag == "Suntikan")
        {
            health -= 100;
        }
    }
}
