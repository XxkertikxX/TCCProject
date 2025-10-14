using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteDB;

public class SaveStats
{
    [BsonId]
    public int ID { get; set; }

    public string SceneName { get; set; }
    public int ManaBase { get; set; }
    public int ManaTotal { get; set; }
    public int Level { get; set; }
    public Vector3Stat Player { get; set; }
    public bool[] DefeatEnemy { get; set; }
}

public class Vector3Stat
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
}