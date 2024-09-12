using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingMgr : MonoBehaviour
{
    // PlayerWaiting Prefab
    public GameObject playerWaitingFatory;

    // 나의 해당되는 PlayerWaiting 을 가지고 있는 변수
    public PlayerWaiting myPlayer;

    void Start()
    {
        // 현재 방의 최대 인원
        int max = 4;
        
        // 내가 몇번째로 들어왔는지
        int idx = 0;

        // 캐릭터들 간의 간격
        float distance = 3;        

        // 만약에 내가 포톤에 접속 되어 있다면 
        if(PhotonNetwork.IsConnected)
        {
            // max 값을 방의 최대 인원
            max = PhotonNetwork.CurrentRoom.MaxPlayers;
            // idx 값을 내가 몇번째 들어왔는지
            idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        }

        // 총길이 / 2
        float xDist = (max - 1) * distance * 0.5f;

        // idx 에 따라서 좌표를 구하자.
        Vector3 pos = new Vector3(idx * distance - xDist, 0, 0);

        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerWaitingFatory.name, pos, Quaternion.identity);
        }
        else
        {
            // 플레이어 생성
            Instantiate(playerWaitingFatory, pos, Quaternion.identity);
        }

    }

    void Update()
    {
        
    }

    public void OnClickReady()
    {
        // 나에 해당되는 캐릭터의 SetReady 함수를 호출하자.
        myPlayer.SetReady();
    }
}
