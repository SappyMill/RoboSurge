using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : SwitchPowered
{
    private bool movingUp;
    private Vector3 startPos;
    [SerializeField]
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        movingUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x, startPos.y + height, startPos.z), 0.02f);
        }
        if(!movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x, startPos.y, startPos.z), 0.02f);
        }
    }

    public override void Activate()
    {
        movingUp = !movingUp;
    }
}
