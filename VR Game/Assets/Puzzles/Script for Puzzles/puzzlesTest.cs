using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TMPro;

public class puzzlesTest : MonoBehaviour
{
    int answer1;
    int answer2;
    int answer3;
    static int trueAnswer;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    string string1;
    string string2;
    string string3;
    public TMPro.TMP_Text board;
    string objectName;
    Answer correct;
    GameObject correctObject;
    

    // Start is called before the first frame update
    void Start()
    {
        //get the random going
        System.Random rnd = new System.Random();
        //initialize variables
        answer1 = rnd.Next(999,9999);
        answer2 = rnd.Next(999,9999);
        answer3 = rnd.Next(999,9999);
        //assign the text object to board
        //board = GameObject.Find("Text (TMP)");
        //create the options to chose from
        int[] answers = new int[3] {answer1, answer2, answer3};
        GameObject[] objects = new GameObject[3] {object1, object2, object3};

        trueAnswer = answers[rnd.Next(0, answers.Length)];
        correctObject = objects[rnd.Next(0, objects.Length)];

        objectName = correctObject.name;

        //put the correct option into an object
        correct = new Answer(objectName,correctObject,trueAnswer);

        //show the correct book on the board
        board.text = correct.answer;

        //show correct combination in book
        TMPro.TMP_Text correctText = correctObject.GetComponentInChildren<TMP_Text>();
        correctText.text = correct.code.ToString();

        //take the correct combination out
        objects = Array.FindAll(objects, i => i != correctObject).ToArray();
        answers = Array.FindAll(answers, i => i != trueAnswer).ToArray();

        //assign the other values to the other books
        TMPro.TMP_Text objText1 = objects[0].GetComponentInChildren<TMP_Text>();
        TMPro.TMP_Text objText2 = objects[1].GetComponentInChildren<TMP_Text>();
        objText1.text = answers[0].ToString();
        objText2.text = answers[1].ToString();
        
        //print out the necessary info
        Debug.Log("if you look in " + correct.answer + " the combo to the lock is " + correct.code);
        Debug.Log("The possible objects were " + object1 + " " + object2 + " " + object3);
        Debug.Log("the possible combos were " + answer1 + " " + answer2 + " " + answer3);
    }

    public static bool Checkresults(string codeSequence)
    {
        int code = Int32.Parse(codeSequence);
        if (code == trueAnswer) {
            
            
            Debug.Log("The code is CORRECT");
            return true;
        } else {
            Debug.Log("The code is WRONG");
            return false;
        }
    }
    
    
}
