using System.Collections;
using UnityEngine;

public class DestroyDeath : MonoBehaviour, IDeath
{
    public void Death() {
        StartCoroutine(DeathAnim());
    }

    public IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}