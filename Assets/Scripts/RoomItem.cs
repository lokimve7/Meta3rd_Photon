using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    // 내용 담는 Text
    public Text roomInfo;
    // 잠금 표시 Image
    public GameObject imgLock;
    // 방 이름
    string realRoomName;

    // 클릭 되었을 때 호출되는 함수를 가지고 있는 변수
    public Action<string> onChangeRoomName;

    public void SetConent(string roomName, int currPlayer, int maxPlayer)
    {
        // rooName 을 전역변수에 담아놓자.
        realRoomName = roomName;

        // 정보 입력
        roomInfo.text = roomName + " ( " + currPlayer + " / " + maxPlayer + " )";
    }
    
    public void SetLockMode(bool isLock)
    {
        imgLock.SetActive(isLock);
    }

    public void OnClick()
    {
        // 만약에 onChangeRoomName 에 함수가 들어있다면
        if(onChangeRoomName != null)
        {
            // 해당 함수 실행
            onChangeRoomName(realRoomName);
        }

        //// 1. InputRoomName 게임오브젝트 찾자.
        //GameObject go = GameObject.Find("InputRoomName");
        //// 2. 찾은 게임오브젝트에서 TMP_InputField 컴포넌트 가져오자
        //TMP_InputField inputField = go.GetComponent<TMP_InputField>();
        //// 3. 가져온 컴포넌트를 이용해서 내용 변경
        //inputField.text = realRoomName;
    }
}
