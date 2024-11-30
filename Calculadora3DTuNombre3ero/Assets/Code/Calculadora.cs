using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculadora : MonoBehaviour {
    #region Variables
    public OperacionesMatematicas matematicas;

    //[SerializeField] private TMP_InputField m_inputField;
    [SerializeField] private TMP_InputField _historialTMP;
    [SerializeField] private Button[] operationButtons;

    // Paneles de operaciones
    [SerializeField] private GameObject panelSumaVectores;
    [SerializeField] private GameObject panelRestarVectores;
    [SerializeField] private GameObject panelProductoPunto;
    [SerializeField] private GameObject panelProductoCruz;
    [SerializeField] private GameObject panelMagnitud;
    [SerializeField] private GameObject panelNormalizar;
    [SerializeField] private GameObject panelTransponer;
    [SerializeField] private GameObject panelDeterminante3x3;
    [SerializeField] private GameObject panelDescomposicion;
    [SerializeField] private GameObject panelOrtogonalizacion;
    [SerializeField] private GameObject panelSumaMatrices;
    [SerializeField] private GameObject panelRestaMatrices;
    [SerializeField] private GameObject panelMultiplicacionMatrices;
    [SerializeField] private GameObject panelAnguloEntreVectores;
    [SerializeField] private GameObject panelMultiplicarEscalar;
    [SerializeField] private GameObject panelReflejar;
    [SerializeField] private GameObject panelInterseccionLineaPlano;
    [SerializeField] private GameObject panelDistanciaPuntoPlano;
    [SerializeField] private GameObject panelConvertirAHomogeneas;
    [SerializeField] private GameObject panelRotacion2D;
    [SerializeField] private GameObject panelRotacion3D;
    [SerializeField] private GameObject panelReflejoEscalar;
    [SerializeField] private GameObject panelTransformacionRotacion;
    [SerializeField] private GameObject panelMultiplicarMatrices;
    [SerializeField] private GameObject panelRestarMatrices;
    [SerializeField] private GameObject panelInterseccionTresPlanos;
    [SerializeField] private GameObject panelInversaMatriz3x3;
    [SerializeField] private GameObject panelSumarMatrices;

    private List<string> historialCalculo = new List<string>();

    // Para dibujar en Gizmos
    private Vector3? vectorA = null;
    private Vector3? vectorB = null;

    [SerializeField] InputField inputField;
    [SerializeField] InputField inputField1;
    [SerializeField] InputField inputField2;
    [SerializeField] Text texto;
    [SerializeField] TextMeshPro text;
    [SerializeField] ScriptableObject script;

    #endregion

    public void inputUser() {
        //float result1 = 0, result2 = 0, result3 = 0;
        //if (!float.TryParse(inputField[2].text, out result1))
        //    result1 = 0;
        //if (!float.TryParse(inputField1.text, out result2))
        //    result2 = 0;
        //if (!float.TryParse(inputField2.text, out result3))
        //    result3 = 0;
        //Vector3 v = new Vector3(result1, result2, result3);


        //string userInput = inputField[2].text;
        //texto.text = "Operacion" + userInput;
        // FindObjectOfType<Calculadora>(userInput);
        //hacerlo 3 veces para cada panel , si hay sumas por ejemplo llamar 2 de estas y 3 cuando hay matrices 3x3


        // Inicializamos los resultados como 0. Estos valores se llenarán con los datos ingresados por el usuario.
        float result1 = 0, result2 = 0, result3 = 0;

        // Intentamos parsear el tercer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputField.text, out result1))
            result1 = 0;

        // Intentamos parsear el primer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputField1.text, out result2))
            result2 = 0;

        // Intentamos parsear el segundo input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputField2.text, out result3))
            result3 = 0;

        // Creamos un vector con los valores procesados de los campos de entrada.
        Vector3 v = new Vector3(result1, result2, result3);

        // Recuperamos la entrada del usuario directamente del tercer input field (puedes adaptarlo según el campo relevante).
        string userInput = inputField.text;

        // Actualizamos el texto en pantalla para informar al usuario de la operación seleccionada.
        texto.text = "Operacion: " + userInput;

        // Aquí podrías realizar acciones específicas según el tipo de operación seleccionada:
        // Ejemplo: Si userInput es "suma", llamas al panel de suma.
        if (userInput.Equals("SumaVectores", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelSumaVectores); // Llamamos al panel específico 
        } else if (userInput.Equals("RestarVectores", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelRestarVectores); 
        } else if (userInput.Equals("ProductoPunto", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelProductoPunto);
        } else if (userInput.Equals("ProductoCruz", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelProductoCruz); 
        } else if (userInput.Equals("Magnitud", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelMagnitud); 
        } else if (userInput.Equals("Normalizar", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelNormalizar);
        } else if (userInput.Equals("Transponer", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelTransponer); 
        } else if (userInput.Equals("Determinante3x3", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelDeterminante3x3); 
        } else if (userInput.Equals("Descomposicion", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelDescomposicion);
        } else if (userInput.Equals("Ortogonalizacion", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelOrtogonalizacion);
        } else if (userInput.Equals("SumarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelSumarMatrices); 
        } else if (userInput.Equals("AnguloEntreVectores", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelAnguloEntreVectores); 
        } else if (userInput.Equals("MultiplicarEscalar", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelMultiplicarEscalar); 
        } else if (userInput.Equals("Reflejar", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelReflejar); 
        } else if (userInput.Equals("InterseccionLineaPlano", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelInterseccionLineaPlano); 
        } else if (userInput.Equals("DistanciaPuntoPlano", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelDistanciaPuntoPlano);
        } else if (userInput.Equals("Rotacion2D", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelRotacion2D); 
        } else if (userInput.Equals("Rotacion3D", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelRotacion3D); 
        } else if (userInput.Equals("ConvertirAHomogeneas", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelConvertirAHomogeneas); 
        } else if (userInput.Equals("ReflejoEscalar", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelReflejoEscalar); 
        } else if (userInput.Equals("TransformacionRotacion", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelTransformacionRotacion); 
        } else if (userInput.Equals("MultiplicarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelMultiplicarMatrices);
        } else if (userInput.Equals("RestarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelRestarMatrices); 
        } else if (userInput.Equals("InterseccionTresPlanos", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelInterseccionTresPlanos);
        } else if (userInput.Equals("InversaMatriz3x3", System.StringComparison.OrdinalIgnoreCase)) {
            MostrarPanel(panelInversaMatriz3x3); 
        } else {
            // Si el input no coincide con ninguna operación, mostramos un mensaje.
            texto.text = "Operación no reconocida.";
        }
    }
    #region Unity Methods
    private void Start() {
        _historialTMP.text = "Historial: \n";
        inputField.onEndEdit.AddListener(ProcesarInputUsuario);
        InitializeUI();
    }

    private void OnDrawGizmos() {
        if (vectorA.HasValue) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, vectorA.Value);
        }

        if (vectorB.HasValue) {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, vectorB.Value);
        }
    }
    #endregion

    #region UI Management
    private void InitializeUI() {
        operationButtons[0].onClick.AddListener(() => MostrarPanel(panelSumaVectores));
        operationButtons[1].onClick.AddListener(() => MostrarPanel(panelRestarVectores));
        operationButtons[2].onClick.AddListener(() => MostrarPanel(panelProductoPunto));
        operationButtons[3].onClick.AddListener(() => MostrarPanel(panelProductoCruz));
        operationButtons[4].onClick.AddListener(() => MostrarPanel(panelMagnitud));
        operationButtons[5].onClick.AddListener(() => MostrarPanel(panelNormalizar));
        operationButtons[6].onClick.AddListener(() => MostrarPanel(panelTransponer));
        operationButtons[7].onClick.AddListener(() => MostrarPanel(panelDeterminante3x3));
        operationButtons[8].onClick.AddListener(() => MostrarPanel(panelDescomposicion));
        operationButtons[9].onClick.AddListener(() => MostrarPanel(panelOrtogonalizacion));
        operationButtons[10].onClick.AddListener(() => MostrarPanel(panelSumarMatrices));
        operationButtons[11].onClick.AddListener(() => MostrarPanel(panelAnguloEntreVectores));
        operationButtons[12].onClick.AddListener(() => MostrarPanel(panelMultiplicarEscalar));
        operationButtons[13].onClick.AddListener(() => MostrarPanel(panelReflejar));
        operationButtons[14].onClick.AddListener(() => MostrarPanel(panelInterseccionLineaPlano));
        operationButtons[15].onClick.AddListener(() => MostrarPanel(panelDistanciaPuntoPlano));
        operationButtons[16].onClick.AddListener(() => MostrarPanel(panelRotacion2D));
        operationButtons[17].onClick.AddListener(() => MostrarPanel(panelRotacion3D));
        operationButtons[18].onClick.AddListener(() => MostrarPanel(panelConvertirAHomogeneas));
        operationButtons[19].onClick.AddListener(() => MostrarPanel(panelReflejoEscalar));
        operationButtons[20].onClick.AddListener(() => MostrarPanel(panelTransformacionRotacion));
        operationButtons[21].onClick.AddListener(() => MostrarPanel(panelMultiplicarMatrices));
        operationButtons[22].onClick.AddListener(() => MostrarPanel(panelRestarMatrices));
        operationButtons[23].onClick.AddListener(() => MostrarPanel(panelInterseccionTresPlanos));
        operationButtons[24].onClick.AddListener(() => MostrarPanel(panelInversaMatriz3x3));



    }

    private void MostrarPanel(GameObject panel) {
        OcultarTodosLosPaneles();
        panel.SetActive(true);
    }

    private void OcultarTodosLosPaneles() {
        panelSumaVectores.SetActive(false);
        panelRestarVectores.SetActive(false);
        panelProductoPunto.SetActive(false);
        panelProductoCruz.SetActive(false);
        panelMagnitud.SetActive(false);
        panelNormalizar.SetActive(false);
        panelTransponer.SetActive(false);
        panelDeterminante3x3.SetActive(false);
        panelDescomposicion.SetActive(false);
        panelOrtogonalizacion.SetActive(false);
        panelSumarMatrices.SetActive(false);
        panelAnguloEntreVectores.SetActive(false);
        panelMultiplicarEscalar.SetActive(false);
        panelReflejar.SetActive(false);
        panelInterseccionLineaPlano.SetActive(false);
        panelDistanciaPuntoPlano.SetActive(false);
        panelRotacion2D.SetActive(false);
        panelRotacion3D.SetActive(false);
        panelConvertirAHomogeneas.SetActive(false);
        panelReflejoEscalar.SetActive(false);
        panelTransformacionRotacion.SetActive(false);
        panelMultiplicarMatrices.SetActive(false);
        panelRestarMatrices.SetActive(false);
        panelInterseccionTresPlanos.SetActive(false);
        panelInversaMatriz3x3.SetActive(false);
    }
    #endregion

    #region Input Processing
    private void ProcesarInputUsuario(string usuarioInput) {
        if (!string.IsNullOrWhiteSpace(usuarioInput)) {
            historialCalculo.Add(usuarioInput);
            ActualizarHistorial();
        }
        inputField.text = "";
    }

    private void ActualizarHistorial() {
        _historialTMP.text = "Historial: \n";
        foreach (var entrada in historialCalculo) {
            _historialTMP.text += entrada + "\n";
        }
    }
    #endregion

    #region Result Display
    public void MostrarResultado(string resultado) {
        historialCalculo.Add("Resultado: " + resultado);
        ActualizarHistorial();
    }
    #endregion
}


