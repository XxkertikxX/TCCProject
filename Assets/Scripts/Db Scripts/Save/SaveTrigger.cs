using UnityEngine;
using System;
using System.Collections;

public class SaveTrigger : MonoBehaviour
{
    static public event Action OnDeath;
    private bool morreu = false;
    [SerializeField] private GameObject MorreuMenu;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && !morreu) {
            //GameObject.FindObjectOfType<SaveLoader>().Load();
            MorreuMenu.SetActive(true);
            OnDeath?.Invoke();
            StartCoroutine(Morreu());
        }
    }

    private IEnumerator Morreu() {
        morreu = true;
        yield return new WaitForSeconds(3f);
        morreu = false;
    }
}
