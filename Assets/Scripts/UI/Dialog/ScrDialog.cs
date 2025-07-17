using UnityEngine;

[CreateAssetMenu(menuName = "new dialog")]
public class ScrDialog : ScriptableObject {
    [SerializeField] LineDialog[] lineDialog;

    public LineDialog[] LineDialog => lineDialog;
}

[System.Serializable]
public class LineDialog {
    public string NameCharacter;
    public Sprite ImageCharacter;
    [TextArea] public string TextDialog;
}