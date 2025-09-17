using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActionSO : TextActionString
{
    [SerializeField] TextsSO texts;

    public override string[] TextAction() {
        return texts.LineDialog;
    }
}
