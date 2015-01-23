using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogBubble : MonoBehaviour {


	public string dialogFileName;
	public GameObject dialogWindow;
	public Text dialogTextBox;

	DirectoryInfo dialogDirectory;
	string[] dialogLines;

	int currentLine;

	void Awake () {

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
		if (Input.GetButtonDown ("Fire1") && dialogWindow.activeSelf) {
			showDialogMessage();
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
	}

	void HideDialog() {
		dialogWindow.SetActive (false);
	}
}
