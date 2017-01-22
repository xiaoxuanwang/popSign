using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour {
	//POPSign Shared Video Manager
	private VideoManager sharedVideoManager;
	private string[] colorNameArray = new string[] {
		"blue",   // 0
		"green",  // 1
		"red",    // 2
		"violet", // 3
		"yellow"};// 4
	private Color[] colArray = new Color[] { 
		new Color(0.73F , 0.51F, 0.92F, 1.0F), // blue
		new Color(0.55F , 0.77F, 0.447F, 1.0F), // green
		new Color(0.91F , 0.451F, 0.41F, 1.0F), // red
		new Color(0.95F , 0.667F, 0.725F, 1.0F), // violet
		new Color(1.0F , 0.80F, 0.02F, 1.0F)}; // yellow

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		sharedVideoManager = VideoManager.getVideoManager();
		changeMenuPlayVideo ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Next()
	{
		updateCircles (true);
		if (sharedVideoManager.curtVideoIndex < 4) {
			sharedVideoManager.curtVideoIndex++;
		} else {
			sharedVideoManager.curtVideoIndex = 0;
		}
		changeMenuPlayVideo ();
	}

	public void Back()
	{
		updateCircles (false);
		if (sharedVideoManager.curtVideoIndex > 0) {
			sharedVideoManager.curtVideoIndex--;
		} else {
			sharedVideoManager.curtVideoIndex = 4;
		}
		changeMenuPlayVideo ();
	}

	public void Close() {
		sharedVideoManager.curtVideoIndex = 0;
		this.changeMenuPlayVideo ();
		for (int i = 0; i < 5; i++) {
			RawImage curtCircle = (RawImage) GameObject.Find("Circle" + i).GetComponent<RawImage>();
			if (i == 0) {
				curtCircle.texture = (Texture)Resources.Load ("Texture/circle_filled", typeof(Texture));
			} else {
				curtCircle.texture = (Texture)Resources.Load ("Texture/circle_unfilled", typeof(Texture));
			}
		}
		GameObject.Find ("Canvas").transform.Find ("MenuPlay").gameObject.SetActive (false);
	}
		
	public void updateCircles(bool isNext) {
		int curtCircleId;
		int prevCircleId;
		if (isNext) {
			if (sharedVideoManager.curtVideoIndex < 4) {
				curtCircleId = sharedVideoManager.curtVideoIndex + 1;
				prevCircleId = sharedVideoManager.curtVideoIndex;
			} else {
				curtCircleId = 0;
				prevCircleId = sharedVideoManager.curtVideoIndex;
			}
		} else {
			if (sharedVideoManager.curtVideoIndex > 0) {
				curtCircleId = sharedVideoManager.curtVideoIndex - 1;
				prevCircleId = sharedVideoManager.curtVideoIndex;
			} else {
				curtCircleId = 4;
				prevCircleId = sharedVideoManager.curtVideoIndex;
			}
		}

		RawImage curtCircle = (RawImage) GameObject.Find("Circle" + curtCircleId).GetComponent<RawImage>();
		RawImage prevCircle = (RawImage) GameObject.Find ("Circle" + sharedVideoManager.curtVideoIndex).GetComponent<RawImage>();

		Texture unfilledTexture = prevCircle.texture;
		Texture filledTexture = curtCircle.texture;
		curtCircle.texture = unfilledTexture;
		prevCircle.texture = filledTexture;
	}

	public void changeMenuPlayVideo() {
		sharedVideoManager.resetCurtVideo ();
		sharedVideoManager.shouldChangeVideo = true;


		RawImage curtBallExample = (RawImage) GameObject.Find("ballExample").GetComponent<RawImage>();
//		Debug.Log ("ball_" + colorNameArray [sharedVideoManager.curtVideoIndex] + "_l");
		curtBallExample.texture = (Texture)Resources.Load("PreviewBall/ball_" + colorNameArray[sharedVideoManager.curtVideoIndex] + "_l", typeof(Texture));

		Text currentWord = (Text) GameObject.Find("CurrentWord").GetComponent<Text>();
		currentWord.color = colArray [sharedVideoManager.curtVideoIndex];
		currentWord.text = sharedVideoManager.curtVideo.fileName;

		// popsign_family: remove text first
//		Text ballExampleName = (Text) GameObject.Find("ballExampleName").GetComponent<Text>();
//		int maxLength = Mathf.Min (3, sharedVideoManager.curtVideo.fileName.Length);
//		ballExampleName.text = sharedVideoManager.curtVideo.fileName.Substring(0, maxLength);

		// Popsign_family: Change text to raw image
		RawImage ballExampleImage = (RawImage) GameObject.Find("ballExampleImage").GetComponent<RawImage>();
		ballExampleImage.texture = (Texture)Resources.Load(sharedVideoManager.curtVideo.imageName, typeof(Texture));

//
//		Transform[] ts = gameObject.transform.GetComponentsInChildren<Transform>(true);
//		foreach (Transform t in ts) {
//			if (t.gameObject.name == "CurrentWord") {
//				Text txt = t.gameObject.GetComponent<Text>();
//				txt.text = sharedVideoManager.curtVideo.fileName;
//			} else if (t.gameObject.name == "ballExample") {
//			} else if (t.gameObject.name == "ballExampleName") {
//				Text txt = t.gameObject.GetComponent<Text>();
//				txt.text = sharedVideoManager.curtVideo.fileName.Substring(0, 3);
//			}
//		}
	}
}
