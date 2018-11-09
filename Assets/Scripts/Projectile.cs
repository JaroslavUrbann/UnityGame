using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float MoveSpeed;
	public float Damage;
	public float aimOffset = 0;
	Vector2 moveDirection;
	Rigidbody2D rb;
	public GameObject Target;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector3 pos = new Vector3(transform.position[0] + Random.Range(-aimOffset, aimOffset), transform.position[1] + Random.Range(-aimOffset, aimOffset), transform.position[2]);
		moveDirection = (Target.transform.position - pos).normalized * MoveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);

		// rotates projectile
		Vector2 direction = Target.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 500f * Time.deltaTime);

		Destroy (gameObject, 4f);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<Enemy>().Health -= Damage;
			Destroy (gameObject);
		}
	}
}
