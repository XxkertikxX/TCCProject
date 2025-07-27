using UnityEngine;

[CreateAssetMenu(menuName = "new dialog")]
public class ScrDialog : ScriptableObject {
    [SerializeField] private LineDialog[] lineDialog;

    public LineDialog[] LineDialog => lineDialog;
}

[System.Serializable]
public class LineDialog {
    public string NameCharacter;
    public Sprite ImageCharacter;
    [TextArea] public string TextDialog;
}