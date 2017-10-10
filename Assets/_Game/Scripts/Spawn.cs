using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn : MonoBehaviour
{
	public enum SIDES {SideA,SideB}

	public bool isAutomatic = true;
	public GameObject spawnA;
	public GameObject spawnB;
	public SIDES player;
	public SIDES computer;
	public GameObject enemy;
	private GameObject p1;
	private GameObject p2;

	void Start ()
	{
		if (isAutomatic) {
			InvokeRepeating ("SpawnAutomatic", 3f, 3f);
		}

	}

	public void SpawnObject (GameObject player)
	{
		p1 = Instantiate (player, spawnA.transform.position, spawnA.transform.rotation);
		p2 = Instantiate (player, spawnB.transform.position, spawnB.transform.rotation);
	}
	public void destroyObject(){
		Destroy (p1);
		Destroy (p2);
	}

	void SpawnAutomatic ()
	{
		GameObject spawnPoint;
		if (computer == SIDES.SideB) {
			spawnPoint = spawnB;
		} else {
			spawnPoint = spawnA;
		}
			
		Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
}
