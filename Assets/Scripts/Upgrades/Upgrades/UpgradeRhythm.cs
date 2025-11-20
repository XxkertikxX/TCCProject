using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRhythm : UpgradeBase
{
    public override void Upgrade(StatusCharacters status, float value) {
        foreach(var skill in status.Skills) {
			skill.SpeedMin -= value;
			skill.SpeedMax -= value;
		}
    }
}
