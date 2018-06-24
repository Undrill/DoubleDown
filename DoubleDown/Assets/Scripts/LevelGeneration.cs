using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    public GameObject[] availablePatterns;
    public List<GameObject> currentPatterns;
    public float distanceToAddPattern = 50.0f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        GeneratePatternIfRequired();
    }

    private void GeneratePatternIfRequired()
    {
        List<GameObject> patternsToRemove = new List<GameObject>();
        bool addPatterns = true;
        float playerY = this.transform.position.y;
        float removePatternY = playerY - distanceToAddPattern;
        float addPatternY = playerY + distanceToAddPattern;
        float farthestPatternEndY = 0;

        foreach (var pattern in currentPatterns)
        {
            float patternHeight = pattern.transform.Find("HeightChecker").localScale.y;
            float patternStartY = pattern.transform.position.y - (patternHeight * 0.5f);
            float patternEndY = patternStartY + patternHeight;

            if (patternStartY > addPatternY)
            {
                addPatterns = false;
            }

            if (patternEndY < removePatternY)
            {
                patternsToRemove.Add(pattern);
            }
            farthestPatternEndY = Mathf.Max(farthestPatternEndY, patternEndY);
        }

        foreach(var pattern in patternsToRemove)
        {
            currentPatterns.Remove(pattern);
            Destroy(pattern);
        }

        if (addPatterns)
        {
            AddPattern(farthestPatternEndY);
        }
    }
    void AddPattern(float farthestPatternEndY)
    {
        int randomPatternIndex = Random.Range(0, availablePatterns.Length);
        GameObject pattern = Instantiate(availablePatterns[randomPatternIndex]);
        float patternHeight = pattern.transform.Find("HeightChecker").localScale.y;
        float patternCenter = farthestPatternEndY + patternHeight * 0.5f;
        pattern.transform.position = new Vector3(0, patternCenter, 0);
        currentPatterns.Add(pattern);
    }
}
