using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPlayer : MonoBehaviour
{

    public GameObject dead;
    private int healthPlayer;
    public static float energyPlayer;
    public Text health;
    public Text energy;
    public Slider healthSlider;
    public Slider energySlider;


    private Animator anim;

    public static bool sedangRecovery = false;
    public void tambahDarah()
    {
        healthPlayer = 100;
    }
    public void darahBerkurangDikit()
    {
        anim = GetComponent<Animator>();
        healthPlayer -= 12;
    }
    public void darahBerkurangBanyak()
    {
        healthPlayer -= 28;
    }
    public void darahHabis()
    {
        int temp = healthPlayer;
        healthPlayer -= temp;
    }
    private void Start()
    {
        healthPlayer = 100;
        energyPlayer = 100;
    }
    private void Update()
    {
        if(healthPlayer <= 0)
        {
            Time.timeScale = 0;
            dead.SetActive(true);
        }

        healthSlider.value = healthPlayer;
        health.text = healthPlayer + "%";

        if (energyPlayer >= 100)
        {
            energyPlayer = 100;
            sedangRecovery = false;
        }
        if (energyPlayer <= 0)
        {
            energyPlayer = 0;
            sedangRecovery = true;
        }
        energySlider.value = energyPlayer;
        energy.text = ((int) energyPlayer) + "%";
    }
   

    public void kurangEnergi()
    {
        energyPlayer -= 35 * Time.deltaTime;
    }
    public void kurangEnergiBig()
    {
        energyPlayer -= 45;
    }
    public void tambahEnergiBig()
    {
        energyPlayer = 100;
    }
    public void reloadEnergy()
    {
        energyPlayer += 15 * Time.deltaTime;
    }
    public void recoveryEnergy()
    {
        
        energyPlayer += 10 * Time.deltaTime;
    }

}
