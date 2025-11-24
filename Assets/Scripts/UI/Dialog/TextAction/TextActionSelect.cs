using UnityEngine;

[CreateAssetMenu(menuName = "TextActionSelect")]
public class TextActionSelect : TextActionString {
	public override string[] TextAction() {
        string[] text = {$"Selecione um personagem"};
        return text;
    }
}
