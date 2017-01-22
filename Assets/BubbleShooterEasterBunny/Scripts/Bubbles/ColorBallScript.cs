using UnityEngine;
using System.Collections;
using LitJson;

public enum BallColor
{
    blue   = 1,
	green,
    red,
    violet,
    yellow,
    random,
    chicken
}

public class ColorBallScript : MonoBehaviour {
	//POPSign tie the video name with ball
	//public Video video;

	public Sprite[] sprites;
    public BallColor mainColor;
	// Use this for initialization
	void Start () {
	}

	//POPSign Read Json file(The connection between colors and videos)
//	void ReadJsonFromTXT(BallColor color)
//	{
//		int currentLevel = mainscript.Instance.currentLevel;
//		TextAsset textReader = Resources.Load( "VideoConnection/" + "Video" + currentLevel ) as TextAsset;
//		JsonData jd = JsonMapper.ToObject(textReader.text);
//
//		string fileName = jd[color + "fileName"] + "";
//		string folderName = jd[color + "folderName"] + "";
//		string frameNumber = jd[color + "frameNumber"] + "";
//		if (fileName != "" && folderName != "" && frameNumber != "") {
//			video = new Video (int.Parse (frameNumber), fileName, folderName);
//		}
//	}

    public void SetColor(BallColor color)
	{
		//POPSign tie the color with videos
		//ReadJsonFromTXT(color);

        mainColor = color;
        foreach (Sprite item in sprites)
        {
            if( item.name == "ball_" + color )
            {
                GetComponent<SpriteRenderer>().sprite = item;
                SetSettings( color );
                gameObject.tag = "" + color;
            }
         }
	}

    private void SetSettings( BallColor color )
    {
        if( color == BallColor.chicken )
        {
            if( LevelData.mode == ModeGame.Rounded )
            {

            }
        }
    }

    public void SetColor( int color )
    {
        mainColor = (BallColor)color;
        GetComponent<SpriteRenderer>().sprite = sprites[color];
    }

    public void ChangeRandomColor()
    {
        mainscript.Instance.GetColorsInGame();
        SetColor( (BallColor)mainscript.colorsDict[Random.Range( 0, mainscript.colorsDict.Count )]);
        GetComponent<Animation>().Stop();
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -16 && transform.parent == null) {  Destroy(gameObject); }
	}
}
