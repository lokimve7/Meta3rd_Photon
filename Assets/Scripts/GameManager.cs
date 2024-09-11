using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;

    // Spawn 위치를 담아놓을 변수
    public Vector3[] spawnPos;
    public Transform spawnCenter;

    public int currTurn = -1;
    public List<PhotonView> allPlayer = new List<PhotonView>();

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetSpawnPos();

        // RPC 보내는 빈도 설정
        PhotonNetwork.SendRate = 60;
        // OnPhotonSerializeView 보내고 받고 하는 빈도 설정
        PhotonNetwork.SerializationRate = 60;

        // 내가 위치해야 하는 idx 를 알아오자. ( 현재 방의 들어와 있는 인원 수 )
        int idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        // 플레이어를 생성 (현재 Room 에 접속 되어있는 친구들도 보이게)
        PhotonNetwork.Instantiate("Player", spawnPos[idx], Quaternion.identity);          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void SetSpawnPos()
    {
        // maxPlayer 를 현재 방의 최대 인원으로 설정
        int maxPlayer = PhotonNetwork.CurrentRoom.MaxPlayers;

        // 최대 인원 만큼 spawnPos 의 공간을 할당
        spawnPos = new Vector3[maxPlayer];

        // spawnPos 간의 간격(각도)
        float angle = 360.0f / maxPlayer;

        // maxPlayer 만큼 반복
        for(int i = 0; i < maxPlayer; i++)
        {
            // spawnCenter 회전 (i * angle) 만큼
            spawnCenter.eulerAngles = new Vector3(0, i * angle, 0);
            // spawnCenter 앞방향으로 2만큼 떨어진 위치 구하자.
            spawnPos[i] = spawnCenter.position + spawnCenter.forward * 2;
            //// 큐브 하나 생성
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //// 생성된 큐브를 위에서 구한 위치에 놓자.
            //cube.transform.position = spawnPos[i];
        }
    }

    public void AddPlayer(PhotonView pv)
    {
        allPlayer.Add(pv);

        if(allPlayer.Count == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                ChangeTurn();
            }
        }
    }

    public void ChangeTurn()
    {
        photonView.RPC(nameof(RpcChangeTurn), RpcTarget.MasterClient);
    }

    [PunRPC]
    void RpcChangeTurn()
    {
        PlayerFire pf;

        if (currTurn != -1)
        {
            pf = allPlayer[currTurn].GetComponent<PlayerFire>();
            pf.ChangeTurn(false);
        }

        currTurn = (++currTurn) % allPlayer.Count;
        print("현재 턴 : Player " + currTurn);

        pf = allPlayer[currTurn].GetComponent<PlayerFire>();
        pf.ChangeTurn(true);
    }    
}
