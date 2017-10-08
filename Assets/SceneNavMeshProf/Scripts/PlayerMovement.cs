using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneNavMeshProf
{
	public class PlayerMovement : MonoBehaviour
	{

		private Rigidbody rigidBody;
		public float speed;

		void Start ()
		{
			rigidBody = GetComponent<Rigidbody> ();
		}

		void Update ()
		{
			Move ();
		}

		void Move ()
		{
			Vector2 direction = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			rigidBody.velocity = new Vector3 (speed * direction.x, rigidBody.velocity.y, speed * direction.y);
		}
	}

}