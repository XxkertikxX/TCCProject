public class TextActionSkill : TextActionString {
    public string[] TextAction() {
        string[] text = {$"{TextBattleData.Character} usou {TextBattleData.SkillName}"};
        return text;
    }
}
