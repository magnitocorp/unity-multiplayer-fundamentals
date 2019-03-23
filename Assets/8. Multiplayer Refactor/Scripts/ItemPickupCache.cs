/*
 * Created by - Symsey Cruz.
 */

using UnityEngine;
using System.Collections.Generic;

public class ItemPickupCache : Manager<ItemPickupCache>
{

    #region private properties fields

    Dictionary<string, ItemPickUps_SO> itemPickupCache;

    #endregion

    #region public properties fields

    #endregion

    #region inherited functions	

    void Start()
    {
        itemPickupCache = new Dictionary<string, ItemPickUps_SO>();
        ItemPickUps_SO[] itemPickUps_SOs = Resources.LoadAll<ItemPickUps_SO>("ItemDropData");
        foreach (ItemPickUps_SO so in itemPickUps_SOs)
        {
            itemPickupCache.Add(so.itemName, so);
        }
    }

    #endregion

    #region override functions

    #endregion

    #region user-defined functions

    public ItemPickUps_SO GetItemByName(string name)
    {
        return itemPickupCache[name];
    }

    #endregion

}
