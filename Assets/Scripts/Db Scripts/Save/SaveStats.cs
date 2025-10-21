using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class SaveStats { 
    [BsonId]
    public int ID {get; set;}

    public string SceneName {get; set;}
    public float Mana {get; set;}
    public Vector3Stat Player {get; set;}
    public bool[] DefeatEnemy {get; set;}
    public Status[] StatusCharacter {get; set;}
}

public class Vector3Stat {
    public float X {get; set;}
    public float Y {get; set;}
    public float Z {get; set;}
}

public class Status {
    public float Level {get; set;}
    public float Life {get; set;}
    public float Power {get; set;}
}