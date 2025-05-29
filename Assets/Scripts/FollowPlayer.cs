using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Target;
    void Update() {
        transform.position = Target.position;
    }
}
