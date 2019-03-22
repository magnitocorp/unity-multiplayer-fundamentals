using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeUIManager : MonoBehaviour
{
    public GameObject UIParent;

    private CustomNetworkDiscovery networkDiscovery;
    private CustomNetworkManager networkManager;


    // Start is called before the first frame update
    void Start()
    {
        networkManager = CustomNetworkManager.Instance;
        networkDiscovery = CustomNetworkDiscovery.Instance;
    }

    public void StartHost()
    {
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
}
