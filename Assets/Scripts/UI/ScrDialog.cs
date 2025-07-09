using UnityEngine;

[CreateAssetMenu(menuName = "new dialog")]
public class ScrDialog : ScriptableObject {
    [SerializeField] LineDialog[] _lineDialog;

    public LineDialog[] LineDialog => _lineDialog;
}

[System.Serializable]
public class LineDialog {
    public string NameCharacter;
    public Sprite ImageCharacter;
    [TextArea] public string TextDialog;
}