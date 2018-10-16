using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float MoveSpeed;
	public float Damage;
	Vector2 moveDirection;
	Rigidbody2D rb;
	public GameObject Target;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		moveDirection = (Target.transform.position - transform.position).normalized * MoveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 2f);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<Enemy>().Health -= Damage;
			Destroy (gameObject);
		}
	}
}
