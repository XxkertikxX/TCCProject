using LiteDB;
using UnityEngine;
public class KeyBinding{
    [BsonId]
    public string KeyName { get; set; }

    public KeyCode Key { get; set; }
}