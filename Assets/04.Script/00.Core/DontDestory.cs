﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ThisObjectDestory()
    {
        Destroy(this.gameObject);
    }
}
