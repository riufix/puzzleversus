using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetCodeUI : MonoBehaviour
{
    [SerializeField] private Button _startHostBtn;
    [SerializeField] private Button _startClientBtn;

    private void Awake()
    {
        _startHostBtn.onClick.AddListener(() =>{
            Debug.Log("Host");
            NetworkManager.Singleton.StartHost();
        });

        _startClientBtn.onClick.AddListener(() => {
            Debug.Log("Client");
            NetworkManager.Singleton.StartClient();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
