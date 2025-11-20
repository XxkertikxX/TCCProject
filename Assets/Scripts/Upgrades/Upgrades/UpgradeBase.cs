using UnityEngine;

public abstract class UpgradeBase : MonoBehaviour{
    public abstract void Upgrade(StatusCharacters status, float value);
	public abstract void UpgradeDetails(StatusCharacters status, float value);
}