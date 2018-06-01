using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	#region Variable Declarations
	public int best;
	public Text bestText;
	public int score;
	public Text scoreText;
	private GameManager gameManager;
	#endregion

	private void Awake () {
		gameManager = FindObjectOfType<GameManager> ();
		score = 0;
		best = PlayerPrefs.GetInt ("Best", 0);
	}

	private void Update () {
		scoreText.text = "" + score;

		if (score > best) {
			best = score;
			PlayerPrefs.SetInt ("Best", best);
		}
	}
}
