using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
	
    public Transform enemy;
    public Vector2 distToEnemy;

	public Animator animator;

	public bool isAlly = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update()
    {
		if (isAlly == false)
		{
			transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);

		}
        else
		{
			transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
		}

		distToEnemy = transform.position - enemy.position;

		float dot = Vector2.Dot(distToEnemy.normalized, transform.right); //Get distance from enemy to player

		float newScale = (dot > 0 ? 1 : -1) * Mathf.Abs(transform.localScale.x);

		transform.localScale = new Vector2(newScale, transform.localScale.y);

	}

    private void OnCollisionEnter2D(Collision2D hit)
	{
        if(hit.gameObject.tag == "Player")
		{
            if(!isAlly)
            {
				Destroy(gameObject);
			}
		}
        if(hit.gameObject.tag == "Nail")
		{
			Destroy(hit.gameObject);
			isAlly = true;
			this.gameObject.tag = "Ally";
			this.gameObject.layer = 9;
			animator.SetBool("Ally", true);
		}
		if (isAlly)
		{
			if (hit.gameObject.tag == "Enemy")
			{
				Destroy(hit.gameObject);
			}
		}
	}

 
}
