using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class OnlineMatchmaker : Manager<OnlineMatchmaker>
{

    #region private properties field

    [SerializeField]
    private CustomNetworkManager customNetworkManager;

    [SerializeField]
    private int maxPlayers = 4;

    private int serverListenPort = 9000;
    #endregion

    #region MonoBehavior callbacks
    // Start is called before the first frame update
    void Start()
    {
        customNetworkManager.StartMatchMaker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region user-defined methods

    public void HandleJoinOrCreateMatch()
    {
        customNetworkManager.matchMaker.ListMatches(0, 10, "", false, 0, 0, OnMatchListed);
    }

    void OnMatchListed(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
    {
        if (success)
        {
            if (responseData.Count > 0)
            {
                customNetworkManager.matchMaker.JoinMatch(responseData[responseData.Count - 1].networkId, "", "", "", 0, 0, OnJoinInternetMatch);
            }
            else
                CreateMatchAndStartHost();
        }
    }

    void CreateMatchAndStartHost()
    {
        customNetworkManager.matchMaker.CreateMatch("", (uint)maxPlayers, true, "", "", "", 0, 0, OnCreateInternetMatch);
    }

    void OnCreateInternetMatch(bool success, string extendedInfo, MatchInfo responseData)
    {
       if (success)
        {
            NetworkServer.Listen(responseData, serverListenPort);
            customNetworkManager.StartHost(responseData);
            customNetworkManager.ServerChangeScene("Main");
        }
    }

    void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo responseData)
    {
       if (success)
        {
            customNetworkManager.StartClient(responseData);
        }
    }

    #endregion
}
