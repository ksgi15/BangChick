using UnityEngine;
using System.Collections;

public class ChicksMovement : MonoBehaviour 
{
	public static ChicksMovement current;
	public float yMovementRate = 20.0f;

	public bool _isMoving = false;

	void Awake()
	{
		current = this;
	}
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		// Debug.Log("X-axis: " + gameObject.transform.position.x + " Y-axis: " + gameObject.transform.position.y);

		Vector3 objPostition = gameObject.transform.position;

		if (objPostition.y > 1200)
		{
			gameObject.SetActive(false);
			_isMoving = false;
		}
		else if(_isMoving)
		{
			objPostition.y += yMovementRate;
			gameObject.transform.position = objPostition;
		}
	}
}
