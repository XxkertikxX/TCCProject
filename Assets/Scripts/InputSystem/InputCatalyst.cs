using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IButtonInput))]
public class InputCatalyst : MonoBehaviour
{
    static public IButtonInput input;

    void Awake() {
        input = GetComponent<IButtonInput>();
    }
}
