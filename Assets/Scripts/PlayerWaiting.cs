using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWaiting : MonoBehaviourPun
{
    public Transform trNickPos;

    public GameObject textNickFactory;

    GameObject go;
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        go = Instantiate(textNickFactory, canvas.transform);
        go.GetComponent<TMP_Text>().text = photonView.Owner.NickName;

        Vector3 pos = Camera.main.WorldToScreenPoint(trNickPos.position);
        pos.x -= Screen.width * 0.5f;
        pos.y -= Screen.height * 0.5f;
        go.GetComponent<RectTransform>().anchoredPosition = pos;

        if(photonView.IsMine)
        {
            WaitingMgr.instance.myPlayer = this;
        }
    }

    void Update()
    {
    }

    public void SetReady()
    {
        photonView.RPC(nameof(RpcSetReady), RpcTarget.AllBuffered);
    }

    [PunRPC]
    void RpcSetReady()
    {
        go.GetComponent<TMP_Text>().color = Color.blue;

        if(PhotonNetwork.IsMasterClient)
        {
            WaitingMgr.instance.readyCount++;
            if(WaitingMgr.instance.readyCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                PhotonNetwork.LoadLevel("GameScene");   
            }
        }
    }
}
