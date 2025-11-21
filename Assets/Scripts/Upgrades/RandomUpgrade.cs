using UnityEngine;
using System.Collections.Generic;
public class RandomUpgrade : MonoBehaviour
{
	[SerializeField] private UpgradeSO[] upgrades;
	
	public UpgradeSO PickOriginal(HashSet<UpgradeSO> proibidos) {
		UpgradeSO selected = null;
    
		while(true) {
			int r = Random.Range(0, 100);

			if (r < 5)  selected = upgrades[0];
			else if (r < 28) selected = upgrades[1];
			else if (r < 50) selected = upgrades[2];
			else if (r < 56) selected = upgrades[3];
			else if (r < 75) selected = upgrades[4];
			else selected = upgrades[5];

        	if (!proibidos.Contains(selected))
				return selected;
		}
	}
}
