using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    private bool isCarrried;
    private GameObject carrier;
    private Rigidbody rb;
    private float force = 500;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        isCarrried = false;
        carrier = null;
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCarrried)
        {
            transform.position = new Vector3(carrier.transform.position.x, carrier.transform.position.y + 1.5f, carrier.transform.position.z);
        }
    }

    public void PickUp(GameObject gameObject)
    {
        isCarrried = true;
        carrier = gameObject;
    }

    public void Dropped()
    {
        isCarrried = false;
        carrier = null;
    }

    public void Thrown(GameObject thrower)
    {
        isCarrried = false;
        carrier = null;
        rb.AddForce(new Vector3(thrower.transform.forward.x, thrower.transform.forward.y + 1, thrower.transform.forward.z) * force);
    }

    public void Death()
    {
        transform.position = startPos;
        isCarrried = false;
        carrier = null;
    }
}
