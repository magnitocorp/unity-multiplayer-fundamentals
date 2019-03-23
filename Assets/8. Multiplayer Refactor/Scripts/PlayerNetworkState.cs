using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkState : NetworkBehaviour
{
    #region public properties field
    public static PlayerNetworkState LocalPlayer;
    public CharacterInventory characterInventory;
    public GameObject inventoryParent;
    #endregion

    private void Start()
    {
        if (isLocalPlayer)
            inventoryParent.transform.SetParent(transform.parent);
        else
            inventoryParent.SetActive(false);
    }

    #region user-defined methods

    #region handles SetDestination
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

    #region handles DoStomp
    public void HandleDoStomp(Vector3 destination)
    {
        // GetComponent<HeroController>().SetDestination(destination);
        CmdHandleDoStomp(destination);
    }

    [Command]
    public void CmdHandleDoStomp(Vector3 destination)
    {
        RpcHandleDoStomp(destination);
    }

    [ClientRpc]
    public void RpcHandleDoStomp(Vector3 destination)
    {
        // if (!isLocalPlayer) 
        GetComponent<HeroController>().DoStomp(destination);
    }
    #endregion

    #region handles StoreItems
    [Command]
    public void CmdStoreItem(string itemName)
    {
        RpcStoreItem(itemName);
    }

    [ClientRpc]
    public void RpcStoreItem(string itemName)
    {
        characterInventory.StoreItem(itemName);
    }
    #endregion

    #region handles ItemUse

    [Command]
    public void CmdTriggerItemUse(int itemID)
    {
        RpcTriggerItemUse(itemID);
    }

    [ClientRpc]
    public void RpcTriggerItemUse(int itemID)
    {
       characterInventory.TriggerItemUse(itemID);
    }

    #endregion

    #region handles TryPickUp

    [Command]
    public void CmdTryPickUp()
    {
        RpcTryPickUp();
    }

    [ClientRpc]
    public void RpcTryPickUp()
    {
        characterInventory.TryPickUp();
    }

    #endregion

    #region handles UseItemInstant

    [Command]
    public void CmdUseItemInstant(string itemToUseID)
    {
        RpcUseItemInstant(itemToUseID);
    }

    [ClientRpc]
    public void RpcUseItemInstant(string itemToUseID)
    {
        ItemPickUps_SO itemPickUps_SO = ItemPickupCache.Instance.GetItemByName(itemToUseID);
        ItemPickUp itemToUse = Instantiate(itemPickUps_SO.itemSpawnObject).GetComponent<ItemPickUp>();
        itemToUse.charStats = GetComponent<CharacterStats>();
        itemToUse.itemDefinition = itemPickUps_SO;
        itemToUse.UseItem();
    }

    #endregion

    #endregion

    #region override methods

    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;
    }


    #endregion
}
