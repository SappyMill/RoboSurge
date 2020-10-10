using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{

    public GameObject playerOneSpawn, playerTwoSpawn;
    private PlayerInputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        inputManager.playerPrefab.transform.position = playerOneSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlayerJoined()
    {
        inputManager.playerPrefab.transform.position = playerTwoSpawn.transform.position;  
    }
}
