using UnityEngine;

[CreateAssetMenu(menuName = "TextActionPassTurn")]
public class TextActionPassTurn : TextActionString
{
     public override string[] TextAction() {
        string[] text = {$"O turno foi passado, você recuperou 5 de mana."};
        return text;
    }
}
