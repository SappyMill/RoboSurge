using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : BatteryPowered
{
    public GameObject arrow;
    private float shootTime, timer;

    // Start is called before the first frame update
    void Start()
    {
        battery = FindBattery();
        shootTime = timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCharged(transform.position);
        
        if(isCharged)
        {
            if(timer == shootTime)
            {
                Instantiate(arrow,transform.position,Quaternion.identity);
            }
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if(timer < 0)
            {
                timer = shootTime;
            }
        }
    }
}
