
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	public int score;
	public int highscore;
	public Text countScore;
	public Text HighScore;
	public float jumpForce = 10f;
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public string currColor;
	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;
	public Text Tap;

	void Start(){
		Screen.sleepTimeout = 50;
		rb.gravityScale = 0f;
		setRandomColor();
		score = 0;
		printScore ();
	}
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown (0)) {
			{
				Tap.text = "";
				rb.gravityScale = 3f;
				rb.velocity = Vector2.up * jumpForce;
			}

		}
	}

	void OnTriggerEnter2D(Collider2D obj)
	{

		if (obj.tag == "Changer") {
			setRandomColor();
			Destroy (obj.gameObject);
			score++;
			printScore ();
			return;
		}
		if (obj.tag != currColor) {
			{
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex );
			}

		}
	}
	void setRandomColor()
	{
		int index = Random.Range (0, 4);
		switch (index) {
		case 0:
			currColor = "Yellow";
			sr.color = colorYellow;
			break;
		case 1:
			currColor = "Magenta";
			sr.color = colorMagenta;
			break;
		case 2:
			currColor = "Pink";
			sr.color = colorPink;
			break;
		case 3:
			currColor = "Cyan";
			sr.color = colorCyan; 
			break;
		}
	}
	void printScore()
	{
		highscore = PlayerPrefs.GetInt("highscore");
		if (score > highscore) {
			highscore = score;
			PlayerPrefs.SetInt ("highscore", score);
		}
		if (score == 6)
			Tap.text = "SUCCESS";
 		countScore.text = "Score: "+score.ToString ();
		HighScore.text = "HighScore: " + highscore.ToString ();
	}
}

