using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public void PlayerDied(GameObject battery)
    {
        battery.GetComponent<BatteryScript>().Death();
        for(int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<PlayerController>().Death();
        }
    }
}
