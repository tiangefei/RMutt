using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// An abstract notion of a Reward for a Mission.
public abstract class AReward : MonoBehaviour {

	public abstract ICanvasElement GetReward ();
}
