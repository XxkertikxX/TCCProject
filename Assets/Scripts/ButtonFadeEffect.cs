using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFadeEffect : MonoBehaviour
{
    private Vector2 lastMousePos;
    private bool IsMoving = false;
    private Image skipButton;
    private Camera cam;
    private Coroutine coroutine;

    private void Start() {
        lastMousePos = Input.mousePosition;
        skipButton = GetComponent<Image>();   
        cam = Camera.main;
    }

    private void Update() {
        Vector2 mousePos = cam.WorldToScreenPoint(Input.mousePosition);
        if(mousePos != lastMousePos) {
            if (!IsMoving) {
                IsMoving = true;
                MouseMoving();
            }
        }
        else
        {
            if (IsMoving && coroutine == null) {
                coroutine = StartCoroutine(MouseStopped());
                IsMoving = false;
            }
        }
        lastMousePos = mousePos;
    }

    private void MouseMoving() {
        skipButton.color = Color.white;
    }

    private IEnumerator MouseStopped() {
        yield return new WaitForSeconds(2);
        skipButton.CrossFadeAlpha(0.3f, 0.5f, true);
        yield return new WaitForSeconds(0.5f);
        coroutine   = null;
    }

    public void ButtonClicked() {
        SceneManager.LoadScene("MainMenu");
    }
}
