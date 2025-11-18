using UnityEngine;

[CreateAssetMenu(menuName = "TextActionPassTurn")]
public class TextActionPassTurn : TextActionString
{
     public override string[] TextAction() {
        string[] text = {$"O turno foi passado, você recuperou {EnemyTurn.ManaAdd} de mana."};
        return text;
    }
}
