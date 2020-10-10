using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BatteryPowered
{
    private Vector3 startPosition;
    [SerializeField]
    private Vector3 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        battery = FindBattery();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCharged(transform.position);
        if(isCharged)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -5.0f, transform.position.z), 0.05f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 0.05f);
        }
    }
}
