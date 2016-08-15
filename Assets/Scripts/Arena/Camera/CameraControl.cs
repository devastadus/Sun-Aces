using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour
{
	public float m_DampTime = 0.2f;
	// Approximate time for the camera to refocus.
	public float m_ScreenEdgeBuffer = 4f;
	// Space between the top/bottom most target and the screen edge.
	public float m_MinSize = 6.5f;
	// The smallest orthographic size the camera can be.
	public float arenaRange = 20f;
	List<Transform> targets = new List<Transform> ();

	private Camera m_Camera;
	// Used for referencing the camera.
	private float m_ZoomSpeed;
	// Reference speed for the smooth damping of the orthographic size.
	private Vector3 m_MoveVelocity;
	// Reference velocity for the smooth damping of the position.
	private Vector3 m_DesiredPosition;
	// The position the camera is moving towards.


	private void Awake ()
	{
		m_Camera = GetComponentInChildren<Camera> ();
	}


	private void FixedUpdate ()
	{
		//FindFollowableObjects();
		// Move the camera towards a desired position.
		Move ();

		// Change the size of the camera based.
		Zoom ();

		ArenaObjectAdjust ();
	}

	//need to add objects to the list and take them out dynamically
	public void AddFollowableObject (GameObject follow)
	{

		targets.Add (follow.transform);
	}

	public void RemoveFollowableObject (GameObject follow)
	{
		targets.Remove (follow.transform);
	}


	private void Move ()
	{
		// Find the average position of the targets.
		FindAveragePosition ();

		// Smoothly transition to that position.

		//transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
		transform.position = m_DesiredPosition;
//			Debug.Log(transform.position);
	}


	private void FindAveragePosition ()
	{
		Vector3 averagePos = new Vector3 ();
		int numTargets = 0;

		// Go through all the targets and add their positions together.

		foreach (Transform trans in targets) {
			if (!trans.gameObject.activeSelf)
				continue;
			averagePos += trans.position;
			++numTargets;
		}


		/* for (int i = 0; i < m_Targets.Length; i++)
            {
                // If the target isn't active, go on to the next one.
                if (!m_Targets[i].gameObject.activeSelf)
                    continue;

                // Add to the average and increment the number of targets in the average.
                averagePos += m_Targets[i].position;
                numTargets++;
            }*/

		// If there are targets divide the sum of the positions by the number of them to find the average.
		if (numTargets > 0)
			averagePos /= numTargets;

		// Keep the same y value.
		//averagePos.y = transform.position.y;

		// The desired position is the average position;
		m_DesiredPosition = averagePos;
	}


	private void Zoom ()
	{
		// Find the required size based on the desired position and smoothly transition to that size.
		float requiredSize = FindRequiredSize ();
		m_Camera.orthographicSize = requiredSize;
		//m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
	}


	//TODO: could be expensive if lots of objects may need to optimize in the future
	private void ArenaObjectAdjust ()
	{
		foreach (Transform target in targets) {
			float distance = Vector2.Distance (transform.position, target.position);
            Debug.Log(distance);
			if (distance > arenaRange) {
				Vector3 temp;
				temp = target.position;
				//need to reduce the amount on one vector to be at a clamp without modifying the other.

				if (Mathf.Abs (target.position.x) > Mathf.Abs (target.position.y)) {

					if (temp.x >= 0)
						temp.x = -target.position.x + .5f;
					else
						temp.x = -target.position.x - .5f;
				} else {
					if (temp.y >= 0)
						temp.y = -target.position.y + .5f;
					else
						temp.y = -target.position.y - .5f;
				}
			//	Debug.Log (temp);
				//target.position = Vector3.ClampMagnitude(temp,arenaRange-1);
				target.position = temp;
				return; // may not be breaking out of the foreach????
			}
		}
	}


	private float FindRequiredSize ()
	{
		// Find the position the camera rig is moving towards in its local space.
		Vector3 desiredLocalPos = transform.InverseTransformPoint (m_DesiredPosition);

		// Start the camera's size calculation at zero.
		float size = 0f;

		// Go through all the targets...
		//for (int i = 0; i < m_Targets.Length; i++)
		foreach (Transform trans in targets) {
			// ... and if they aren't active continue on to the next target.
			if (!trans.gameObject.activeSelf)
				continue;

			// Otherwise, find the position of the target in the camera's local space.
			Vector3 targetLocalPos = transform.InverseTransformPoint (trans.position);

			// Find the position of the target from the desired position of the camera's local space.
			Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

			// Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera.
			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

			// Choose the largest out of the current size and the calculated size based on the tank being to the left or right of the camera.
			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
		}

		// Add the edge buffer to the size.
		size += m_ScreenEdgeBuffer;

		// Make sure the camera's size isn't below the minimum.
		size = Mathf.Max (size, m_MinSize);

		return size;
	}


}
