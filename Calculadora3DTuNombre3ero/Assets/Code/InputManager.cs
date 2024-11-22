using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] InputField inputField1;
    [SerializeField] InputField inputField2;
    [SerializeField] Text texto;
    [SerializeField] TextMeshPro text;
    [SerializeField] ScriptableObject script;

    public void inputUser()
    {
        float result1 = 0, result2 = 0, result3 = 0;
        if (!float.TryParse(inputField.text, out result1))
            result1 = 0;
        if (!float.TryParse(inputField1.text, out result2))
            result2 = 0;
        if (!float.TryParse(inputField2.text, out result3))
            result3 = 0;
        Vector3 v = new Vector3(result1, result2, result3);


        string userInput = inputField.text;
        texto.text = "Operacion" + userInput;
        // FindObjectOfType<Calculadora>(userInput);

        //hacerlo 3 veces para cada panel , si hay sumas por ejemplo llamar 2 de estas y 3 cuando hay matrices 3x3
    }

}
