
using UnityEngine;

public class Swipe : MonoBehaviour {
	public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	public bool isDragging = false;
	public Vector2 startTouch, swipeDelta;
	private GameManager gameManager;

	private void Awake () {
		gameManager = FindObjectOfType<GameManager> ();
	}

	private void Update () {
		if (gameManager.isPaused == false) {
			tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

			#region StandAlone Inputs
			if (Input.GetMouseButtonDown (0)) {
				tap = true;
				isDragging = true;
				startTouch = Input.mousePosition;
			} else if (Input.GetMouseButtonDown (0)) {
				isDragging = false;
				Reset ();
			}
			#endregion

			#region Mobile Inputs
			if (Input.touches.Length > 0) {
				if (Input.touches[0].phase == TouchPhase.Began) {
					isDragging = true;
					tap = true;
					startTouch = Input.touches[0].position;
				} else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
					isDragging = false;
					Reset ();
				}
			}
			#endregion

			#region Calculating the Distance of the Swipe
			swipeDelta = Vector2.zero;

			if (isDragging) {
				if (Input.touches.Length != 0) {
					swipeDelta = Input.touches[0].position - startTouch;
				} else if (Input.GetMouseButton (0)) {
					swipeDelta = (Vector2) Input.mousePosition - startTouch;
				}
			}
			#endregion
		
			#region Testing Swipe Distance Validity and Direction
			if (swipeDelta.magnitude > 100) {
				float x = swipeDelta.x;
				float y = swipeDelta.y;

				if (Mathf.Abs (x) > Mathf.Abs (y)) {
					if (x < 0) {
						swipeLeft = true;
					} else {
						swipeRight = true;
					}
				} else {
					if (y < 0) {
						swipeDown = true;
					} else {
						swipeUp = true;
					}
				}
				
				Reset ();
			}
			#endregion
		}
	}

	private void Reset () {
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
	}
}
