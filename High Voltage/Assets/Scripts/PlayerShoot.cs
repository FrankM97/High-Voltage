using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public Transform firePoint;
	public GameObject nailPrefab;

	public float nailForce = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			Shoot();
		}
    }

	void Shoot()
	{
		GameObject nail;
		if (this.GetComponent<SpriteRenderer>().flipX)
		{
			Vector3 flippedPosition = new Vector3(-firePoint.localPosition.x + transform.position.x, firePoint.position.y, firePoint.position.z);
		    nail = Instantiate(nailPrefab, flippedPosition, firePoint.rotation);
			Rigidbody2D rb = nail.GetComponent<Rigidbody2D>();
			rb.AddForce(-firePoint.right * nailForce, ForceMode2D.Impulse);
		}
		else
		{
			nail = Instantiate(nailPrefab, firePoint.position, firePoint.rotation);
			Rigidbody2D rb = nail.GetComponent<Rigidbody2D>();
			rb.AddForce(firePoint.right * nailForce, ForceMode2D.Impulse);
		}

		Destroy(nail, 1.5f);
	}
}
