using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
Important notes for this to work:
Review this video: https://www.youtube.com/watch?v=1NCvpZDtTMI&ab_channel=MisterTaftCreates

1) the trigger uses the tag "Player", so make sure to tag your Player sprite with Player in the Inspector window
2) make sure the file is the same name as the class (literally spent 3 hours trying to figure out why I had a compile error in Unity...)
3) For text and dialog box, need to add a Canvas to the Scene (right click, choose UI > Canvas), then right click Canvas and add new UI > Image (adds white background for the 'dialog box', and rename it as such), then add text to the dialog box by right clicking on the Image item, and selecting UI > Text
4) drag a sign prefab into Scene
5) add this signScript.cs as a component
6) From Canvas, drag in the 'dialog box' UI item into "Dialog Box" of component (dialog box UI item is the white background the text appears on)
7) drag in the "Text" UI component from Scene into "Dialog Text" of component (looks like only one is needed)
8) Fill 'Dialog' inside the script component with the text to display in game (modify each sign's text here)
=-=-= for the 'press enter' prompt: =-=-=
9) Under 'Canvas;, create a new UI object -> text, and place it properly on the screen
10) add 'press enter' or whatever text you want
11) untick the 'set active' box to hide it from the view
12) drag that object into the sign's "Enter Prompt" component in the inspector

*/

public class signScript : MonoBehaviour
{

    public GameObject dialogBox;
    public GameObject pressEnterPrompt;
    public Text dialogText;
    public string dialog;   
    public bool playerInRange;
    public bool isFlickering = false;
    public bool isReading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && isReading == false) {
            if(isFlickering == false) {
                StartCoroutine(FlickeringMessage());
            }
        } else {
            StopCoroutine(FlickeringMessage());
        }
       
        if(Input.GetKeyDown(KeyCode.Return) && playerInRange) {
            if(dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
                //StopCoroutine(FlickeringMessage());
                isReading = false;
            } else {
                isReading = true;
                pressEnterPrompt.SetActive(false);
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    IEnumerator FlickeringMessage() {
        isFlickering = true;
        pressEnterPrompt.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pressEnterPrompt.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        isFlickering = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            //Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            //Debug.Log("Player left range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
