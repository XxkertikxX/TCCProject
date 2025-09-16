public class TextActionSkill : TextActionString {
    public string TextAction() {
        return $"{TextBattleData.Character} usou {TextBattleData.SkillName}";
    }
}
