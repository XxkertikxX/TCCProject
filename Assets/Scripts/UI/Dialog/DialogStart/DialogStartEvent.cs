using UnityEngine;

public class DialogStartEvent : DialogStartBase {
    [SerializeField] private Event eventDialog;

    void OnEnable() {
        eventDialog.OnEvent += StartDialog;
    }

    void OnDisable() {
        eventDialog.OnEvent -= StartDialog;
    }
}
