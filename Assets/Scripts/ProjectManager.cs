using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    static ProjectManager instance;

    public int orderInRoom;

    public static ProjectManager Get()
    {
        if(instance == null)
        {
            GameObject go = new GameObject(nameof(ProjectManager));
            go.AddComponent<ProjectManager>();
        }        

        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
