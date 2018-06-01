
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour {
	public Swipe swipeControls;
	private GameManager gameManager;
	private ChangeBG changeBG;
	private ScoreManager scoreManager;

	private void Awake () {
		gameManager = FindObjectOfType<GameManager> ();
		changeBG = FindObjectOfType<ChangeBG> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	private void Update () {
		if (gameManager.isPaused == false) {
			#region Swipe Functions
			if (swipeControls.swipeLeft) {
				if (changeBG.color == 1 && changeBG.dir == 1) {
					scoreManager.score += 1;
				} else if (changeBG.color == 2 && changeBG.dir == 2) {
					scoreManager.score += 1;
				} else {
					scoreManager.score = 0;
					changeBG.cooldown = 2.1f;
					gameManager.isPaused = true;
					gameManager.tapToPlay.enabled = true;
				}
				Destroy (this.gameObject);
			}
			if (swipeControls.swipeRight) {
				if (changeBG.color == 1 && changeBG.dir == 2) {
					scoreManager.score += 1;
				} else if (changeBG.color == 2 && changeBG.dir == 1) {
					scoreManager.score += 1;
				} else {
					scoreManager.score = 0;
					changeBG.cooldown = 2.1f;
					gameManager.isPaused = true;
					gameManager.tapToPlay.enabled = true;
				}
				Destroy (this.gameObject);
			}
			if (swipeControls.swipeUp) {
				if (changeBG.color == 1 && changeBG.dir == 4) {
					scoreManager.score += 1;
				} else if (changeBG.color == 2 && changeBG.dir == 3) {
					scoreManager.score += 1;
				} else {
					scoreManager.score = 0;
					changeBG.cooldown = 2.1f;
					gameManager.isPaused = true;
					gameManager.tapToPlay.enabled = true;
				}
				Destroy (this.gameObject);
			}
			if (swipeControls.swipeDown) {
				if (changeBG.color == 1 && changeBG.dir == 3) {
					scoreManager.score += 1;
				} else if (changeBG.color == 2 && changeBG.dir == 4) {
					scoreManager.score += 1;
				} else {
					scoreManager.score = 0;
					changeBG.cooldown = 2.1f;
					gameManager.isPaused = true;
					gameManager.tapToPlay.enabled = true;
				}
				Destroy (this.gameObject);
			}
			#endregion
		}
	}
}
