using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeReductionMana : MonoBehaviour
{
    public void Upgrade(StatusCharacters status, float value) {
        foreach(var skill in status.Skills) {
			skill.ManaConsume -= value;
		}
    }
	
	public void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
