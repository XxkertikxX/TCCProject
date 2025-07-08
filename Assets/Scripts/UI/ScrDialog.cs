using UnityEngine;

[CreateAssetMenu(menuName = "new dialog")]
public class ScrDialog : ScriptableObject {
    public LineDialog[] lineDialog;
}

[System.Serializable]
public class LineDialog {
    public string nameCharacter;
    public Sprite imageCharacter;
    [TextArea] public string textDialog;
}