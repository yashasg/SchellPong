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
		m_ballRigidBody.velocity = Vector2.down;
		m_ballRigidBody.angularVelocity =0.0f;
		//reset p1 paddle
		m_player1.GetComponent<Movement>().resetPaddles();
		//reset p2 paddle
		m_player2.GetComponent<MovementP2>().resetPaddles();

	}
	// Update is called once per frame
	void FixedUpdate () {

		m_ballRigidBody.velocity = m_ballRigidBody.velocity.normalized * m_ConstantVelocity;
	}
	void OnCollisionStay2D(Collision2D i_collision){
	Debug.Log (i_collision.gameObject.tag);

		if (i_collision.gameObject.tag.Equals ("Player")) {
			Vector2 myPosition = m_ballRigidBody.position;
			m_ConstantVelocity += 0.5f;
			Vector2 reflectionVec = Vector2.Reflect (myPosition, Vector2.up);
			m_ballRigidBody.AddForce (reflectionVec.normalized * m_ballSpeed);
		}
		else if(i_collision.gameObject.tag.Equals ("LeftWall")) {
			Vector2 myPosition = m_ballRigidBody.position;
			Vector2 reflectionVecNorm = Vector2.Reflect (myPosition, Vector2.right).normalized;
			m_ballRigidBody.AddForce (reflectionVecNorm * m_ballSpeed/4);
		}
		else if(i_collision.gameObject.tag.Equals ("RightWall")) {
			Vector2 myPosition = m_ballRigidBody.position;
			Vector2 reflectionVecNorm = Vector2.Reflect (myPosition, Vector2.left).normalized;
			m_ballRigidBody.AddForce (reflectionVecNorm * m_ballSpeed/4);
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
