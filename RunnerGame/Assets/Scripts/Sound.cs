﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound 
{

    public string name;
    public AudioClip clip;
    public float volume;
    public AudioSource source;
    public bool loop;
}
