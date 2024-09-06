﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ConnectionMgr : MonoBehaviourPunCallbacks
{
    // InputNickName
    public TMP_InputField inputNickName;
    // BtnConnect
    public Button btnConnect;

    void Start()
    {
        // inputNickName 의 내용이 변경될 때 호출되는 함수 등록
        inputNickName.onValueChanged.AddListener(OnValueChanged);
    }

    void Update()
    {
        
    }

    void OnValueChanged(string s)
    {
        btnConnect.interactable = s.Length > 0;

        //// 만약에 s 의  길이가 0보다 크면
        //if(s.Length > 0)
        //{
        //    // 접속 버튼을 활성화
        //    btnConnect.interactable = true;
        //}
        //// 그렇지 않으면 (s 의 길이가 0)
        //else
        //{
        //    // 접속 버튼을 비활성화
        //    btnConnect.interactable = false;
        //}
    }

    public void OnClickConnect()
    {
        // 마스터 서버에 접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // 마스터 서버에 접속 성공하면 호출되는 함수
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        // 닉네임 설정
        PhotonNetwork.NickName = inputNickName.text;
        // 로비씬으로 전환
        PhotonNetwork.LoadLevel("LobbyScene");
    }
}
