using UnityEngine;
using UnityEngine.UI;

public class ChangeNumber : MonoBehaviour
{
    public Collectables collectables;
    private int cherries;
    private int currentCount;
    public Text textScore;

    private void Start()
    {
        currentCount = 0;
        textScore = GetComponent<Text>();
    }

    private void Update()
    {
        cherries = collectables.getCherryCounter();
        if(cherries > currentCount)
        {
            ChangeNum();
        }

    }

    private void ChangeNum() 
    {
        textScore.text = cherries.ToString();

    }
}

