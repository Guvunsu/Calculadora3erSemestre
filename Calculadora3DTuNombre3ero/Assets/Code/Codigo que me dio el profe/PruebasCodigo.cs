//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class InputManager : MonoBehaviour {
//    [SerializeField] InputField inputField;
//    [SerializeField] InputField inputField1;
//    [SerializeField] InputField inputField2;
//    [SerializeField] Text texto;
//    [SerializeField] TextMeshPro text;
//    [SerializeField] ScriptableObject script;

//    public void inputUser() {
//        float result1 = 0, result2 = 0, result3 = 0;
//        if (!float.TryParse(inputField.text, out result1))
//            result1 = 0;
//        if (!float.TryParse(inputField1.text, out result2))
//            result2 = 0;
//        if (!float.TryParse(inputField2.text, out result3))
//            result3 = 0;
//        Vector3 v = new Vector3(result1, result2, result3);


//        string userInput = inputField.text;
//        texto.text = "Operacion" + userInput;
//        // FindObjectOfType<Calculadora>(userInput);

//        //hacerlo 3 veces para cada panel , si hay sumas por ejemplo llamar 2 de estas y 3 cuando hay matrices 3x3
//    }

//}



//     lo otro no funciona pero no afecat si esta o no esta comentado , despues de esto hay mas codigo funcional, mas o menos


//llamo a las acciones especificas segun el tipo de operacion y si inputfield es normalizar,llamo ese panel
//    if (userInput.Equals("SumaVectores", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelSumaVectores);
//} else if (userInput.Equals("RestarVectores", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelRestarVectores);
//} else if (userInput.Equals("ProductoPunto", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelProductoPunto);
//} else if (userInput.Equals("ProductoCruz", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelProductoCruz);
//} else if (userInput.Equals("Magnitud", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelMagnitud);
//} else if (userInput.Equals("Normalizar", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelNormalizar);
//} else if (userInput.Equals("Transponer", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelTransponer);
//} else if (userInput.Equals("Determinante3x3", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelDeterminante3x3);
//} else if (userInput.Equals("Descomposicion", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelDescomposicion);
//} else if (userInput.Equals("Ortogonalizacion", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelOrtogonalizacion);
//} else if (userInput.Equals("SumarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelSumarMatrices);
//} else if (userInput.Equals("AnguloEntreVectores", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelAnguloEntreVectores);
//} else if (userInput.Equals("MultiplicarEscalar", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelMultiplicarEscalar);
//} else if (userInput.Equals("Reflejar", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelReflejar);
//} else if (userInput.Equals("InterseccionLineaPlano", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelInterseccionLineaPlano);
//} else if (userInput.Equals("DistanciaPuntoPlano", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelDistanciaPuntoPlano);
//} else if (userInput.Equals("Rotacion2D", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelRotacion2D);
//} else if (userInput.Equals("Rotacion3D", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelRotacion3D);
//} else if (userInput.Equals("ConvertirAHomogeneas", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelConvertirAHomogeneas);
//} else if (userInput.Equals("ReflejoEscalar", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelReflejoEscalar);
//} else if (userInput.Equals("TransformacionRotacion", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelTransformacionRotacion);
//} else if (userInput.Equals("MultiplicarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelMultiplicarMatrices);
//} else if (userInput.Equals("RestarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelRestarMatrices);
//} else if (userInput.Equals("InterseccionTresPlanos", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelInterseccionTresPlanos);
//} else if (userInput.Equals("InversaMatriz3x3", System.StringComparison.OrdinalIgnoreCase)) {
//    MostrarPanel(panelInversaMatriz3x3);
//} else {
//    // Si el input no coincide con ninguna operación, muestra un mensaje.
//    resultados.text = "Operación no reconocida.";
//}





//if (operaciones != null) {
//    // Llama la función SumarVectores de OperacionesMatematicas
//    Vector3 resultadoSuma = operaciones.SumarVectores(v1, v2);
//    // Mostramos el resultado en un TextMeshPro
//    resultado.text = $"Suma: ({resultadoSuma.x}, {resultadoSuma.y}, {resultadoSuma.z})";

//    //agregar a las demas, solo hay que lograr que funcione este primero 
//}