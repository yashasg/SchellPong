using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float m_speed;
    public bool m_IsPlayer1;
	private bool m_leftKeyPressed;
	private bool m_rightKeyPressed;
	Rigidbody2D thisRigidBody;
	// Use this for initialization
	void Start () {
		resetPaddles ();
	}
	public void resetPaddles (){
		gameObject.transform.position = new Vector2(0.0f, gameObject.transform.position.y);
		m_leftKeyPressed = false;
		m_rightKeyPressed = false;
		thisRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		updatePosition ();

}
	/// <summary>
	/// Updates the transform of the body.
	/// </summary>
	void updatePosition(){

		Vector2 currentPosition = thisRigidBody.position;
        if (m_leftKeyPressed)
            //thisRigidBody.MovePosition (new Vector2(Mathf.Clamp(currentPosition.x-m_speed,-4.7f,4.7f),currentPosition.y));
            thisRigidBody.velocity = Vector2.left * m_speed;

        else if (m_rightKeyPressed)
            //thisRigidBody.MovePosition(new Vector2(Mathf.Clamp(currentPosition.x+m_speed,-4.7f,4.7f),currentPosition.y));
            thisRigidBody.velocity = Vector2.right * m_speed;
        else
            thisRigidBody.velocity = Vector2.zero;


    }

    ///
    /// 
    /// 
    void Update()
    {
        checkForKeyPress();

    }
    /// <summary>
    /// Checks for key press.
    /// </summary>
    void checkForKeyPress(){
        //check if left key is still pressed
        if (m_IsPlayer1)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                m_leftKeyPressed = true;

            }
            //check if left key is released
            else if (Input.GetKeyUp(KeyCode.A))
            {
                m_leftKeyPressed = false;

            }
            //check if right key is still pressed

            if (Input.GetKeyDown(KeyCode.D))
            {

                m_rightKeyPressed = true;
            }
            //check if right key is released.
            else if (Input.GetKeyUp(KeyCode.D))
            {

                m_rightKeyPressed = false;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_leftKeyPressed = true;

            }
            //check if left key is released
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                m_leftKeyPressed = false;

            }
            //check if right key is still pressed

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                m_rightKeyPressed = true;
            }
            //check if right key is released.
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {

                m_rightKeyPressed = false;
            }


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

	}
}