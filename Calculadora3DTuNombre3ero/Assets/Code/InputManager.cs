using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    InputField inputField;
    Text texto;
    TextMeshPro text;
    [SerializeField] ScriptableObject script;

    public void inputUser()
    {
        string userInput = inputField.text;
        texto.text = "Operacion" + userInput;
       // FindObjectOfType<Calculadora>(userInput);

       
    }

}
