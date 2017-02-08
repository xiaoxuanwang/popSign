using UnityEngine;
using System.Collections;
using System;
using LitJson;
 
public class VideoManager {
	private static VideoManager sharedVideoManager;
	private ArrayList videoList;
	public string curtVideoName;
	public Video curtVideo;
	public int curtVideoIndex;
	public bool shouldChangeVideo;

	private VideoManager() {
		videoList = new ArrayList ();
		shouldChangeVideo = true;
		curtVideoIndex = 0;
		curtVideo = null;
		ReadJsonFromTXT ();
	}

	public static void resetVideoManager() {
		if (sharedVideoManager == null) {
			sharedVideoManager = new VideoManager ();
		}
		Debug.Log ("RESET MANAGER");
		sharedVideoManager.resetVideoList ();
	}
		
	public static VideoManager getVideoManager() {
		if (sharedVideoManager == null) {
			sharedVideoManager = new VideoManager ();
		}
		return sharedVideoManager;
	}

	//POPSign Read Json file(The connection between colors and videos)
	void ReadJsonFromTXT()
	{
		//int currentLevel = mainscript.Instance.currentLevel;
		int currentLevel = PlayerPrefs.GetInt("OpenLevel");
//		Debug.Log ("current level is " + currentLevel);
		TextAsset textReader = Resources.Load("VideoConnection/" + "level" + currentLevel ) as TextAsset;
		JsonData jd = JsonMapper.ToObject(textReader.text);

		foreach(BallColor color in Enum.GetValues(typeof(BallColor))) {
			if (color == BallColor.random) {
				break;
			}
			string fileName = jd[color + "fileName"] + "";
			string folderName = jd[color + "folderName"] + "";
			string frameNumber = jd[color + "frameNumber"] + "";
			string imageName = jd [color + "ImageName"] + "";
			if (fileName != "" && folderName != "" && frameNumber != "" && imageName != "") {
				videoList.Add(new Video (int.Parse (frameNumber), fileName, folderName, imageName, color));
			}
		}

		curtVideo = (Video) videoList [0];
		curtVideoIndex = 0;
	}

	public void addVideoToVideoList(Video video) {
		videoList.Add (video);
	}

	public Video getVideoByVideoName(string videoName) {
		foreach (Video video in videoList) {
			if (video.fileName == videoName) {
				return video;
			}
		}
		return null;
	}

	public Video getVideoByColor(BallColor color) {
		return (Video) videoList[(int)color - 1];
	}

	public void resetVideoList() {
		videoList.Clear ();
		ReadJsonFromTXT ();
	}

	public Video getCurtVideo() {
		return curtVideo;
	}

	public void resetCurtVideo() {
		curtVideo = (Video) videoList [curtVideoIndex];
	}
	// Use this for initialization
	void Start () {
		
	}

}
