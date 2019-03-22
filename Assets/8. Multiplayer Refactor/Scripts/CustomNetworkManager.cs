using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    private static CustomNetworkManager instance;

    //Creating a singleton instance.
    public static CustomNetworkManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CustomNetworkManager>();
            }
            return instance;
        }
    }
}
