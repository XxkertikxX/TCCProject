using UnityEngine;
using System.Collections;
using System;

public class RemoveAnimation : MonoBehaviour
{
    static public event Action OnDisableAnimation;

    void OnDisable() {
        OnDisableAnimation?.Invoke();
    }
}
