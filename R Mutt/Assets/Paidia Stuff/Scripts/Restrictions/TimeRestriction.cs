using UnityEngine;
using System.Collections;

// A restriction on time windows. Restricts to a single time window on the military time clock. Time Zone is local to the phone device's time zone
public class TimeRestriction : ARestriction {

	// The hour for the opening of the time window. Treated as between [0, 24) such that 27 -> 3
	public int openingHour;
	// The minute for the opening of the timer window. Treated as between [0, 59) such that 65 -> 5 without changing the hours.
	public int openingMinute;
	// The hour for the closing of the time window. Treated as between [0, 24) such that 27 -> 3
	public int closingHour;
	// The minute for the closing of the timer window. Treated as between [0, 59) such that 65 -> 5 without changing the hours.
	public int closingMinute;

	// Returns if the user's device is within the time window
	override public bool IsRestrictionMet() {
		openingHour %= 24;
		openingMinute %= 60;
		closingHour %= 24;
		closingMinute %= 60;

		int currentHour = System.DateTime.Now.Hour;
		int currentMinute = System.DateTime.Now.Minute;

		bool isRightHour = false;
		bool isRightMinute = false;

		// if time is ordered in lower bound to upper bound (doesn't last thru midnight)
		if (openingHour * 60 + openingMinute <= closingHour * 60 + closingMinute) {
			isRightHour = openingHour <= currentHour && currentHour <= closingHour;
			isRightMinute = (openingHour * 60 + openingMinute <= currentMinute + 60 * currentHour) && (currentHour * 60 + currentMinute <= closingMinute + 60 * closingHour);
		} 
		// time includes midnight and goes from one day to the next
		else {
			isRightHour = currentHour >= openingHour || currentHour <= closingHour;
			isRightMinute = (currentMinute >= openingMinute && currentHour >= openingHour) || (currentMinute <= closingMinute && currentHour <= closingHour);
		}
		return isRightHour && isRightMinute;
	}
}
