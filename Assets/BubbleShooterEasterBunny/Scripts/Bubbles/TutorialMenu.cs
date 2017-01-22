using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour {

	void Awake () {
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void Next()
	{
	}

	public void Back()
	{
	}

	public void Close() {
		GameObject.Find ("Canvas").transform.Find ("Tutorial").gameObject.SetActive (false);
	}
}