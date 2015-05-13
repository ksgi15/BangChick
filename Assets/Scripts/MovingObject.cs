using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{
	public enum ObjectTypeEnum
	{
		RedChix = 0,
		GreenChix,
		BlueChix,
		Live,
		Magnet,
		Barrier
	}

	public ObjectTypeEnum _objectType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
