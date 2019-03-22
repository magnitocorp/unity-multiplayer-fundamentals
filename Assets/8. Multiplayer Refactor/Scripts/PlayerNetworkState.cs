using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkState : NetworkBehaviour
{
    #region public properties field
    public static PlayerNetworkState LocalPlayer;
    #endregion

    #region user-defined methods

    public void HandleSetDestination(Vector3 destination)
    {
      // GetComponent<HeroController>().SetDestination(destination);
        CmdHandleSetDestination(destination);
    }

    [Command]
    public void CmdHandleSetDestination(Vector3 destination)
    {
        RpcHandleSetDestination(destination);
    }

    [ClientRpc]
    public void RpcHandleSetDestination(Vector3 destination)
    {
       // if (!isLocalPlayer) 
        GetComponent<HeroController>().SetDestination(destination);
    }

    #endregion

    #region override methods

    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;
    }

    #endregion
}
