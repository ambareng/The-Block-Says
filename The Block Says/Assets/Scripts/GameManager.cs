using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public bool isPaused;
	public Text tapToPlay;

	private void Awake () {
		isPaused = true;
		tapToPlay.enabled = true;
	}

	private void Update () {
		if (Input.GetMouseButtonDown (0) && isPaused == true) {
			isPaused = false;
			tapToPlay.enabled = false;
		}
	}

	public void Pause () {
		isPaused = true;
		tapToPlay.enabled = true;
	}
}
