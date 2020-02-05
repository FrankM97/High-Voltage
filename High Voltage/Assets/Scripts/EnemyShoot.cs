using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	public Transform firePoint;
	public GameObject projectile;
	public Animator animator;

	public float projectileForce = 3.5f;

	private float timeBetweenShots;
	public float startTimeBetweenShots;
	// Start is called before the first frame update
	void Start()
	{
		timeBetweenShots = startTimeBetweenShots;
	}

	// Update is called once per frame
	void Update()
	{
		if (timeBetweenShots <= 0)
		{
			Shoot();
			timeBetweenShots = startTimeBetweenShots;
		}
		else
		{
			timeBetweenShots -= Time.deltaTime;
            if(timeBetweenShots < 1.5f)
			{
				animator.SetBool("Attack", false);
			}
		}

		void Shoot()
		{
			animator.SetBool("Attack", true);
			GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
			bullet.transform.localScale = new Vector2(this.transform.localScale.normalized.x * bullet.transform.localScale.x, bullet.transform.localScale.y);
			
            if(this.gameObject.tag == "Ally")
			{
				bullet.layer = 9;
				bullet.gameObject.tag = "Ally";
			}
            Destroy(bullet, 2f);

			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

			rb.AddForce(firePoint.right * bullet.transform.localScale.normalized.x * projectileForce, ForceMode2D.Impulse);
		}
	}
}
