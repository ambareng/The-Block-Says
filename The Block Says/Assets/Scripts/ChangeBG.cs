using System.Collections;
using UnityEngine;

public class ChangeBG : MonoBehaviour {
	#region Variable Declarations
	public float changeCooldown = 0f;
	public Color blue, red;
	public IEnumerator coroutine;
	public Camera cam;
	public Vector3 spawnPos;
	public int color, dir;
	public GameObject arrowPrefab;
	public GameObject arrowToDelete;
	public GameManager gameManager;
	private ScoreManager scoreManager;
	public float cooldown = 2f;
	#endregion
	
	void Awake () {
		#region Variable Initializations
		blue = Color.blue;
		red = Color.red;
		cam = FindObjectOfType<Camera> ();
		spawnPos = transform.position;
		gameManager = FindObjectOfType<GameManager> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
		cooldown = 2f;
		#endregion
	}

	void Update () {
		if (gameManager.isPaused == false) {
			#region Time Handling of Spawning New Arrows and Changing of Background
			arrowToDelete = GameObject.FindGameObjectWithTag ("Arrow");
			if (arrowToDelete == null) {
				StartCoroutine ("Change");
				if (scoreManager.score % 5 == 0 && cooldown > 0.5f) {
					cooldown -= 0.1f;
				}
				changeCooldown = cooldown;
			} 

			changeCooldown -= Time.deltaTime;

			if (changeCooldown < 0) {
				scoreManager.score = 0;
				gameManager.isPaused = true;
				gameManager.tapToPlay.enabled = true;
				changeCooldown = 2.1f;
				cooldown = 2.1f;
				Destroy (arrowToDelete);
			}
			#endregion
		}
	}

	IEnumerator Change () {
		Destroy (arrowToDelete);

		#region Changing Background Colors
		color = Random.Range (1, 3);
		
		if (color == 1) {
			cam.backgroundColor = red;
		} else {
			cam.backgroundColor = blue;
		}
		#endregion

		#region Spawning New Arrow and Direction
		GameObject arrow = Instantiate (arrowPrefab, spawnPos, Quaternion.identity);
		dir = Random.Range (1, 5);

		if (dir == 1) {
			arrow.transform.position = spawnPos; // To the Right (Normal Direction)
		} else if (dir == 2) {
			arrow.transform.position = spawnPos; // To the Left
			arrow.transform.Rotate (Vector3.back * -180);
		} else if (dir == 3) {
			arrow.transform.position = spawnPos; // Upwards
			arrow.transform.Rotate (Vector3.back * -90);
		} else {
			arrow.transform.position = spawnPos; // Downwards
			arrow.transform.Rotate (Vector3.forward * -90);
		}
		#endregion

		yield return new WaitForSeconds (0.0000001f);
	}
}
