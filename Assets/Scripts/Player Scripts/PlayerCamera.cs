using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	[Header("Variables to Change")]
	public float moveSpeed; //The speed in which the camera moves
	
	[Tooltip("This is the end point for the camera, use an empty game object for this!")]
	public GameObject target; //The end point for the camera

	[Tooltip("This is where you set the prefab for the colliders that stop the player going to far back and forward")]
	public GameObject colliderPrefab; //Collider prefabs to stop player from moving behind or too far infront. 
	[Tooltip("This is the offset used by the colliders")]
	public Vector3 frontOffset; //Vector to create offsets for colliders.
	public Vector3 backOffset; //Vector to create offsets for colliders.
	
	[HideInInspector]
	GameObject playerObject; //The player Object

	void Start()
	{
		playerObject = GameObject.FindWithTag("Player"); //find and assign player object through tag.
		//offset = new Vector3(0, 0, 20); //Creates an offset for the collider positions around the player
		//These lines spawn in colliders and make them children of the camera. 
		GameObject BKClone = Instantiate(colliderPrefab, playerObject.transform.position - backOffset, Quaternion.identity);
		BKClone.transform.parent = this.transform;
		GameObject FRClone = Instantiate(colliderPrefab, playerObject.transform.position + frontOffset, Quaternion.identity);
		FRClone.transform.parent = this.transform;
	}
	void Update(){
		Move();
	}

	void Move(){
		var step = moveSpeed * Time.deltaTime; //Creates a smooth move speed
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step); //Moves the camera towards the end point.
	}

	//You can ignore this, just another way of doing moving camera. 
	#region oldVersion
	/*
	GameObject playerTarget;
	Vector3 offSet;

	// Start is called before the first frame update
	void Start()
	{
		playerTarget = GameObject.FindWithTag("Player");
		offSet = transform.position - playerTarget.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position + offSet, 0.01f);
	}*/
	#endregion
}
