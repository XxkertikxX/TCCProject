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
		character.Xp += 50;
		HUD.SetActive(false);
        Dialogs.SetActive(false);
		UI.SetActive(true);
        float x = character.Xp;
        while (x > 0) {
            float xpRemaining = x;
            float xpNeeded = XpToNext * (1f - xpSlider.value);

            float deltaXP = Mathf.Min(xpRemaining, xpNeeded);

            float speed = fillSpeedBase + character.Xp * fillSpeedMultiplier;

            float startValue = xpSlider.value;
            float endValue = (startValue * XpToNext + deltaXP) / XpToNext;

            float t = 0f;
            x -= deltaXP;
            while (t < 1f) {
                t += Time.deltaTime * speed;
                xpSlider.value = Mathf.Lerp(startValue, endValue, t);
                yield return null;
            }

            if (Mathf.Approximately(xpSlider.value, 1f)) {
                character.Level++;
                xpSlider.value = 0f;
                character.Xp -= xpNeeded;
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