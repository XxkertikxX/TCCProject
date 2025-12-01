using UnityEngine;

[CreateAssetMenu(fileName = "attackInfoDesc",menuName = "NewAttackInfo")]

public class AttackDesck : ScriptableObject
{
    [TextArea] public string DescAttac1;
    [TextArea] public string DescAttac2;
}
