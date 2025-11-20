using UnityEngine;

public class InputKeyboard : MonoBehaviour, IButtonInput
{
    private Bindings bindings;
    
    void Awake() {
        InputCatalyst.input = this;
        bindings = GetComponent<Bindings>();
    }
    
    public bool InputButton(string key) {
		foreach (var k in bindings.BindingsDic[key].Keys) {
			if (Input.GetKey(k)) 
				return true;
		}
		return false;
    }
    
    public bool InputButtonDown(string key) {
		foreach (var k in bindings.BindingsDic[key].Keys) {
			if (Input.GetKeyDown(k)) 
				return true;
		}
		return false;
    }
    
    public bool InputButtonUp(string key) {
		foreach (var k in bindings.BindingsDic[key].Keys) {
			if (Input.GetKeyUp(k)) 
				return true;
		}
		return false;
    }
}
