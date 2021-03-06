﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeUIManager : MonoBehaviour
{


    #region private properties field
    [SerializeField]
    private GameObject UIParent;
    private CustomNetworkDiscovery networkDiscovery;
    private CustomNetworkManager networkManager;
    #endregion

    #region MonoBehavior callbacks

    // Start is called before the first frame update
    void Start()
    {
        networkManager = CustomNetworkManager.Instance;
        networkDiscovery = CustomNetworkDiscovery.Instance;
    }

    #endregion

    #region user-defined methods

    public void StartHost()
    {
        networkManager.StartHost();
        networkDiscovery.StartAsServer();
        DisableButtons();
    }

    public void StartClient()
    {
        networkDiscovery.StartAsClient();
        DisableButtons();
    }

    void DisableButtons()
    {
        UIParent.SetActive(false);
    }

    #endregion
}
