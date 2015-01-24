using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogBubble : MonoBehaviour {


	public string dialogFileName;
	public GameObject dialogWindow;
	public Text dialogTextBox;
	public bool AttackOnFinish = false;

	DirectoryInfo dialogDirectory;
	string[] dialogLines;
	LayerMask npcMask;
	bool dialogOpen = false;
	bool playerInRange = false;
	GameObject player;
	PlayerMovement playerMovement;
	EnemyAttack enemyAttack;

	int currentLine;

	void Awake () {

		npcMask = LayerMask.GetMask ("NPC");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerMovement = player.GetComponent<PlayerMovement> ();
		enemyAttack = GetComponent<EnemyAttack> ();

		// get reference to dialog directory
		dialogDirectory = new DirectoryInfo(Application.dataPath + "/Dialogs");
		try {
			// load the dialog text and separate the lines
			string dialogText = File.ReadAllText (dialogDirectory.FullName + '/' + dialogFileName + ".txt");
			dialogLines = dialogText.Split(new string[] {  "--LINE--" }, System.StringSplitOptions.RemoveEmptyEntries);
		} catch (FileNotFoundException ex) {
			Debug.LogError("Could not find file: " + dialogFileName + " In Dialogs directory");
		}
	}
	

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			// Create a RaycastHit variable to store information about what was hit by the ray.
			RaycastHit npcHit;
			
			// Perform the raycast and if it hits something on the floor layer...
			if(!dialogOpen && Physics.Raycast (camRay, out npcHit, 100f, npcMask) && playerInRange)
			{
				if (npcHit.collider.gameObject == gameObject) {
					showDialogMessage();
				}
				
			} else if (dialogOpen) {
				showDialogMessage();
			}
		}

	}

	/**
	 * Shows the NPC dialog and loads the next line.
	 * @returns bool Did finish dialog
	 */
	public bool showDialogMessage() {
		if (currentLine < dialogLines.Length) {
			ShowDialog();
			Debug.Log(dialogLines[currentLine]);
			dialogTextBox.text = dialogLines [currentLine];
			currentLine++;
			return false;
		} else {
			HideDialog ();
			currentLine = 0;
			return true;
		}
	}

	void ShowDialog() {
		dialogWindow.SetActive (true);
		dialogOpen = true;
		playerMovement.enabled = false;
	}

	void HideDialog() {
		dialogWindow.SetActive (false);
		dialogOpen = false;
		playerMovement.enabled = true;

		if (AttackOnFinish && enemyAttack != null) {
			enemyAttack.Attack();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
}
