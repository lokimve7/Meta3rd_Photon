using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingMgr : MonoBehaviour
{
    public static WaitingMgr instance;

    public GameObject playerInWaitingFactory;

    public PlayerWaiting myPlayer;

    public int readyCount;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        int max = 3;
        int idx = 0;
        if(PhotonNetwork.IsConnected)
        {
            max = PhotonNetwork.CurrentRoom.MaxPlayers;
            idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        }
        
        float interval = 3;

        float startPosX = -(max - 1) * interval * 0.5f;

        Vector3 pos = new Vector3(startPosX + idx * interval, 0, 0);

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerInWaitingFactory.name, pos, Quaternion.identity);
        }
        else
        {
            Instantiate(playerInWaitingFactory, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }

    public void OnClickReady()
    {
        myPlayer.SetReady();
    }
}
