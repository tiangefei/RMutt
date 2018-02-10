using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// An AReward that uses Text elements to displat its contents.
public class TextReward : AReward {

	// The contents of the reward text
	public string rewardText;
	// The Text to output this to
	public Text textOutput;

	override public ICanvasElement GetReward() {
		this.textOutput.text = this.rewardText;

		return this.textOutput;
	}
}
