using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    
	[SerializeField] private CircleCollider2D checkArea;
	[SerializeField] private LayerMask groundMask;
	private bool isGrounded;

	public bool IsGrounded
	{
		get { return isGrounded; }
	}

	private void Update()
	{
		isGrounded = CheckGround();
	}

    private bool CheckGround()
	{
		Vector3 center = checkArea.transform.position + checkArea.transform.TransformPoint(checkArea.offset);
		Collider2D possiblyGround = Physics2D.OverlapCircle(center, checkArea.radius, groundMask.value);
		Debug.Log( possiblyGround + (possiblyGround == null ? "null" : possiblyGround.name ));
		return possiblyGround != null;
	}

}
