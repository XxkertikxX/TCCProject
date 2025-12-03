using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnStartVideo : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<DefineBattleConfigSO>().DefineSO();
    }
}
