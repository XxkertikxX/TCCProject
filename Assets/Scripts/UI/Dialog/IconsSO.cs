using UnityEngine;

[CreateAssetMenu(menuName = "new icon")]
public class IconsSO :ScriptableObject {
	[SerializeField] private IconCharacter[] iconsCharacter;

    public IconCharacter[] IconsCharacter => iconsCharacter;
}

[System.Serializable]
public class IconCharacter {
	public string NameCharacter;
    public Sprite ImageCharacter;
}