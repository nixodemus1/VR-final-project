using UnityEngine;
using System;
using UnityEngine.UI;

public class PushTheButton : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };
    private string buttonName, buttonValue;

    // Start is called before the first frame update
    void Start()
    {
        buttonName = gameObject.name;
        buttonValue = buttonName;

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        ButtonPressed(buttonValue);
    }
}
