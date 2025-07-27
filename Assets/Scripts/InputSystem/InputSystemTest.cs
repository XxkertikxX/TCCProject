using System.Collections.Generic;
using UnityEngine;

public class InputSystemTest : MonoBehaviour, IButtonInput
{
    public List<string> Input = new List<string>() {""};
    
    public bool InputButton(string key) {
        return Input.Contains(key);
    }

    public bool InputButtonDown(string key) {
        return Input.Contains(key);
    }
    
    public bool InputButtonUp(string key) {
        return Input.Contains(key);
    }
}