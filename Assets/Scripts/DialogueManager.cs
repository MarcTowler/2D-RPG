using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text text;

    public bool active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(active && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueBox.SetActive(false);
            active = false;
        }
	}

    public void ShowBox(string dialogue)
    {
        active = true;
        dialogueBox.SetActive(true);
        text.text = dialogue;
    }
}
