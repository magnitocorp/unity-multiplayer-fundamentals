using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    #region private properties field

    #endregion

    #region public properties field
    public const string ConnectionBroadcastMessage = "ConnectionBroadcastMessage";
    public const char BroadcastMessageDelimiter = ' ';
    #endregion

    #region singleton instance

    //Creating a singleton instance.
    private static CustomNetworkManager instance;

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

    #endregion

    #region override methods

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        SetupNewPlayer(conn, playerControllerId);
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);
        GameManager.Instance.UpdateLevel(sceneName);
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        if (!conn.isReady) base.OnClientSceneChanged(conn);
        GameManager.Instance.UpdateLevel(networkSceneName);
    }

    #endregion

    #region user-defined methods

    void SetupNewPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    public string GenerateNetworkBroadcastData()
    {
        return string.Format("{0} : {1}", ConnectionBroadcastMessage, networkPort);
    }

    #endregion
}
