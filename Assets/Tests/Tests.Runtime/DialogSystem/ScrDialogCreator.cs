using UnityEngine;

public class ScrDialogCreator
{
    static public ScrDialog NewScrDialog()
    {
        ScrDialog scrDialog = ScriptableObject.CreateInstance<ScrDialog>();
        Reflection.SetField(scrDialog, "lineDialog", new LineDialog[] {
            new LineDialog {
                NameCharacter = "Test Character",
                ImageCharacter = null,
                TextDialog = "This is a test dialog."
            }
        });
        return scrDialog;
    }
}