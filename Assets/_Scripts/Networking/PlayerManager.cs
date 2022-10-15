using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();

        instance = this;
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Vehicles", "Sedan"), Vector3.zero, Quaternion.identity);
        }
    }
}
