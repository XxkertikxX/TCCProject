using UnityEngine;

public class DialogStartBase : MonoBehaviour
{
    [SerializeField] private ScrDialog dialog;

    protected void StartDialog() {
        DialogManager.Instance.OpenDialog(dialog);
    }
}
