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
            },
            new LineDialog {
                NameCharacter = "Test",
                ImageCharacter = null,
                TextDialog = "This is a test dialog. 2"
            }
        });
        return scrDialog;
    }
}