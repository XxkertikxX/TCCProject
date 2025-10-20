using UnityEngine;

public class NuvemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] nuvens;
    [SerializeField] private float intervalo = 2f;
    [SerializeField] private Vector2 altura;

    private void Start() {
        InvokeRepeating(nameof(Spawn), 0f, intervalo);
    }

    private void Spawn() {
        int i = Random.Range(0, nuvens.Length);
        float y = Random.Range(altura.x, altura.y);
        Instantiate(nuvens[i], new Vector3(transform.position.x, y), Quaternion.identity);
    }
}
