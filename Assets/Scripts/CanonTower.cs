using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : MonoBehaviour {

	public GameObject RangeObject;
	public int InitialTowerRange;

	public void OnMouseEnter(){
		RangeObject.SetActive(true);
		RangeObject.transform.localScale = new Vector3(InitialTowerRange, InitialTowerRange, 0);
	}

	public void OnMouseExit(){
		RangeObject.SetActive(false);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
