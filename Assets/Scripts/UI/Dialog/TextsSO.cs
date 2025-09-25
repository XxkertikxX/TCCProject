using UnityEngine;

[CreateAssetMenu(menuName = "new dialog")]
public class TextsSO : ScriptableObject {
    [SerializeField, TextArea] private string[] lineDialog;

    public string[] LineDialog => lineDialog;
}