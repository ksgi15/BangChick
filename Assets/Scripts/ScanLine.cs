using UnityEngine;
using System.Collections;

public class ScanLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {

		/*switch (other.gameObject.GetComponent<MovingObject> ()._objectType)
		{
		case MovingObject.ObjectTypeEnum.BlueChix:
			if(Input.GetKeyDown("a")) {
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ChicksMovement>()._isMoving = true;
			}
			break;
		case MovingObject.ObjectTypeEnum.GreenChix:
			if(Input.GetKeyDown("s")) {
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ChicksMovement>()._isMoving = true;
			}
			break;
		case MovingObject.ObjectTypeEnum.RedChix:
			if(Input.GetKeyDown("d")) {
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ChicksMovement>()._isMoving = true;
			}
				
			break;
		}*/

		GameObject GameManagerRef = GameObject.Find("GameManager");

		if (gameObject.name == "ScanLineRed") {
			if(Input.GetKeyDown("a")) {
				//Animate Chick
				HenMovement.current.attackLeft();

				// Put Object back to pool
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ChicksMovement>()._isMoving = false;

				// Increase the score
				GameObject.Find("GameManager").GetComponent<_GameManager>()._scoreCounter++;

				// Check for Powerups
				switch (other.gameObject.GetComponent<MovingObject> ()._objectType)
				{
				case MovingObject.ObjectTypeEnum.Live:
					GameManagerRef.GetComponent<_GameManager>().SpawnLives();
					break;
				case MovingObject.ObjectTypeEnum.Magnet:
					GameManagerRef.GetComponent<_GameManager>().ActivateMagnet(other.gameObject.transform.position.x);
					break;
				case MovingObject.ObjectTypeEnum.Barrier:
					GameManagerRef.GetComponent<_GameManager>().ActivateBarrier();
					break;
				}

			}
		} else if (gameObject.name == "ScanLineGreen") {
			if(Input.GetKeyDown("s")) {
				//Animate Chick
				// RUN

				// Put Object back to pool
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ChicksMovement>()._isMoving = false;

				// Increase the score
				GameManagerRef.GetComponent<_GameManager>()._scoreCounter++;

				// Check for Powerups
				switch (other.gameObject.GetComponent<MovingObject> ()._objectType)
				{
				case MovingObject.ObjectTypeEnum.Live:
					GameManagerRef.GetComponent<_GameManager>().SpawnLives();
					break;
				case MovingObject.ObjectTypeEnum.Magnet:
					GameManagerRef.GetComponent<_GameManager>().ActivateMagnet(other.gameObject.transform.position.x);
					break;
				case MovingObject.ObjectTypeEnum.Barrier:
					GameManagerRef.GetComponent<_GameManager>().ActivateBarrier();
					break;
				}
			}
		} else if (gameObject.name == "ScanLineBlue") {
			if(Input.GetKeyDown("d")) {
				//Animate Chick
				HenMovement.current.attackRight();

				// Put Object back to pool
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ChicksMovement>()._isMoving = false;

				// Increase the score
				GameObject.Find("GameManager").GetComponent<_GameManager>()._scoreCounter++;

				// Check for Powerups
				switch (other.gameObject.GetComponent<MovingObject> ()._objectType)
				{
				case MovingObject.ObjectTypeEnum.Live:
					GameManagerRef.GetComponent<_GameManager>().SpawnLives();
					break;
				case MovingObject.ObjectTypeEnum.Magnet:
					GameManagerRef.GetComponent<_GameManager>().ActivateMagnet(other.gameObject.transform.position.x);
					break;
				case MovingObject.ObjectTypeEnum.Barrier:
					GameManagerRef.GetComponent<_GameManager>().ActivateBarrier();
					break;
				}
			}
		}

		
		/*if (Input.GetKeyDown ("space"))
			print ("space key was pressed");
		Destroy(other.gameObject);*/
	}

	void OnTriggerExit2D(Collider2D other) {
		GameObject GameManagerRef = GameObject.Find("GameManager");
		GameManagerRef.GetComponent<_GameManager>().CheckForGameOver();

	}
}
