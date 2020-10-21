using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public GameObject manager;
    public GameObject battery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        manager.GetComponent<Manager>().PlayerDied(battery);
        this.gameObject.SetActive(false);

    }
}
