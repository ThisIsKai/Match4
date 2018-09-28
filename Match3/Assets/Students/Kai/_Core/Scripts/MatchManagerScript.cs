using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MatchManagerScript : MonoBehaviour {

	protected GameManagerScript gameManager;

	public class redPlayerScore {	//creating a new class for my Player's Health Stats
		public int redCurrentScore = 0; //seting the starting health value of the player
		public TextMesh redScoreText; //creating the variable for the text that shows the player's current health

		} //END PUBLIC CLASS RedPlayerStats

	public class yellowPlayerScore {	//creating a new class for my Player's Health Stats
		public int yellowCurrentScore = 0; //seting the starting health value of the player
		public TextMesh yellowScoreText; //creating the variable for the text that shows the player's current health

	} //END PUBLIC CLASS bluePlayerStats
	public class bluePlayerScore {	//creating a new class for my Player's Health Stats
		public int blueCurrentScore = 0; //seting the starting health value of the player
		public TextMesh blueScoreText; //creating the variable for the text that shows the player's current health

	} //END PUBLIC CLASS bluePlayerStats



	public redPlayerScore redScoreTally;
	public yellowPlayerScore yellowScoreTally;
	public bluePlayerScore blueScoreTally;


	public bool isGameOver; //game over bool




	public virtual void Start () {
		gameManager = GetComponent<GameManagerScript>();

		isGameOver = false;

		redScoreTally = new redPlayerScore ();
		redScoreTally.redCurrentScore = 0;	
		redScoreTally.redScoreText = Camera.main.transform.GetChild (1).gameObject.GetComponent<TextMesh> ();
		Debug.Log ("red score=" + redScoreTally.redScoreText);

		yellowScoreTally = new yellowPlayerScore ();
		yellowScoreTally.yellowCurrentScore = 0;	
		yellowScoreTally.yellowScoreText = Camera.main.transform.GetChild (2).gameObject.GetComponent<TextMesh> ();
		Debug.Log ("yellow score=" + yellowScoreTally.yellowScoreText);

		blueScoreTally = new bluePlayerScore ();
		blueScoreTally.blueCurrentScore = 0;	
		blueScoreTally.blueScoreText = Camera.main.transform.GetChild (3).gameObject.GetComponent<TextMesh> ();
		Debug.Log ("blue score=" + blueScoreTally.blueScoreText);



	}//END START FUNCTION
	void Update(){
		redScoreTally.redScoreText.text = "RED SCORE: " +redScoreTally.redCurrentScore; //telling the text to include the current score
		yellowScoreTally.yellowScoreText.text = "YELLOW SCORE: " +yellowScoreTally.yellowCurrentScore;
		blueScoreTally.blueScoreText.text = "BLUE SCORE: " + blueScoreTally.blueCurrentScore;
	}

	public virtual bool GridHasMatch(){
		bool match = false;
		
		for (int x = 0; x < gameManager.gridWidth; x++) {
			for (int y = 0; y < gameManager.gridHeight; y++) {

				if (x < gameManager.gridWidth - 2) {
					match = match || GridHasNeutralHorizontalMatch (x, y);
				}
					
				if (x < gameManager.gridWidth - 3) {
					match = match || GridHasHorizontalMatch (x, y);

				}

				if (y < gameManager.gridHeight - 3) {
					match = match || GridHasVerticalMatch (x, y);
	
				}
				if (y < gameManager.gridHeight - 2) {
					match = match || GridHasNeutralVertMatch (x, y);

				}
			}
		}
		
		return match;
	}//END GRID HAS MATCH FUNCTION

	public bool GridHasHorizontalMatch(int x, int y){
		GameObject token1 = gameManager.gridArray[x + 0, y];
		GameObject token2 = gameManager.gridArray[x + 1, y];
		GameObject token3 = gameManager.gridArray[x + 2, y];
		GameObject token4 = gameManager.gridArray[x + 3, y];
		if (token1.gameObject.tag !="Grey"){
			if (token1 != null && token2 != null && token3 != null && token4 != null) {
				SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr4 = token4.GetComponent<SpriteRenderer> ();
				return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite && sr3.sprite == sr4.sprite);
			}
			return false;
		} else {
			return false;
		}
	}//END GRID HAS HORIZ MATCH FUNCTION
		public bool GridHasVerticalMatch(int x, int y){
		
			GameObject token1 = gameManager.gridArray[x, y + 0];
			GameObject token2 = gameManager.gridArray[x, y + 1];
			GameObject token3 = gameManager.gridArray[x, y + 2];
			GameObject token4 = gameManager.gridArray[x, y + 3];
			if (token1.gameObject.tag !="Grey"){				
			if (token1 != null && token2 != null && token3 != null) {
				SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr4 = token4.GetComponent<SpriteRenderer> ();
				return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite && sr3.sprite == sr4.sprite);
			} 
				return false;

		} else {
				return false;
			}
		}//END GRID HAS VERT MATCH FUNCTION

	public bool GridHasNeutralVertMatch(int x, int y){
		GameObject token1 = gameManager.gridArray[x, y + 0];
		GameObject token2 = gameManager.gridArray[x, y + 1];
		GameObject token3 = gameManager.gridArray[x, y + 2];
		if (token1.gameObject.tag =="Grey"){
			if (token1 != null && token2 != null && token3 != null) {
				SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer> ();
				return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite);
			}
			return false;
		} else {
			return false;
		}
	}//END GRID HAS NEUTRAL VERT MATCH FUNCTION

	public bool GridHasNeutralHorizontalMatch(int x, int y){
		GameObject token1 = gameManager.gridArray[x + 0, y];
		GameObject token2 = gameManager.gridArray[x + 1, y];
		GameObject token3 = gameManager.gridArray[x + 2, y];
		if (token1.gameObject.tag =="Grey"){
			if (token1 != null && token2 != null && token3 != null) {
				SpriteRenderer sr1 = token1.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr2 = token2.GetComponent<SpriteRenderer> ();
				SpriteRenderer sr3 = token3.GetComponent<SpriteRenderer> ();
				return (sr1.sprite == sr2.sprite && sr2.sprite == sr3.sprite);
			}
			return false;
		} else {
			return false;
		}
	}//END GRID HAS HORIZ MATCH FUNCTION

	public int GetHorizontalMatchLength(int x, int y){
		int matchLength = 1;
		
		GameObject first = gameManager.gridArray[x, y];

		if(first != null){
			SpriteRenderer sr1 = first.GetComponent<SpriteRenderer>();
			
			for(int i = x + 1; i < gameManager.gridWidth; i++){
				GameObject other = gameManager.gridArray[i, y];

				if(other != null){
					SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();

					if(sr1.sprite == sr2.sprite){
						matchLength++;
					} else {
						break;
					}
				} else {
					break;
				}
			}
		}
		
		return matchLength;
	}//END HORIZ MATCH LENGTH FUNCTION

	public int GetVerticalMatchLength(int x, int y){
		int matchLength = 1;

		GameObject first = gameManager.gridArray[x, y];

		if(first != null){
			SpriteRenderer sr1 = first.GetComponent<SpriteRenderer>();

			for(int i = y + 1; i < gameManager.gridHeight; i++){
				GameObject other = gameManager.gridArray[x, i];

				if(other != null){
					SpriteRenderer sr2 = other.GetComponent<SpriteRenderer>();

					if(sr1.sprite == sr2.sprite){
						matchLength++;
					} else {
						break;
					}
				} else {
					break;
				}
			}
		}

		return matchLength;
	}//END VERT MATCH LENGTH FUNCTION

	public virtual int RemoveMatches(){
		int numRemoved = 0;
		//		// Vert
		for (int y = 0; y < gameManager.gridHeight; y++) {
			for (int x = 0; x < gameManager.gridWidth; x++) {
				if (y < gameManager.gridHeight - 2) {

					int verticalMatchLength = GetVerticalMatchLength (x, y);

					if (verticalMatchLength > 2) {

						for (int i = y; i < y + verticalMatchLength; i++) {
							GameObject token = gameManager.gridArray [x, i]; 
							if (token.gameObject.tag == "Blue"){
								BlueScored();
							}
							if (token.gameObject.tag == "Red"){
								RedScored();
							}
							if (token.gameObject.tag == "Yellow"){
								YellowScored();	
							}

							Destroy (token);

							gameManager.gridArray [x, i] = null;
							numRemoved++;
						}
					}
				}
			}
		}
		for(int x = 0; x < gameManager.gridWidth; x++){
			for(int y = 0; y < gameManager.gridHeight ; y++){
				if(x < gameManager.gridWidth - 2){

					int horizonMatchLength = GetHorizontalMatchLength(x, y);

					if(horizonMatchLength > 2){

						for(int i = x; i < x + horizonMatchLength; i++){
							GameObject token = gameManager.gridArray[i, y];
							if (token.gameObject.tag == "Blue"){
								BlueScored();
							}
							if (token.gameObject.tag == "Red"){
								RedScored();
							}
							if (token.gameObject.tag == "Yellow"){
								YellowScored();	
							}

							Destroy(token);


							gameManager.gridArray[i, y] = null;
							numRemoved++;
						}
					}
				}
			}
		}
	
		
		return numRemoved;
	}//END REMOVE MATCHES FUNCTION


	void RedScored(){
		redScoreTally.redCurrentScore +=1 ;
		if (redScoreTally.redCurrentScore >= 50) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("RedWinsScene");
		}
	}//END RED SCORED FUNCTION

	void YellowScored(){
		yellowScoreTally.yellowCurrentScore += 1;
		if (yellowScoreTally.yellowCurrentScore >= 50) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("YellowWinsScene");
		}
	}//END YELLOW SCORED FUNCTION

	void BlueScored(){
		blueScoreTally.blueCurrentScore += 1;
		if (blueScoreTally.blueCurrentScore >= 50) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("BlueWinsScene");
		}
	}//END BLUE SCORED FUNCTION





}//END MATCH MANAGER SCRIPT
