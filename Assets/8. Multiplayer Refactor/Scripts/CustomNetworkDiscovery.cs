using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery
{
    #region private properties field
    private CustomNetworkManager customNetworkInstance;
    #endregion

    #region public properties field

    #endregion

    #region singleton instance

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

    #endregion

    #region MonoBehavior callbacks

    void Start()
    {
        customNetworkInstance = CustomNetworkManager.Instance;
        broadcastData = customNetworkInstance.GenerateNetworkBroadcastData();
        Initialize();
    }

    #endregion

    #region Override methods

    // getting the data port from the server.
    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        if (data.Contains(CustomNetworkManager.ConnectionBroadcastMessage))
        {
            string[] datas = data.Split(' ');

            if (customNetworkInstance != null && customNetworkInstance.client == null)
            {
                Debug.LogError("Attempting to connect from: " + fromAddress);

                int port;
                customNetworkInstance.networkAddress = fromAddress;

                if (int.TryParse(datas[2], out port))
                {
                    Debug.LogError("Connected Succesful: Port:" + port);
                    customNetworkInstance.networkPort = port;
                    customNetworkInstance.StartClient();
                }
                else
                    Debug.LogError("Cannot parse trying to be networkPort");
            }  
        }
    }

    #endregion
}
