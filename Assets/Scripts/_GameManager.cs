using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour
{	
	public GameObject _scanLine;

	public float _chickSpawnRate = 1.0f;
	private float _chickSpawnCounter = 0.0f;

	private float _difficultyCounter = 0.0f;

	public Text _scoreCounterDisplayText;
	public Text _gameOverDisplayText;
	public int _scoreCounter = 1;
	 
	public List<GameObject> _lives = new List<GameObject>();
	private int _noOfLives = 1;

	private float _powerUpDelayer;

	private bool _gameOver = false;

	// Powerups
	private bool _magnetActivated = false;
	private float _magnetPositionX = 0.0f;

	// Use this for initialization
	void Start()
	{
		_scanLine = GameObject.Find("ScanLine");

		if (_lives.Count == 0) {
			GameObject live;

			for(int i = 0; i < 3; i++) {
				switch(i) {
				case 0:
					live = GameObject.Find("LivesOne");
					_lives.Add (live);
					break;
				case 1:
					live = GameObject.Find("LivesTwo");
					_lives.Add (live);
					break;
				case 2:
					live = GameObject.Find("LivesThree");
					_lives.Add (live);
					break;
				}
			}
		}
}
	
	// Update is called once per frame
	void Update()
	{
		if (_gameOver)
			return;

		_chickSpawnCounter += Time.deltaTime;

		_difficultyCounter += Time.deltaTime;

		_powerUpDelayer += Time.deltaTime;

		// Sets the difficulty
		//SetDifficulty();

		// Spawn the chix yo!
		SpawnChix();

		// Update score
		_scoreCounterDisplayText.text = _scoreCounter.ToString();

	}

	void SetDifficulty()
	{
		if (_difficultyCounter > 2.0f) {
			
			if(_chickSpawnRate > 0.3f) {
				_chickSpawnRate -= 0.2f;
				ChicksMovement.current.yMovementRate += 30.0f;
				
				_difficultyCounter = 0.0f;
			}
		} 
	}

	void SpawnChix()
	{
		if(_chickSpawnCounter > _chickSpawnRate)
		{
			GameObject chick = ChickPool.current.GetChick();
			Vector3 tmpChickPosition = chick.transform.position;
			tmpChickPosition.y = -1200.0f;

			switch(Random.Range(0,3))
			{
			case 0:
				tmpChickPosition.x = -360.0f;
				
				break;
			case 1:
				tmpChickPosition.x = 0.0f;
				
				break;
			case 2:
				tmpChickPosition.x = 360.0f;
				
				break;
			}

			if(_magnetActivated)
			{
				tmpChickPosition.x = _magnetPositionX;
			}

			switch(Random.Range(0,6))
			{
			case 0:
				chick.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.BlueChix;
				chick.renderer.material.color = Color.blue;
				break;
			case 1:
				chick.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.GreenChix;
				chick.renderer.material.color = Color.green;
				break;
			case 2:
				chick.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.RedChix;
				chick.renderer.material.color = Color.red;
				break;
			case 3:
				chick.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.Live;
				chick.renderer.material.color = Color.cyan;
				break;
			case 4:
				chick.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.Magnet;
				chick.renderer.material.color = Color.grey;
				break;
			case 5:
				chick.GetComponent<MovingObject>()._objectType = MovingObject.ObjectTypeEnum.Barrier;
				chick.renderer.material.color = Color.yellow;
				break;
			}

			chick.transform.position = tmpChickPosition;
			chick.SetActive(true);

			chick.gameObject.GetComponent<ChicksMovement>()._isMoving = true;
			
			// Reset Chix spawn rate
			_chickSpawnCounter = 0.0f;
		}
	}

	public void SpawnLives()
	{
		if (_powerUpDelayer < 1.0f && _noOfLives > 3)
			return;

		_powerUpDelayer = 0.0f;

		foreach (GameObject live in _lives)
		{
			if(!live.gameObject.GetComponent<LiveObject>()._isFilled) {
				live.gameObject.GetComponent<LiveObject>()._isFilled = true;
				_noOfLives++;
				return;
			}
		}
	}

	public void CheckForGameOver()
	{
		return;
		if (_noOfLives == 1) {
			// Game Over
			_lives[0].gameObject.GetComponent<LiveObject>()._isFilled = false;
			_gameOver = true;
			_gameOverDisplayText.gameObject.SetActive(true);

			_noOfLives--;
		} else if(_noOfLives > 0){
			// Deduct Lives

			int tmpLivesIndex = _noOfLives - 1;
			_lives[tmpLivesIndex].gameObject.GetComponent<LiveObject>()._isFilled = false;

			_noOfLives--;
		}
	}

	public void ActivateMagnet(float positionX)
	{
		_magnetActivated = true;
		_magnetPositionX = positionX;
	}

	public void ActivateBarrier()
	{
		
	}
}
