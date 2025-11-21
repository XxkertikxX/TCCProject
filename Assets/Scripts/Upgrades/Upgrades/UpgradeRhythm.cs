using UnityEngine;

[CreateAssetMenu(menuName = "RhythmLentCreator")]
public class UpgradeRhythm : UpgradeSO {
    public override void Upgrade(StatusCharacters status) {
        foreach(var skill in status.Skills) {
			skill.SpeedMin -= Value;
			skill.SpeedMax -= Value;
		}
    }
}
