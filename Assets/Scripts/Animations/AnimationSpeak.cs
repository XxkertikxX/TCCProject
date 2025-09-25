using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeak : MonoBehaviour
{	
	[SerializeField] private DialogIconsUI dialog;

	[SerializeField] private Animator anim;
	[SerializeField] private string name;
	
	void OnEnable() {
		dialog.OnApplyIcons += PlayAnimation;
		DialogManager.OnDialogClose += IdleAnimation;
	}
	
	void OnDisable() {
		dialog.OnApplyIcons -= PlayAnimation;
		DialogManager.OnDialogClose -= IdleAnimation;
	}
	
	private void PlayAnimation(string name) {
		if(this.name == name) {
			anim.SetBool("Talking", true);
		} else {
			IdleAnimation();
		}
	}
	
	private void IdleAnimation() {
		anim.SetBool("Talking", false);
	}
}
