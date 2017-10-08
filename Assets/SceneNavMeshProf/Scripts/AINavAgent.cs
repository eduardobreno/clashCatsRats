using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SceneNavMeshProf
{
	public class AINavAgent : MonoBehaviour
	{
		[Header ("Gameobject waypoints ")]
		public Transform waypointObject;


		private NavMeshAgent navAgent;
		private List<Transform> waypoints = new List<Transform> ();
		bool walkBack = false;
		int wayPointIndex = 0;

		void Start ()
		{
			navAgent = GetComponent<NavMeshAgent> ();


			initWayPoints ();
		}

		void Update ()
		{
			List<Transform> target = GetComponent<FieldOfView> ().visibleTargets;
			if (target.Count == 0) {
				checkNextWayPoint ();
			} else {
				navAgent.destination = target [0].transform.position;
			}
		}

		void initWayPoints ()
		{
			Transform children = waypointObject;
			for (int i = 0; i < children.childCount; i++) {
				Transform child = children.GetChild (i).transform;
				waypoints.Add (child);
			}
		}

		void checkNextWayPoint ()
		{
			if (Vector3.Distance (transform.position, waypoints [wayPointIndex].position) > 1) {
				navAgent.destination = waypoints [wayPointIndex].position;
			} else {
				wayPointIndex = (walkBack) ? --wayPointIndex : ++wayPointIndex;
				if (wayPointIndex == (waypoints.Count - 1))
					walkBack = true;
				if (wayPointIndex == 0)
					walkBack = false;
			}
		}
	}
}