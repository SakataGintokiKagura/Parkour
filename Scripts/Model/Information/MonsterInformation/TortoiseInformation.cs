﻿using UnityEngine;
using System.Collections;
using System;

public class TortoiseInformation : IBlology {
    public int damage{get;set;}
    public int HP{get;set;}
    //public Transform trans { get; set; }
    public TortoiseInformation(float time)
    {
        HP = 1;
        damage = 20;
        //this.trans = trans;
    }
}