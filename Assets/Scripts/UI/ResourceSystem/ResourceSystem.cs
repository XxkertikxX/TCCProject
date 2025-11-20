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

    public float ModifyValue(float valueChange) {
		float oldActualValue = actualValue;
        actualValue = Mathf.Clamp(actualValue + valueChange, 0, maxValue);
        valueUI.UpdateUI(actualValue, maxValue);
        if (actualValue == 0) {
            OnResourceEmpty?.Invoke();
        }
		
		return ValueModifier(valueChange, oldActualValue, maxValue);
	}

    public float ActualValue() {
        return actualValue;
    }
    
	public bool CanChangeResource(float resourceConsume) {
		return resourceConsume <= actualValue;
	}
	
	private float ValueModifier(float valueChange, float actualValue, float maxValue) {
		if(actualValue+valueChange > maxValue) {
			return maxValue-actualValue;
		}
		if(actualValue+valueChange < 0) {
			return actualValue;
		}
		return valueChange;
	}
	
    private void PullComponents() {
        valueUI = GetComponent<IDinamicUI>();
    }
}