using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryController
{
    private static MemoryController _instance;
    public List<GameObject> monsterContainerList=new List<GameObject>();

    public static MemoryController instance
    {
        get
        {
            if (_instance==null)
            {
                _instance=new MemoryController();
            }

            return _instance;
        }
    }

}
