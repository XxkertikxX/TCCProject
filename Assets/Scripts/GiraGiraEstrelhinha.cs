using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraGiraEstrelhinha : MonoBehaviour
{
    private void FixedUpdate() {
        transform.Rotate(0, 0, 200 * Time.fixedDeltaTime);
    }
}
