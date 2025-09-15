using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class SaveStats
{ 
    [BsonId]
    public int ID;

    public string SceneName;
    public int ManaBase;
    public int ManaTotal;
    public int Level;
    public Vector3Stat Player;
}

public class Vector3Stat{
    public float X;
    public float Y;
    public float Z;
}