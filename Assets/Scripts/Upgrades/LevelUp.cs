using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelUp : MonoBehaviour
{
	static public HashSet<UpgradeSO> upgradesUsados;
	static public StatusCharacters CharacterForUp;
	
	[SerializeField] private GameObject UI;
	
    [Header("References")]
    [SerializeField] private StatusCharacters character;
    [SerializeField] private Slider xpSlider;

    [Header("Config")]
    [SerializeField] private float fillSpeedBase = 0.5f;
    [SerializeField] private float fillSpeedMultiplier = 0.02f;


    private float XpToNext => 100 + character.Level * 100;

    public IEnumerator UpLevel() {
        while (character.Xp > 0) {
            float xpRemaining = character.Xp;
            float xpNeeded = XpToNext * (1f - xpSlider.value);

            float deltaXP = Mathf.Min(xpRemaining, xpNeeded);

            float speed = fillSpeedBase + character.Xp * fillSpeedMultiplier;

            float startValue = xpSlider.value;
            float endValue = (startValue * XpToNext + deltaXP) / XpToNext;

            float t = 0f;
			
            while (t < 1f) {
                t += Time.deltaTime * speed;
                xpSlider.value = Mathf.Lerp(startValue, endValue, t);
                yield return null;
            }

            character.Xp -= deltaXP;

            if (Mathf.Approximately(xpSlider.value, 1f)) {
                character.Level++;
                xpSlider.value = 0f;

                yield return StartCoroutine(OnLevelUp());
            }
        }
    }

    private IEnumerator OnLevelUp() {
		upgradesUsados = new HashSet<UpgradeSO>();
		UI.SetActive(true);
        yield return new WaitForSeconds(1f);
		UI.SetActive(false);
    }
}