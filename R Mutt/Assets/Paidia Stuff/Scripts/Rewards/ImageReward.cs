using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageReward : AReward {

	// A referrence to the UI image this controls
	public Image uiImage;
	// The image to display as the reward
	public Sprite image;

	override public ICanvasElement GetReward() {
		this.uiImage.sprite = this.image;

		return this.uiImage;
	}
}
