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
*/

public class signScript : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;   
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && playerInRange) {
            if(dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
            } else {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
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
