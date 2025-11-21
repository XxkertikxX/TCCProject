using UnityEngine;

[CreateAssetMenu(menuName = "ManaUpCreator")]
public class UpgradeMana : UpgradeSO {
    [SerializeField] private ManaSO manaSO;

    public override void Upgrade(StatusCharacters status) {
        manaSO.Mana += Value;
    }
}
