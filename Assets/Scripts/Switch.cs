using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : BatteryPowered
{

    public GameObject switchPowered;
    // Start is called before the first frame update
    void Start()
    {
        battery = FindBattery();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCharged(this.transform.position);
    }

    public override void Interact()
    {
        if (isCharged)
        {
            switchPowered.GetComponent<SwitchPowered>().Activate();
        }
    }
}
