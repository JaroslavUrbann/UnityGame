using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenus : MonoBehaviour {

    public Sprite[] TowerSprites;
	public GameObject[] TowerOptions;
	public GameObject[] BuildOptions;
	public GameObject RangeObject;
	public CircleCollider2D TowerRange;
	public Projectile[] Projectiles;
	private int towerIndex;
	private Queue<GameObject> targets = new Queue<GameObject>();
	private GameObject target;
	private bool isBuilt = false;
	private bool menuState = false;
	private bool mouseOver = false;
	private float projectileSpeed;
	private float projectileDamage;
	private float projectileFireRate;
	private bool multipleProjectiles;
	private float price;
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
		if(target != null && isBuilt){
			// rotates tower
			Vector2 direction = target.transform.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);

			if(Time.time > nextFire){
				if(towerIndex == 3){
					for(int i=0;i<3;i++){
						Projectile ProjectileInstance = Instantiate (Projectiles[towerIndex], transform.position, Quaternion.identity) as Projectile;
						ProjectileInstance.MoveSpeed = projectileSpeed;
						ProjectileInstance.Target = target;
						ProjectileInstance.Damage = projectileDamage;
						ProjectileInstance.aimOffset = 2f;
						nextFire = Time.time + projectileFireRate;
					}
				}
				else{
					Projectile ProjectileInstance = Instantiate (Projectiles[towerIndex], transform.position, Quaternion.identity) as Projectile;
					ProjectileInstance.MoveSpeed = projectileSpeed;
					ProjectileInstance.Target = target;
					ProjectileInstance.Damage = projectileDamage;
					nextFire = Time.time + projectileFireRate;
				}
			}
		}
		if (target == null && targets.Count > 0 && isBuilt){
			target = targets.Dequeue();
		}
	}

	public void ChooseTower(string towerName){
        switch (towerName)
        {
            case "Unicorn":
				price = 100;
                projectileFireRate = 0.5f;
                projectileSpeed = 12f;
                projectileDamage = 16f;
				towerIndex = 0;
                break;
            case "Orange":
				price = 90;
                projectileFireRate = 2f;
                projectileSpeed = 16f;
                projectileDamage = 50f;
				towerIndex = 1;
                break;
            case "Wizard":
				price = 120;
                projectileFireRate = 0.2f;
                projectileSpeed = 40f;
                projectileDamage = 3f;
				towerIndex = 2;
                break;
            case "Trebuchet":
				price = 150;
                projectileFireRate = 4f;
                projectileSpeed = 7f;
                projectileDamage = 70f;
				towerIndex = 3;
                break;
			case "Sell":
				Money.Amount += price / 2;
				gameObject.GetComponent<Image>().sprite = TowerSprites[4];
				ToggleMenu();
				isBuilt = false;
				return;
			case "Upgrade":
				if(!Money.Buy(20))
					return;
				price += 20;
				projectileFireRate = projectileFireRate * 0.9f;
                projectileSpeed = projectileSpeed  * 1.1f;
                projectileDamage = projectileDamage * 1.1f;
				TowerRange.radius = TowerRange.radius * 1.1f;
				ToggleMenu();
				return;
        }
		if(!Money.Buy(price))
			return;
		Debug.Log("got here");
		gameObject.GetComponent<Image>().sprite = TowerSprites[towerIndex];
		ToggleMenu();
		TowerRange.radius = RangeObject.transform.localScale[0] / 2;
		RangeObject.SetActive(false);
		isBuilt = true;
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
