using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPowered : MonoBehaviour
{
    public bool isCharged;
    public float chargedDistance = 7.0f;
    public GameObject battery;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    virtual public void Interact()
    {

    }

    public GameObject FindBattery()
    {
        return GameObject.FindGameObjectWithTag("Battery");
    }

    public void CheckIfCharged(Vector3 position)
    {
        if (Vector3.Distance(position, battery.transform.position) < chargedDistance)
        {
            isCharged = true;
        }
        else
        {
            isCharged = false;
        }
    }
}
