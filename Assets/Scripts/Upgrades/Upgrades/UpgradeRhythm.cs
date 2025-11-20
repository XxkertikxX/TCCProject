using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRhythm : MonoBehaviour, UpgradeBase
{
    public void Upgrade(StatusCharacters status, float value) {
        foreach(var skill in status.Skills) {
			skill.SpeedMin -= value;
			skill.SpeedMax -= value;
		}
    }
	
	public void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
