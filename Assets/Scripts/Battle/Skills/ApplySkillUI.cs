using UnityEngine;
using UnityEngine.UI;

public class ApplySkillUI : MonoBehaviour
{
	[SerializeField] private int position;
	[SerializeField] private SpriteRenderer iconTypeSkill;
	[SerializeField] private SpriteRenderer[] iconSubTypeSkill;
	[SerializeField] private Text damage;
	[SerializeField] private Text manaConsume;
	[SerializeField] private Text nameSkill;
	
	void Update() {
        iconTypeSkill.sprite = Skill().SpriteTypeSkill;
		damage.text = Skill().SkillPower.ToString();
		manaConsume.text = Skill().ManaConsume.ToString();
		nameSkill.text = Skill().Name.ToString();
		SubType(); 
	}
	
	private void SubType() {
		for(int i = 0; i < Skill().SpritesEffectsSkill.Length; i++) {
			iconSubTypeSkill[i].sprite = Skill().SpritesEffectsSkill[i];
		}
		if(Skill().SpritesEffectsSkill.Length == 1) {
			iconSubTypeSkill[1].sprite = null;
		}
	}

	private SkillBase Skill() {
        return CharacterClick.CharacterAttr.Character.Skills[position];
    }
}
