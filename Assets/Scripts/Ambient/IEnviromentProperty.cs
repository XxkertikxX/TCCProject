using System.Collections;
using UnityEngine;

public interface IEnviromentProperty
{
    IEnumerator ApplyEffect(Rigidbody2D targetRB);
}
