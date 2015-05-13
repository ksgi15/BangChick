using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChickPool : MonoBehaviour
{
	public static ChickPool current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;
	
	List<GameObject> pool;
	
	void Awake()
	{
		current = this;
	}
	
	// Use this for initialization
	void Start()
	{
		pool = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = Instantiate(pooledObject) as GameObject;

			obj.SetActive(false);
			pool.Add(obj);
		}
	}
	
	public GameObject GetChick()
	{
		for (int i = 0; i < pooledAmount; i++)
		{
			if(!pool[i].activeInHierarchy)
				return pool[i];
		}
		
		if (willGrow)
		{
			GameObject obj = Instantiate(pooledObject) as GameObject;
			switch(Random.Range(0,3))
			{
			case 0:
				obj.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.BlueChix;
				obj.renderer.material.color = Color.blue;
				break;
			case 1:
				obj.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.GreenChix;
				obj.renderer.material.color = Color.green;
				break;
			case 2:
				obj.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.RedChix;
				obj.renderer.material.color = Color.red;
				break;
			}
			pool.Add(obj);
			return obj;
		}
		
		return null;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
