using UnityEngine;
using System.Collections;

public class Video {
	public int frameNumber;
	public string fileName;
	public string folderName;
	public string imageName;

	public Video(int _frameNumber, string _fileName, string _folderName, string _imageName) {
		frameNumber = _frameNumber;
		fileName = _fileName;
		folderName = _folderName;
		imageName = _imageName;
	}

	// Use this for initialization
	void Start () {
	
	}

}
