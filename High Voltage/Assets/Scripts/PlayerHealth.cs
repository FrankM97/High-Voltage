using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{

	[SerializeField] private int health = 3;
	public TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
		UpdateUI();
    }

    private void OnCollisionEnter2D(Collision2D hit)
	{
        if(hit.gameObject.tag == "Enemy")
		{
			health--;
			UpdateUI();

            if(health <= 0)
			{
				Destroy(gameObject);
			}
		}

		if (hit.gameObject.tag == "Projectile")
		{
			health--;
			UpdateUI();
			Destroy(hit.gameObject);

			if (health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

    void UpdateUI()
	{
		textComponent.text = "Health: " + health.ToString();
	}


}
