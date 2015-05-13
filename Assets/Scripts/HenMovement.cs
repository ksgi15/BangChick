using UnityEngine;
using System.Collections;

public class HenMovement : MonoBehaviour {

	public static HenMovement current;
	private Animator anim;

	private float _animationCounter = 0.0f;
	private bool _startAnimationCounter = false;
	void Awake()
	{
		current = this;
	}

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void attackLeft() 
	{
		_startAnimationCounter = true;

		anim.Play("AttackLeftHen");
	}

	public void attackRight()
	{
		_startAnimationCounter = true;
		
		anim.Play("AttackRightHen");
	}

	private IEnumerator WaitForAnimation(Animation animation) {
		do {
			yield return null;
		} while(animation.isPlaying);
	}
}
