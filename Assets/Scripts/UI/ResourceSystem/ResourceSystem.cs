using UnityEngine;
using System;

public class ResourceSystem : MonoBehaviour
{
    public event Action OnResourceEmpty;
    private IDinamicUI valueUI;

    private float actualValue;
    private float maxValue;

    public void Constructor(float maxValue) {
        this.maxValue = maxValue;
        this.actualValue = maxValue;
    }

    void Start() {
        PullComponents();
        valueUI.UpdateUI(actualValue, maxValue);
    }

    public void ModifyValue(float valueChange) {
        actualValue = Mathf.Clamp(actualValue + valueChange, 0, maxValue);
        valueUI.UpdateUI(actualValue, maxValue);

        if (actualValue == 0) {
            OnResourceEmpty?.Invoke();
        }
    }

    private void PullComponents() {
        valueUI = GetComponent<IDinamicUI>();
    }
}