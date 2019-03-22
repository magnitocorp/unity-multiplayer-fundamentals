using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    #region private properties field
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

    public void StartSinglePlayer()
    {
        //GameManager.Instance.StartGame();
        networkManager.StartHost();
        networkManager.ServerChangeScene("Main");
    }

    public void StartLANHost()
    {
        networkManager.StartHost();
        networkDiscovery.StartAsServer();
        networkManager.ServerChangeScene("Main");
        //GameManager.Instance.StartGame();
    }

    public void StartLANClient()
    {
        networkDiscovery.StartAsClient();
        //GameManager.Instance.StartGame();
    }

    public void StartInternetMatch()
    {
        OnlineMatchmaker.Instance.HandleJoinOrCreateMatch();
    }

    #endregion
}
