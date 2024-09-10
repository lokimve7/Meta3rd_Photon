using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    // 내용 담는 Text
    public Text roomInfo;
    // 잠금 표시 Image
    public GameObject imgLock;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetConent(string roomName, int currPlayer, int maxPlayer)
    {
        roomInfo.text = roomName + " ( " + currPlayer + " / " + maxPlayer + " )";
    }
    
    public void SetLockMode(bool isLock)
    {
        imgLock.SetActive(isLock);
    }
}
