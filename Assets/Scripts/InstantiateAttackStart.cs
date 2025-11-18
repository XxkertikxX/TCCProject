using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAttackStart : MonoBehaviour
{
    [SerializeField] GameObject Attack;
    private void Start()
    {
        Instantiate(Attack);
    }
}
