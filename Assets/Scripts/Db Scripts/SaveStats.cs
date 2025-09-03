using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteDB;
using UnityEngine.SceneManagement;

public class SaveStats : MonoBehaviour
{ 
    public Rigidbody2D playerRb; 
    public Scene GetScene;
    public int ManaBase;
    public int ManaTotal;
    public int Level;
    public Transform Player;
}
