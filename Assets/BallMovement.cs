using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
	Rigidbody2D m_ballRigidBody;
	public float m_ballSpeed;
	public float m_ConstantVelocity=5.0f;
	public Text m_P1;
	public Text m_P2;
	int m_P1Count,m_P2Count;
	public GameObject m_player1;
	public GameObject m_player2;

	// Use this for initialization
	void Start () {
		resetGame ();
         

	}

	void resetGame(){
		//reset ball
		m_ConstantVelocity = 5.0f;
		m_ballRigidBody = GetComponent<Rigidbody2D> ();
		transform.position = Vector2.zero;
		transform.rotation = new Quaternion (0, 0, 0,0);
		m_ballRigidBody.velocity = Vector2.down * m_ConstantVelocity;
		m_ballRigidBody.angularVelocity =0.0f;
		//reset p1 paddle
		m_player1.GetComponent<Movement>().resetPaddles();
		//reset p2 paddle
		m_player2.GetComponent<Movement>().resetPaddles();

	}
	void OnCollisionEnter2D(Collision2D i_collision){
	Debug.Log (i_collision.gameObject.tag);
        //if the ball collided with the player
		if (i_collision.gameObject.tag.Equals ("Player")) {
            //get the velocity vector of ball and paddle and get a reflection vector off the ball
            //increment the speed of the reflection vector with half of the paddle speed.
            Vector2 myVelocity = m_ballRigidBody.velocity;
            Vector2 paddleVelocity = i_collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            m_ConstantVelocity += 0.5f;
            Vector2 reflectionVec = Vector2.Reflect (myVelocity, Vector2.up);
            reflectionVec = new Vector2(reflectionVec.x + (paddleVelocity.x/2), reflectionVec.y);

            m_ballRigidBody.velocity = reflectionVec.normalized* m_ConstantVelocity;

        }
		else if(i_collision.gameObject.tag.Equals ("BottomWall")) {
			m_P2Count++;
			m_P2.text = "P2 Score: " + m_P2Count;
			resetGame();
		}
		else if(i_collision.gameObject.tag.Equals ("TopWall")) {
			m_P1Count++;
			m_P1.text = "P1 Score: " + m_P1Count;
			resetGame();
		}

	}
}
