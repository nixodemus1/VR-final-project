using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{
    private string codeSequence;
    public TMPro.TMP_Text display;
    private bool success;
    //Door Animation.
    private Animator _doorAnim;
    public GameObject door;
    [SerializeField] AudioSource doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        codeSequence = "";
        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
        _doorAnim = door.GetComponent<Animator>();

    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if (codeSequence.Length < 4) {
                switch(digitEntered) {
                    case "Zero":
                        codeSequence += "0";
                        DisplayCodeSequence(0);
                        break;
                    case "One":
                        codeSequence += "1";
                        DisplayCodeSequence(1);
                        break;
                    case "Two":
                        codeSequence += "2";
                        DisplayCodeSequence(2);
                        break;
                    case "Three":
                        codeSequence += "3";
                        DisplayCodeSequence(3);
                        break;
                    case "Four":
                        codeSequence += "4";
                        DisplayCodeSequence(4);
                        break;
                    case "Five":
                        codeSequence += "5";
                        DisplayCodeSequence(5);
                        break;
                    case "Six":
                        codeSequence += "6";
                        DisplayCodeSequence(6);
                        break;
                    case "Seven":
                        codeSequence += "7";
                        DisplayCodeSequence(7);
                        break;
                    case "Eight":
                        codeSequence += "8";
                        DisplayCodeSequence(8);
                        break;
                    case "Nine":
                        codeSequence += "9";
                        DisplayCodeSequence(9);
                        break;
                }
        }
        switch (digitEntered) {
            case "Clear":
                ResetDisplay();
                break;
            case "Enter":
                if (codeSequence.Length > 0) {
                    success = puzzlesTest.Checkresults(codeSequence);
                }
                break;
        }
        
    }

    private void playAnimation()
    {
        if (success == true)
        {
            //Play Animation and sound
            _doorAnim.Play("Opened");
            doorOpen.Play();
        }
    }

    private void DisplayCodeSequence(int digitJustEntered){
        StringBuilder sb = new StringBuilder(4);
        switch(codeSequence.Length){
            case 1:
                sb[0] = '0';
                sb[1] = '0';
                sb[2] = '0';
                sb[3] = Convert.ToChar(digitJustEntered); // index starts at 0!
                codeSequence = sb.ToString();
                break;
            case 2:
                sb[0] = '0';
                sb[1] = '0';
                sb[2] = sb[3];
                sb[3] = Convert.ToChar(digitJustEntered);
                codeSequence = sb.ToString();
                break;
            case 3:
                sb[0] = '0';
                sb[1] = sb[2];
                sb[2] = sb[3];
                sb[3] = Convert.ToChar(digitJustEntered);
                codeSequence = sb.ToString();
                break;
            case 4:
                sb[0] = sb[1];
                sb[1] = sb[2];
                sb[2] = sb[3];
                sb[3] = Convert.ToChar(digitJustEntered);
                codeSequence = sb.ToString();
                break;
        }
    }

    public void ResetDisplay(){
        codeSequence = "";
    }

    private void OnDestroy(){
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }

    void Update()
    {
        if (success == false) {
            display.text = codeSequence;
        } else {
            display.text = "CORRECT";
            playAnimation();
        }
    }
}
