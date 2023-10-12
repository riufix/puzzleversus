using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class playerController : MonoBehaviour
{
    public static playerController Instance;

    private PlayerInput playerInput;

    private void Awake()
    {
        // Initialize variables
        Instance = this;
        playerInput = GetComponent<PlayerInput>();
    }

    public PlayerInput GetPlayerInput() { return playerInput; }

}