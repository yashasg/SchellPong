using UnityEngine;
using System.Collections;

public class MovementP2 : MonoBehaviour {
	public float m_speed;
	private bool m_leftKeyPressed;
	private bool m_rightKeyPressed;
	Rigidbody2D thisRigidBody;
	Vector2 m_myPosition;
	// Use this for initialization
	void Start () {
		resetPaddles ();
	}
	public void resetPaddles (){
		gameObject.transform.position = new Vector2(0.0f,4.77f);;
		m_leftKeyPressed = false;
		m_rightKeyPressed = false;
		thisRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		updatePosition ();

}
	/// <summary>
	/// Updates the transform of the body.
	/// </summary>
	void updatePosition(){

		checkForKeyPress ();
		Vector2 currentPosition = thisRigidBody.position;
		if (m_leftKeyPressed)
			thisRigidBody.MovePosition (new Vector2(Mathf.Clamp(currentPosition.x-m_speed,-4.7f,4.7f),currentPosition.y));
		if(m_rightKeyPressed)
			thisRigidBody.MovePosition(new Vector2(Mathf.Clamp(currentPosition.x+m_speed,-4.7f,4.7f),currentPosition.y));
		
	
	}
	/// <summary>
	/// Checks for key press.
	/// </summary>
	void checkForKeyPress(){
		//check if left key is still pressed
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{		
			m_leftKeyPressed = true;

		}
		//check if left key is released
		else if(Input.GetKeyUp(KeyCode.LeftArrow))
		{		
			m_leftKeyPressed = false;

		}
		//check if right key is still pressed

		if(Input.GetKeyDown(KeyCode.RightArrow)){

			m_rightKeyPressed = true;
		}
		//check if right key is released.
		else if(Input.GetKeyUp(KeyCode.RightArrow)) {

			m_rightKeyPressed = false;
		}

	}
}