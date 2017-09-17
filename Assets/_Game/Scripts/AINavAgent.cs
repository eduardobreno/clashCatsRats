using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavAgent : MonoBehaviour
{
	[Header ("GameObject with path to be followed")]
	public GameObject waypoint;

	private NavMeshAgent navAgent;
	private List<Transform> waypoints = new List<Transform> ();
	public float speed;
	bool walkBack = false;
	int wayPointIndex = 0;
	private Animator anim;


	Vector3 prevLoc = Vector3.zero;

	void Start ()
	{
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponentInChildren<Animator> ();

		initWayPoints ();
	}

	void Update ()
	{
		List<Transform> target = GetComponent<FieldOfView> ().visibleTargets;
		if (target.Count == 0) {
			checkNextWayPoint ();
		} else {
			walkTo (target [0].transform.position);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			print ("FIGHT");
		}

	}

	void initWayPoints ()
	{
		Transform children = waypoint.transform;
		for (int i = 0; i < children.childCount; i++) {
			Transform child = children.GetChild (i).transform;
			waypoints.Add (child);
		}
	}

	void checkNextWayPoint ()
	{
		if (waypoints.Count > 1) {
			if (Vector3.Distance (transform.position, waypoints [wayPointIndex].position) > 1) {
				if (waypoints.Count - 1 == wayPointIndex) {
					GetComponent<Animator> ().SetTrigger ("HandAttackRight");
					GetComponent<Animator> ().SetBool ("walk", false);
				} else {
					walkTo (waypoints [wayPointIndex].position);
				}
			} else {
				wayPointIndex = (walkBack) ? --wayPointIndex : ++wayPointIndex;
				if (wayPointIndex == (waypoints.Count - 1))
					walkBack = true;
				if (wayPointIndex == 0)
					walkBack = false;
			}
		}
	}

	void walkTo (Vector3 position)
	{
		navAgent.destination = position;
		GetComponent<Animator> ().SetBool ("walk", true);
	}

	#if UNITY_EDITOR
	void OnDrawGizmosSelected () {
			// Draws a blue line from this transform to the target
			Gizmos.color = Color.white;
			Transform children = waypoint.transform;
			for (int i = 0; i < children.childCount-1; i++) {
				Gizmos.DrawLine (children.GetChild (i).transform.position, children.GetChild (i+1).transform.position);
			}
	}
	#endif
}
