using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTutorial : MonoBehaviour, IDialogSetup
{
	[SerializeField] private GameObject tutorialGO;
    [SerializeField] private string[] bindsPressed;
	
    public void SetupOpenDialog() {}
    
    public void SetupCloseDialog(){
		StartCoroutine(BattleTutorial());
    }
	
	private IEnumerator BattleTutorial() {
		tutorialGO.SetActive(true);
		yield return new WaitForKeyDown(bindsPressed);
		Destroy(tutorialGO);
		Destroy(gameObject);
	}
	
	
}

public class WaitForKeyDown : CustomYieldInstruction {
	private string[] binds;

    public WaitForKeyDown(string[] binds) {
        this.binds = binds;
    }
	
    public override bool keepWaiting {
        get {
			foreach (string bind in binds) {
				if (InputCatalyst.input.InputButtonDown(bind)) {
					return false;
				}
			}
            return true;
        }
    }
}