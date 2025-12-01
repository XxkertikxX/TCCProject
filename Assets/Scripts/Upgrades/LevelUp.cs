using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelUp : MonoBehaviour
{
	static public HashSet<UpgradeSO> upgradesUsados;
	static public StatusCharacters CharacterForUp;
	
	[SerializeField] private GameObject UI;
	[SerializeField] private GameObject HUD;
	[SerializeField] private GameObject Level;
	[SerializeField] private GameObject Upgrade;
    [SerializeField] private GameObject Dialogs;
 	
    [Header("References")]
    [SerializeField] private StatusCharacters character;
    [SerializeField] private Slider xpSlider;

    [Header("Config")]
    [SerializeField] private float fillSpeedBase = 0.1f;
    [SerializeField] private float fillSpeedMultiplier = 0.02f;


    private float XpToNext => 100 + character.Level * 100;

	public IEnumerator UpLevel() {
		float xpToAdd = 50f;

		float xpRemainingToAnimate = xpToAdd;

		HUD.SetActive(false);
		Dialogs.SetActive(false);
		UI.SetActive(true);

		while (xpRemainingToAnimate > 0) {
			float xpNeeded = XpToNext - (character.Xp % XpToNext);
			float delta = Mathf.Min(xpRemainingToAnimate, xpNeeded);

			float startValue = xpSlider.value;
			float endValue = (character.Xp % XpToNext + delta) / XpToNext;

			float t = 0f;
			float speed = fillSpeedBase + (character.Level * fillSpeedMultiplier);

			while (t < 1f) {
				t += Time.deltaTime * speed;
				xpSlider.value = Mathf.Lerp(startValue, endValue, t);
				yield return null;
			}

			character.Xp += delta;
			xpRemainingToAnimate -= delta;

			if (Mathf.Approximately(xpSlider.value, 1f)) {
				character.Level++;
				xpSlider.value = 0f;
				yield return StartCoroutine(OnLevelUp());
			}
		}
    }

    private IEnumerator OnLevelUp() {
        CharacterForUp = character;
        upgradesUsados = new HashSet<UpgradeSO>();
		Level.SetActive(false);
		Upgrade.SetActive(true);
        yield return new WaitUntil(() => ChoiceUpgrade.Choice == true);
		ChoiceUpgrade.Choice = false;
		Upgrade.SetActive(false);
		Level.SetActive(true);
    }
}