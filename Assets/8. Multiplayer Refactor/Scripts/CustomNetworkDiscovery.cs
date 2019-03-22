using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery
{
    private static CustomNetworkDiscovery instance;

    //Creating a singleton instance.
    public static CustomNetworkDiscovery Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CustomNetworkDiscovery>();
            }
            return instance;
        }
    }

    void Start()
    {
        Initialize();
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        base.OnReceivedBroadcast(fromAddress, data);

        Debug.LogFormat("Received Broadcast!:: from {0} data {1}", fromAddress, data);
    }
}
