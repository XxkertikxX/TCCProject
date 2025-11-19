using UnityEngine;
using UnityEngine.UI;

public class ApplySkillUI : MonoBehaviour
{
	[SerializeField] private int position;
	[SerializeField] private SpriteRenderer iconTypeSkill;
	[SerializeField] private SpriteRenderer[] iconSubTypeSkill;
	[SerializeField] private Text damage;
	[SerializeField] private Text manaConsume;
	
	void OnEnable() {
		iconTypeSkill.sprite = Skill().SpriteTypeSkill;
		damage.text = Skill().SkillPower.ToString();
		manaConsume.text = Skill().ManaConsume.ToString();
		SubType();
	}
	
	private void SubType() {
		for(int i = 0; i < Skill().SpritesEffectsSkill.Length; i++) {
			iconSubTypeSkill[i].sprite = Skill().SpritesEffectsSkill[i];
		}
	}

	private SkillBase Skill() {
        return CharacterClick.CharacterAttr.Character.Skills[position];
    }
}
