using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicarBatalhaTEMPORARIO : MonoBehaviour
{
    [SerializeField] private string cenaCombate;
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision != null && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(cenaCombate);
        }
    }
}
