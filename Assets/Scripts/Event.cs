using UnityEngine;
using System;

public class Event : MonoBehaviour
{
    public event Action OnEvent;

    public void EventInvoke() {
        OnEvent?.Invoke();
    }
}
