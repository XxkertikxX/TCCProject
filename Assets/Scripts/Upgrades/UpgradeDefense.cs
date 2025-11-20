using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDefense : MonoBehaviour, UpgradeBase
{
    public void Upgrade(StatusCharacters status, float value) {
        status.Defense += value;
    }
	
	public void UpgradeDetails(StatusCharacters status, float value) {
		
	}
}
