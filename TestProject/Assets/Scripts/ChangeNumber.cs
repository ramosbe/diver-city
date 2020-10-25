using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

//holds the numbers for use outside of camera range. When number is changed, swap the current number position with the next

public class ChangeNumber : MonoBehaviour
{
    public Collectables collectables;
    private int cherries;
    private int currentCount;
    private Vector3 numberPos;
    private Vector3 awayPos;
    public GameObject[] nums;

    private void Start()
    {
        currentCount = 0;
        numberPos = nums[0].transform.position;
        awayPos = nums[1].transform.position;
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
        nums[currentCount].transform.position = awayPos;
        nums[cherries].transform.localPosition = Vector3.zero;
        currentCount = cherries;
        Debug.Log("counter changed");
    }
}

