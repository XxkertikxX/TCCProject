using UnityEngine;

public abstract class UpgradeSO : ScriptableObject
{
    public string Name;
	[TextArea]
	public string Description;
	public float Value;
	public Sprite Icon;
	
	public abstract void Upgrade(StatusCharacters status);
}
