using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeak : MonoBehaviour
{	
	[SerializeField] private DialogIconsUI dialog;

	[SerializeField] private Animator anim;
	[SerializeField] private string nameAnim;
	
	void OnEnable() {
		dialog.OnApplyIcons += PlayAnimation;
		DialogManager.OnDialogClose += stopTalking;
	}
	
	void OnDisable() {
		dialog.OnApplyIcons -= PlayAnimation;
		DialogManager.OnDialogClose -= stopTalking;
	}
	
	private void PlayAnimation(string name) {
		if(this.nameAnim == name) {
			anim.SetBool("Talking", true);
		} else {
			stopTalking();
        }
	}
	private void stopTalking()
	{
        anim.SetBool("Talking", false);
    }
}
