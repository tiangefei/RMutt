using UnityEngine;
using System.Collections;

public abstract class ARestriction : MonoBehaviour
{
	// Returns whether or not this IRestriction has been met.
	public abstract bool IsRestrictionMet();
}


