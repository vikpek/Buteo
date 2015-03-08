using UnityEngine;
using System.Collections;

public class ThermalColumnController : MonoBehaviour {
	[SerializeField]
	float _thermalImpact;

	public float ThermalImpact {
		get { return _thermalImpact; }
	}

}
