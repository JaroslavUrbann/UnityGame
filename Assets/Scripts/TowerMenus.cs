using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenus : MonoBehaviour {

	public GameObject[] TowerOptions;
	public GameObject[] BuildOptions;
	public GameObject RangeObject;
	public CircleCollider2D TowerRange;
	public Projectile Projectile;
	private Queue<GameObject> targets = new Queue<GameObject>();
	private GameObject target;
	private bool isBuilt = false;
	private bool menuState = false;
	private bool mouseOver = false;
	private float projectileSpeed;
	private float projectileDamage;
	private float projectileFireRate;
	private bool multipleProjectiles;
	private int moneySpent;
	private float nextFire;

	public void ToggleMenu(){
		menuState = !menuState;
		if(isBuilt){
			for (int i = 0; i < TowerOptions.Length; i++) {
				TowerOptions[i].SetActive(menuState);
			}
		}
		else {
			for (int i = 0; i < BuildOptions.Length; i++) {
				BuildOptions[i].SetActive(menuState);
			}
		}

	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy"){
			targets.Enqueue(col.gameObject);
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Enemy"){
			target = null;
		}
	}

	private void Shoot(){
		if(target != null && Time.time > nextFire && isBuilt){
			Projectile ProjectileInstance = Instantiate (Projectile, transform.position, Quaternion.identity) as Projectile;
			ProjectileInstance.MoveSpeed = projectileSpeed;
			ProjectileInstance.Target = target;
			ProjectileInstance.Damage = projectileDamage;
			nextFire = Time.time + projectileFireRate;
		}
		if (target == null && targets.Count > 0 && isBuilt){
			target = targets.Dequeue();
		}
	}

	public void ChooseTower(string towerName){
		ToggleMenu();
		TowerRange.radius = RangeObject.transform.localScale[0] / 2;
		RangeObject.SetActive(false);
		isBuilt = true;
        switch (towerName)
        {
            case "Archery":
                projectileFireRate = 0.5f;
                projectileSpeed = 1000f;
                projectileDamage = 50f;
                break;
            case "Canon":
                projectileFireRate = 0.5f;
                projectileSpeed = 1000f;
                projectileDamage = 50f;
                break;
            case "Trebuchet":
                projectileFireRate = 0.5f;
                projectileSpeed = 1000f;
                projectileDamage = 50f;
                break;
            case "Wizard":
                projectileFireRate = 0.5f;
                projectileSpeed = 1000f;
                projectileDamage = 50f;
                break;
        }
	}

	public void OnMouseEnter() { 
		mouseOver = true; 
	} 

	public void OnMouseExit() { 
		mouseOver = false; 
	}

	void Start(){
		TowerRange = TowerRange.GetComponent<CircleCollider2D>();
		nextFire = Time.time;
	}

	void Update(){
		if (Input.GetMouseButtonDown(0) && !mouseOver){
			menuState = true;
			ToggleMenu();
		}
		Shoot();
	}
}
