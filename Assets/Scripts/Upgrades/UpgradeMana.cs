using UnityEngine;

public class UpgradeMana : MonoBehaviour, UpgradeBase {
    [SerializeField] private ManaSO manaSO;

    public void Upgrade(StatusCharacters status, float value) {
        manaSO.Mana += value;
    }
}
