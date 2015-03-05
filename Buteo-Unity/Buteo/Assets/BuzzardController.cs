using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Aeroplane;

public class BuzzardController : MonoBehaviour {

	Dictionary<int, GameObject> thermalColumns = new Dictionary<int,GameObject>();
	float currentConstantForceY;

	void Start()
	{
		InvokeRepeating("checkForThermalColumns", 0f, 1f);
	}

	void Update()
	{
		processThermalColumns();
	}

	void checkForThermalColumns ()
	{
		thermalColumns.Clear();
		Collider[] collidingObjects = Physics.OverlapSphere(transform.position, 6f);
		
		foreach(Collider collider in collidingObjects)
		{
			if(collider.gameObject.tag == "ThermalColumn")
			{
				thermalColumns.Add(collider.gameObject.GetInstanceID(), collider.gameObject);
			}
		}
		Debug.Log(thermalColumns.Count);
	}

	void processThermalColumns ()
	{
		currentConstantForceY = 0;
		GameObject[] thermalColumnCache = new GameObject[thermalColumns.Count];
		thermalColumns.Values.CopyTo(thermalColumnCache, 0);

		for(int i = 0; i < thermalColumnCache.Length; i++)
		{
			currentConstantForceY += thermalColumnCache[i].GetComponent<ThermalColumnController>().ThermalImpact;
		}
		GetComponent<AeroplaneController>().m_Lift = currentConstantForceY;
	}

	public float CurrentConstantForceY {
		get {
			return this.currentConstantForceY;
		}
	}
}
