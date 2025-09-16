public class TextActionResult : TextActionString {
    public string TextAction() {
        return $"{TextBattleData.Character} {TextBattleData.Action} em {TextBattleData.Targets}";
    }
}
