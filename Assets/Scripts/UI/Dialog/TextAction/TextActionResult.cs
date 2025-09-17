public class TextActionResult : TextActionString {
    public override string[] TextAction() {
        string[] text = {$"{TextBattleData.Character} {TextBattleData.Action} em {TextBattleData.Targets}"};
        return text;
    }
}
