using System;

public interface IDialogWriter {
	public event Action<int> OnPassLine;
    public void Constructor(string[] dialogs);
    public void StartLine();
}
