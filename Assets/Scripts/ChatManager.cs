using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    // Input Field
    public TMP_InputField inputChat;

    void Start()
    {
        // inputChat 의 내용이 변경될 때 호출되는 함수 등록
        inputChat.onValueChanged.AddListener(OnValueChanged);
        // inputChat 엔터를 쳤을 때 호출되는 함수 등록
        inputChat.onSubmit.AddListener(OnSubmit);
        // inputChat 포커싱을 잃을 때 호출되는 함수 등록
        inputChat.onEndEdit.AddListener(OnEndEdit);
    }

    void Update()
    {
        
    }

    void OnValueChanged(string s)
    {
        print("변경 중 : " + s);
    }

    void OnSubmit(string s)
    {
        print("엔터 침 : " + s);
    }

    void OnEndEdit(string s)
    {
        print("작성 끝 : " + s);
    }
}
