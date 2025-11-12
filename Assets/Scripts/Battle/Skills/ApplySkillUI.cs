using UnityEngine;
using UnityEngine.UI;

public class ApplySkillUI : MonoBehaviour
{
	[SerializeField] private int position;
	[SerializeField] private SpriteRenderer iconTypeSkill;
	[SerializeField] private Text damage;
	[SerializeField] private Text manaConsume;
	
	void OnEnable() {
		iconTypeSkill.sprite = Skill().SpriteTypeSkill;
		damage.text = Skill().SkillPower.ToString();
		manaConsume.text = Skill().ManaConsume.ToString();
	}
	
	private SkillBase Skill() {
        return CharacterClick.CharacterAttr.Character.Skills[position];
    }
}
