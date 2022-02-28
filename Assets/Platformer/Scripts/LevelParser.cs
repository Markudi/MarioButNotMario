using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject waterPrefab;
    public GameObject goalPostPrefab;
    public GameObject goalFlagPrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                
                
                if (letter == 'x')
                {
                    //Rock
                    var rockSprite = Instantiate(rockPrefab, environmentRoot);
                    rockSprite.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'b')
                {
                    //Brick
                    var brickSprite = Instantiate(brickPrefab, environmentRoot);
                    brickSprite.transform.position = new Vector3(column, row, 0f);
                }else if (letter == '?')
                {
                    //Quesiton
                    var questionMarkSprite = Instantiate(questionBoxPrefab, environmentRoot);
                    questionMarkSprite.transform.position = new Vector3(column, row, 0f);
                }
                else if (letter == 's')
                {
                    //Stone
                    var stoneSprite = Instantiate(stonePrefab, environmentRoot);
                    stoneSprite.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'w')
                {
                    //Water
                    var waterSprite = Instantiate(waterPrefab, environmentRoot);
                    waterSprite.transform.position = new Vector3(column, row, 0f);
                }else if (letter == 'g')
                {
                    var goalSprite = Instantiate(goalPostPrefab, environmentRoot);
                    goalSprite.transform.position = new Vector3(column + 0.2f, row, 0f);
                }else if (letter == 'e')
                {
                    var goalFlag = Instantiate(goalFlagPrefab, environmentRoot);
                    goalFlag.transform.position = new Vector3(column + 0.2f, row, 0f);
                }
                
                
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
