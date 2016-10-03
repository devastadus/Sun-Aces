using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerController : MonoBehaviour {
	public int PlayerId; // The Rewired player id of this character
	protected Rewired.Player _player; // The Rewired Player

	void Awake()
	{
		_player = ReInput.players.GetPlayer(PlayerId);
	}

	public Rewired.Player GetPlayer()
	{
		return _player;
	}

	// Use this for initialization
	protected void Start () {
		if(PlayerId == 0)
			gameObject.layer = LayerMask.NameToLayer("Player1");
		if(PlayerId == 1)
			gameObject.layer = LayerMask.NameToLayer("Player2");	
	}

}
