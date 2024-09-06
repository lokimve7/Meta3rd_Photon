using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMgr : MonoBehaviourPunCallbacks
{
    // Input Room Name
    public TMP_InputField inputRoomName;
    // Input Max Player
    public TMP_InputField inputMaxPlayer;
    // Create Button
    public Button btnCreate;
    // Join Button
    public Button btnJoin;

    void Start()
    {
        // 로비 진입
        PhotonNetwork.JoinLobby();

        // inputRoomName 의 내용이 변경될 때 호출되는 함수 등록
        inputRoomName.onValueChanged.AddListener(OnValueChangedRoomName);
        // inputMaxPlayer 의 내용이 변경될 때 호출되는 함수 등록
        inputMaxPlayer.onValueChanged.AddListener(OnValueChangedMaxPlayer);
    }

    void Update()
    {
        
    }

    // 방이름과 최대인원의 값이 있을 때만 Create 버튼 활성화
    // 방이름에 값이 있으면 Join 버튼 활성화

    // Join & Create 버튼을 활성화 / 비활성
    void OnValueChangedRoomName(string roomName)
    {
        // join 버튼 활성 / 비활성
        btnJoin.interactable = roomName.Length > 0;

        // Create 버튼 활성화 / 비활성
        btnCreate.interactable = roomName.Length > 0 && inputMaxPlayer.text.Length > 0;
    }

    // Create 버튼을 활성화 / 비활성
    void OnValueChangedMaxPlayer(string maxPlayer)
    {
        // Create 버튼 활성화 / 비활성
        btnCreate.interactable = maxPlayer.Length > 0 && inputRoomName.text.Length > 0;
    }

    public void CreateRoom()
    {
        // 방 옵션 설정
        RoomOptions option = new RoomOptions();
        // 최대 인원 설정
        option.MaxPlayers = int.Parse(inputMaxPlayer.text);
        // 방 옵션을 기반으로 방을 생성
        PhotonNetwork.CreateRoom(inputRoomName.text, option);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("방 생성 완료");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("방 생성 실패 : " + message);
    }

    public void JoinRoom()
    {
        // 방 입장 요청
        PhotonNetwork.JoinRoom(inputRoomName.text);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("방 입장 완료");
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("방 입장 실패 : " + message);
    }


    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("로비 진입 성공!");
    }
}
