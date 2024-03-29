﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (BuzzardController))]
public class Buzzard4AxisControl : MonoBehaviour
{
	// these max angles are only used on mobile, due to the way pitch and roll input are handled
	public float maxRollAngle = 80;
	public float maxPitchAngle = 80;
	
	// reference to the aeroplane that we're controlling
	private BuzzardController m_Buzzard;
	private float m_Throttle;
	private bool m_AirBrakes;
	private float m_Yaw;
	
	
	private void Awake()
	{
		// Set up the reference to the aeroplane controller.
		m_Buzzard = GetComponent<BuzzardController>();
	}
	
	
	private void FixedUpdate()
	{
		// Read input for the pitch, yaw, roll and throttle of the aeroplane.
//		float roll = CrossPlatformInputManager.GetAxis("Mouse X");
//		float pitch = CrossPlatformInputManager.GetAxis("Mouse Y");
		m_AirBrakes = CrossPlatformInputManager.GetButton("Submit");
//		m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
//		m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");

		float roll = CrossPlatformInputManager.GetAxis("Horizontal");
		float pitch = CrossPlatformInputManager.GetAxis("Vertical");

		#if MOBILE_INPUT
		AdjustInputForMobileControls(ref roll, ref pitch, ref m_Throttle);
		#endif
		// Pass the input to the aeroplane
		m_Buzzard.Move(roll, pitch, m_Yaw, m_Throttle, m_AirBrakes);
	}
	
	
	private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
	{
		// because mobile tilt is used for roll and pitch, we help out by
		// assuming that a centered level device means the user
		// wants to fly straight and level!
		
		// this means on mobile, the input represents the *desired* roll angle of the aeroplane,
		// and the roll input is calculated to achieve that.
		// whereas on non-mobile, the input directly controls the roll of the aeroplane.
		
		float intendedRollAngle = roll*maxRollAngle*Mathf.Deg2Rad;
		float intendedPitchAngle = pitch*maxPitchAngle*Mathf.Deg2Rad;
		roll = Mathf.Clamp((intendedRollAngle - m_Buzzard.RollAngle), -1, 1);
		pitch = Mathf.Clamp((intendedPitchAngle - m_Buzzard.PitchAngle), -1, 1);
	}
}
