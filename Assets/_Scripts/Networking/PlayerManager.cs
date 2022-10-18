using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    int playerID;

    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();

        instance = this;
    }
    

    private void Start()
    {
        playerID = photonView.ViewID;

        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Vehicles", "Sedan"), GameObject.Find("sp" + playerID).transform.position, Quaternion.identity);
        }
    }
}
