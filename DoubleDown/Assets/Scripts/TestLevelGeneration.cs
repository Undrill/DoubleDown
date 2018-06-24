using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelGeneration : MonoBehaviour {

    //Pools of patterns
    public GameObject[] easyPatterns;
    public GameObject[] mediumPatterns;
    public GameObject[] hardPatterns;

    //PatternsList to Use
    public List<GameObject> availablePatterns;

    public List<GameObject> inUsePatterns;

    //Variables to check if a pattern needs to be added
    private bool addPatterns = true;
    private float playerPositionY;
    public float minimumDistanceToAddPattern = 30;
    private float usedPatternToPool;
    private float farthestPatternPositionY;

    //Pattern Initialisation
    private int patternsToStart = 10;
    private float farthestPatternY;

    private void Start()
    {
        farthestPatternY = minimumDistanceToAddPattern;
    }


    void FixedUpdate ()
    {
        PatternUpdate();
	}

    void PatternUpdate()
    {
        playerPositionY = this.transform.position.y;

        if(inUsePatterns.Count >0)
        {
            foreach (var pattern in inUsePatterns)
            {
                if (pattern.transform.position.y > (playerPositionY - minimumDistanceToAddPattern))
                {
                    addPatterns = false;
                }

                else
                {
                    availablePatterns.Add(pattern);
                    inUsePatterns.Remove(pattern);
                }
            }
        }
        else
        {
            for (int i =0; i< patternsToStart;i++)
            {
                int randomPatternIndex = Random.Range(0, easyPatterns.Length);
                GameObject StartPattern = Instantiate(easyPatterns[randomPatternIndex]);
                float StartPatternHeight = StartPattern.transform.Find("HeightChecker").localScale.y;
                Debug.Log("Start Pattern n°" + i + " height is " + StartPatternHeight);
                StartPattern.transform.position = new Vector3(0, farthestPatternY, 0.5f);
                farthestPatternY = farthestPatternY + StartPatternHeight;
                inUsePatterns.Add(StartPattern);
            }
        }

    }
}
