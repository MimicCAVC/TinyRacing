using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] Transform[] spawnPos;
    bool isUsed = false;

    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();

        instance = this;
    }
    

    private void Start()
    {
        for (int i = 0; i < spawnPos.Length; i++)
        {
            
        }

        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Vehicles", "Sedan"), Vector3.zero, Quaternion.identity);
        }
    }
}
