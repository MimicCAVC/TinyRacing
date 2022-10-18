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

    int localPlayerIndex;

    PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();

        instance = this;
    }
    

    private void Start()
    {
        localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber;

        if (photonView.IsMine)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                if (spawnPos[i].gameObject.name == "sp" + localPlayerIndex)
                {
                    PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Vehicles", "Sedan"), spawnPos[i].position, Quaternion.identity);
                }
            }
        }
    }
}
