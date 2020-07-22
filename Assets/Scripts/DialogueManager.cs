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
    private float coolDown;

    private Player player;

    public void Start() {
        player = FindObjectOfType<Player>();
    }
    public void Update() {
        coolDown -= Time.deltaTime;
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return)) {
            currentLine++;
        }

        if (currentLine >= dialogueLines.Length) {
            HideBox();
            currentLine = 0;
            coolDown = 1;
        }
        dialogueText.text = dialogueLines[currentLine];
    }

    public void ShowDialogue() {
        if (coolDown <= 0) {
            dialogueActive = true;
            dialogueBox.SetActive(true);
            player.canMove = false;
        }
    }

    public void HideBox() {
        dialogueActive = false;
        dialogueBox.SetActive(false);
        player.canMove = true;
    }
}
