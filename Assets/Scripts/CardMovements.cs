using UnityEngine;

public class CardMovements : MonoBehaviour {

	[SerializeField]private int type;
	private bool press = false;
	private int countPress = 0;
	private float timer = 0f;
	private bool timerBegin = false;
	private bool executingUpdate = false;
	private GameObject[] cardTypes = new GameObject[2];

	void OnMouseDown(){
		GameObject[] cards = GameObject.FindGameObjectsWithTag("Cards"); 

		for(int i = 0; i < cards.Length; i++){
			if(cards[i].GetComponent<CardMovements>().press){
				countPress++;
			}
		}

		if(countPress < 2){
			press = true;
			transform.Rotate (new Vector3 (180, 0, 0));
		}

		if(countPress == 1){
			timer = 1f;
			timerBegin = true;
			executingUpdate = false;
		}
		
	}

	void Start(){
	}

	void Update(){
		if(timerBegin){
			timer -= Time.deltaTime;
			if(timer <= 0 && executingUpdate == false){
				timerBegin = false;
				executingUpdate = true;
				GameObject[] cards = GameObject.FindGameObjectsWithTag("Cards"); 

				for(int i = 0; i < cards.Length; i++){
					if(cards[i].GetComponent<CardMovements>().press){
						if (cardTypes [0] == null) { 
							cardTypes [0] = cards [i].gameObject; 
						} else { 
							cardTypes [1] = cards [i].gameObject; 
						}
					}
				}

				if (cardTypes [0].GetComponent<CardMovements> ().type == cardTypes [1].GetComponent<CardMovements> ().type) {
					Destroy (cardTypes [0]);
					Destroy (cardTypes [1]);
				} else {
					cardTypes[0].transform.eulerAngles = new Vector3 (0, 0, 0);
					cardTypes[1].transform.eulerAngles = new Vector3 (0, 0, 0);
					cardTypes[1].GetComponent<CardMovements> ().press = false;
					cardTypes[0].GetComponent<CardMovements> ().press = false;
				}

				cardTypes [0] = null;
				cardTypes [1] = null;
			}
		}
	}
}
