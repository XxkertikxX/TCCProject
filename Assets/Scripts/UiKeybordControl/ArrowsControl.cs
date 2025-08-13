using UnityEngine;
using UnityEngine.UI;

public class ArrowsControl : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    int index = 0;
    void Update()
    {
        index += Select(InputCatalyst.input);
        buttons[index].Select();
        Debug.Log(buttons[index].gameObject.name);
    }

    int Select(IButtonInput input)
    {
        if (input.InputButtonDown("Up"))
        {
            return -1;
        }
        if (input.InputButtonDown("Down"))
        {
            return 1;
        }
        return 0;
    }
}
