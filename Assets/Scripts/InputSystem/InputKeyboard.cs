using UnityEngine;

public class InputKeyboard : MonoBehaviour, IButtonInput
{
    private Bindings bindings;
    
    void Awake() {
        bindings = GetComponent<Bindings>();
    }
    
    public bool InputButton(string key) {
        return Input.GetKey(bindings.BindingsDic[key]);
    }
    
    public bool InputButtonDown(string key) {
        return Input.GetKeyDown(bindings.BindingsDic[key]);
    }
    
    public bool InputButtonUp(string key) {
        return Input.GetKeyUp(bindings.BindingsDic[key]);
    }
}
