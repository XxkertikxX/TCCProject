using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActionSO : MonoBehaviour, TextActionString
{
    [SerializeField] TextsSO texts;

    public string[] TextAction() {
        return texts.LineDialog;
    }
}
