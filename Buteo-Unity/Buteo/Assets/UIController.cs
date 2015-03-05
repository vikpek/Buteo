using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	BuzzardController buzzardController;

	Text heightValue;
	Text risingValue;

	void Awake()
	{
		buzzardController = GameObject.FindGameObjectWithTag(Tags.BUZZARD).GetComponent<BuzzardController>();

		heightValue = GameObject.FindGameObjectWithTag(Tags.RISING_VALUE).GetComponent<Text>();
		risingValue = GameObject.FindGameObjectWithTag(Tags.HEIGHT_VALUE).GetComponent<Text>();
	}

	void Update()
	{
		heightValue.text = buzzardController.transform.position.y + "";
		risingValue.text = buzzardController.CurrentConstantForceY + "";
	}
}
