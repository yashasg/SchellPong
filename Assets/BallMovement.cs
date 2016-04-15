using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	Rigidbody2D m_ballRigidBody;
	Vector2 m_Velocity;
	// Use this for initialization
	void Start () {
		m_ballRigidBody = GetComponent<Rigidbody2D> ();
		m_Velocity = Vector2.down;
	}
	
	// Update is called once per frame
	void Update () {
		m_ballRigidBody.MovePosition (m_Velocity);
		m_Velocity += Vector2.down;
	}
}
