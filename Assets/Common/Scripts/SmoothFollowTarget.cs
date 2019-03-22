using System;
using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour
{
    private GameObject target;
    Vector3 offset;

    bool b;


    private void Awake()
    {
        CustomNetworkManager.Instance.eventLocalPlayerJoined.AddListener(HandleLocalPlayerJoined);
        enabled = false;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            target = PlayerNetworkState.LocalPlayer.gameObject;
            return;
        }
        else
        {
            if (!b)
            {
                offset = transform.position - target.transform.position;
                b = true;
            }

            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 5);
            return;
        }
    }

    public void HandleLocalPlayerJoined(PlayerNetworkState playerState)
    {
        target = playerState.gameObject;
        enabled = true;
    }
}

