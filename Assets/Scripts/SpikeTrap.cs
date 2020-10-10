using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : BatteryPowered
{
    private Vector3 startPos;
    private bool reachedHeight;

    [SerializeField]
    private Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        battery = FindBattery();
        reachedHeight = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCharged(transform.position);
        if (isCharged)
        {
            EnableSpikes();
            if (!reachedHeight && transform.position.y == startPos.y)
            {
                reachedHeight = true;
            }
            if(reachedHeight && transform.position.y == endPos.y)
            {
                reachedHeight = false;
            }
        }
    }

    private void EnableSpikes()
    {
        if (reachedHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(endPos.x, endPos.y, endPos.z), 0.02f);
        }
        if (!reachedHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x, startPos.y, startPos.z), 0.02f);
        }
    }
}
