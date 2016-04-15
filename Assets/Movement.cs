using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float m_speed;
	private bool m_leftKeyPressed;
	private bool m_rightKeyPressed;
	// Use this for initialization
	void Start () {
		m_leftKeyPressed = false;
		m_rightKeyPressed = false;
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
		CharacterController thisController = GetComponent<CharacterController>();
		if (m_leftKeyPressed)
			thisController.SimpleMove (Vector2.left * m_speed);
		if(m_rightKeyPressed)
			thisController.SimpleMove(Vector2.right*m_speed);
		
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log("Hit Wall");
	}
	/// <summary>
	/// Checks for key press.
	/// </summary>
	void checkForKeyPress(){
		//check if left key is still pressed
		
		if(Input.GetKeyDown(KeyCode.A))
		{		
			m_leftKeyPressed = true;

		}
		//check if left key is released
		else if(Input.GetKeyUp(KeyCode.A))
		{		
			m_leftKeyPressed = false;

		}
		//check if right key is still pressed

		if(Input.GetKeyDown(KeyCode.D)){

			m_rightKeyPressed = true;
		}
		//check if right key is released.
		else if(Input.GetKeyUp(KeyCode.D)) {

			m_rightKeyPressed = false;
		}

	}
}