using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour {
    [SerializeField] InputField inputField;
    [SerializeField] Text texto;
    [SerializeField] TextMeshPro text;
    [SerializeField] ScriptableObject script;

    public void inputUser() {
        string userInput = inputField.text;
        texto.text = "Operacion" + userInput;
        // FindObjectOfType<Calculadora>(userInput);


    }

}
