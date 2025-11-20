using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDefense : UpgradeBase
{
    public override void Upgrade(StatusCharacters status, float value) {
        status.Defense += value;
    }
}
