using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform HfirePos;
    public Transform VfirePos;
    public GameObject bulletPrefabs;


    //Menggunakan RayCast
    [SerializeField]
    private int damage;
    [SerializeReference]
    private GameObject effectBullet;
    //public LineRenderer laser;

    public ParticleSystem shootAir;
    // Update is called once per frame

    Animator anim;
    private bool sedangShootWater;
    private bool sedangReloadWater;

    private bool shootTop;
    [SerializeField]
    private float cdShootTop;
    private float cdUpdate;
    private void Start()
    {
        cdUpdate = 0;
        shootTop = false;
        anim = GetComponent<Animator>();
        sedangShootWater = false;
    }

    void Update()
    {

        //Recovery Energy
        if (HealthPlayer.sedangRecovery)
        {
            stopShoot();
            GetComponent<HealthPlayer>().recoveryEnergy();
            anim.SetBool("isReload", true);
        }else
            anim.SetBool("isReload", false);

        //Menembak
        if (sedangShootWater && !HealthPlayer.sedangRecovery)
        {
            GetComponent<HealthPlayer>().kurangEnergi();
        }

        //Reload
        if (sedangReloadWater && !HealthPlayer.sedangRecovery && HealthPlayer.energyPlayer < 100)
        {
            anim.SetBool("isReload", true);
            GetComponent<HealthPlayer>().reloadEnergy();
        }
        else
            anim.SetBool("isReload", false);

        if (cdUpdate >= 0)
            cdUpdate -= Time.deltaTime;
        else
            cdUpdate = 0;

        if (shootTop && cdUpdate <= 0 && !HealthPlayer.sedangRecovery)
        {
            shoot();
            cdUpdate = cdShootTop;
            shootTop = false;
        }
    }



    void shoot()
    {
        GetComponent<HealthPlayer>().kurangEnergiBig();
        Instantiate(bulletPrefabs, VfirePos.position, VfirePos.rotation);
    }
    
    


    //Shoot Suntikan
    public void clickShootTop()
    {
        if(!HealthPlayer.sedangRecovery && cdUpdate <= 0)
            shootTop = true;
    }


    //Shoot water
    public void shootDown()
    {
        if (!HealthPlayer.sedangRecovery)
        {
            shootAir.gameObject.SetActive(true);
            shootAir.Play();
            sedangShootWater = true;

            anim.SetBool("isShoot", true);
        }
    }
    public void shootUp()
    {
        if (!HealthPlayer.sedangRecovery)
        {
            stopShoot();
        }
    }
    void stopShoot()
    {
        shootAir.Stop();
        sedangShootWater = false;
        StartCoroutine(stopShootWater());
    }
    IEnumerator stopShootWater()
    {
       
        yield return new WaitForSeconds(.1f);
        anim.SetBool("isShoot", false);
        shootAir.gameObject.SetActive(false);
        
    }


    //Reload
    public void reloadDown()
    {
        if(!HealthPlayer.sedangRecovery)
            sedangReloadWater = true;
    }
    public void reloadUp()
    {
        sedangReloadWater = false;
    }









    //Laser
/*    IEnumerator shootLaser()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(HfirePos.position, HfirePos.right);
        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.getDamage(damage);
            }

            Instantiate(effectBullet, hitInfo.point, Quaternion.identity);

            laser.SetPosition(0, HfirePos.position);
            laser.SetPosition(1, hitInfo.point);
        }
        else
        {

            laser.SetPosition(0, HfirePos.position);
            laser.SetPosition(1, HfirePos.position + HfirePos.right * 100);
        }

        laser.enabled = true;

        yield return new WaitForSeconds(0.3f);
        laser.enabled = false;

    }*/
}
