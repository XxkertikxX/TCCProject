public class TextActionSkill : TextActionString {
    public override string[] TextAction() {
        string[] text = {$"{TextBattleData.Character} usou {TextBattleData.SkillName}"};
        return text;
    }
}
