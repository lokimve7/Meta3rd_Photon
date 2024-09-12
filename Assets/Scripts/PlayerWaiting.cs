using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWaiting : MonoBehaviourPun
{
    // 닉네임 UI
    public TMP_Text nickName;

    void Start()
    {
        // 닉네임 UI 에 표시
        nickName.text = photonView.Owner.NickName;   
        
        // 내것이라면
        if(photonView.IsMine)
        {
            // WaitingMgr 에게 나를 알려주자.
            GameObject go = GameObject.Find("WaitingManager");
            WaitingMgr mgr = go.GetComponent<WaitingMgr>();
            mgr.myPlayer = this;
        }
    }

    void Update()
    {
        
    }

    public void SetReady()
    {
        photonView.RPC(nameof(RpcSetReady), RpcTarget.All);
    }

    [PunRPC]
    void RpcSetReady()
    {
        // nickName 색을 파란색으로 설정
        nickName.color = Color.blue;
    }
}
