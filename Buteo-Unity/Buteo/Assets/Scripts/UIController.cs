using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	BuzzardController buzzardController;
	Text statsField;

	void Awake ()
	{
		buzzardController = GameObject.FindGameObjectWithTag (Tags.BUZZARD).GetComponent<BuzzardController> ();


		statsField = GameObject.FindGameObjectWithTag (Tags.STATS_FIELD).GetComponent<Text> ();
	}

	void Update ()
	{
		statsField.text = "" +
			"Gliding Airspeed: " + buzzardController.GetComponent<Rigidbody>().velocity.magnitude + " m/s ||" + buzzardController.GetComponent<Rigidbody>().velocity.magnitude * 3.6f + " km/h \n" +
			"Vertical Speed: " + buzzardController.GetComponent<Rigidbody>().velocity.y + " m/s \n" +
			"Altitude: " + buzzardController.Altitude + "\n" +
			"Rising: " + buzzardController.CurrentConstantForceY + "\n" +
			"RollInput: " + buzzardController.RollInput + "\n" +
			"PitchInput: " + buzzardController.PitchInput + "\n" +
			"YawInput: " + buzzardController.YawInput + "\n" +
			"AirBrakes: " + buzzardController.AirBrakes + "\n" +
			"ForwardSpeed: " + buzzardController.ForwardSpeed + "\n" +
			"ThrottleInput: " + buzzardController.ThrottleInput + "\n" +
			"Throttle: " + buzzardController.Throttle + "\n" +
			"Pitch Angle: " + buzzardController.GetComponent<Rigidbody>().rotation.x + "\n" +
			"";
	}
}
