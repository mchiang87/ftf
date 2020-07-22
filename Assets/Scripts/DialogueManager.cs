using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;

    public bool dialogueActive;

    public string[] dialogueLines = new string[] {""};
    public int currentLine;

    public void Update() {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return)) {
            currentLine++;
        }

        if (currentLine >= dialogueLines.Length) {
            HideBox();
            currentLine = 0;
        }

        dialogueText.text = dialogueLines[currentLine];
    }

    public void ShowDialogue() {
        dialogueActive = true;
        dialogueBox.SetActive(true);
    }

    public void HideBox() {
        dialogueActive = false;
        dialogueBox.SetActive(false);
    }
}
