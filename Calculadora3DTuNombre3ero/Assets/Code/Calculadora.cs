using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Calculadora : MonoBehaviour {
    #region Variables
    public OperacionesMatematicas matematicas;

    //[SerializeField] private TMP_InputField m_inputField;


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
    [SerializeField] private Text _historialTMP;
    [SerializeField] private Button[] operationButtons;
    private List<string> historialCalculo = new List<string>();

    // Para dibujar en Gizmos
    private Vector3? vectorA = null;
    private Vector3? vectorB = null;

    //LineRnederer
    public Color color;
    //public Material material;
    private Transform head;
    private Transform sphere;
    [SerializeField] InputField inputField;
    [SerializeField] InputField inputXField;
    [SerializeField] InputField inputYField;
    [SerializeField] InputField inputZField;
    [SerializeField] InputField inputXField2;
    [SerializeField] InputField inputYField2;
    [SerializeField] InputField inputZField2;
    [SerializeField] Text resultado;
    [SerializeField] TextMeshPro resultados;


    #endregion
    public void lineRender() {
        sphere = transform.Find("Sphere");
        sphere.localScale = 0.3f * Vector3.one;
        head = transform.Find("Head");
        head.localScale = 0.25f * Vector3.one;
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
        GetComponent<LineRenderer>().positionCount = 2;
    }
    public void inputUser() {
        // son los datos ingresados por el usuario desde cero.
        float result1 = 0, result2 = 0, result3 = 0, result4 = 0, result5 = 0, result6 = 0;

        // Intentamos parsear el tercer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputXField.text, out result1))
            result1 = 0;

        // Intentamos parsear el primer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputYField.text, out result2))
            result2 = 0;

        // Intentamos parsear el segundo input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputZField.text, out result3))
            result3 = 0;
        // Intentamos parsear el tercer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputXField2.text, out result4))
            result4 = 0;

        // Intentamos parsear el primer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputYField2.text, out result5))
            result5 = 0;

        // Intentamos parsear el segundo input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputZField2.text, out result6))
            result6 = 0;


        string userInput = resultado.text;
        resultado.text = "" + userInput;// o solo le quito SumarVectores y ya?

        Vector3 v1 = new Vector3(result1, result2, result3);
        Vector3 v2 = new Vector3(result4, result5, result6);

        // Buscamos el script en la escena
        OperacionesMatematicas operaciones = FindObjectOfType<OperacionesMatematicas>();

        if (operaciones != null) {
            // Llamamos a la función SumarVectores del script OperacionesMatematicas
            Vector3 resultadoSuma = operaciones.SumarVectores(v1, v2);

            // Mostramos el resultado en el TextMeshPro
            resultado.text = $"Suma: ({resultadoSuma.x}, {resultadoSuma.y}, {resultadoSuma.z})";

            //agregar a las demas, solo hay que lograr que funcione este primero 
        }

        ////llamo a las acciones especificas segun el tipo de operacion y si inputfield es normalizar,llamo ese panel
        //if (userInput.Equals("SumaVectores", System.StringComparison.OrdinalIgnoreCase)) {
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
    }
    #region Unity Methods
    private void Start() {
        _historialTMP.text = "";//no se si mejor le pongo esto Historial: \n
        inputField.onEndEdit.AddListener(ProcesarInputUsuario);
        InitializeUI();
        lineRender();
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
        panel.SetActive(true);
        OcultarTodosLosPaneles();
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


