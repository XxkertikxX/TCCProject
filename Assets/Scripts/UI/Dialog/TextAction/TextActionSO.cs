using UnityEngine;

[CreateAssetMenu(menuName = "TextActionSO")]
public class TextActionSO : TextActionString {
    [SerializeField] TextsSO texts;

    public override string[] TextAction() {
        return texts.LineDialog;
    }
}
