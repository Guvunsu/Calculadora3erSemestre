using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Calculadora : MonoBehaviour {
    #region Variables
    [SerializeField] TMP_InputField m_inputField;
    //[SerializeField] private TMP_InputField[] inputFieldsSumaVectores;
    //[SerializeField] private TMP_InputField[] inputFieldsRestaVectores;
    // agregar taaaal vez las demas operaciones y esto en las operaciones MostrarResultado(resultado.ToString());
    [SerializeField] TMP_InputField _historialTMP;
    [SerializeField] Button[] operationButtons;
    [SerializeField] private GameObject panelSumaVectores;
    [SerializeField] private GameObject panelRestaVectores;
    [SerializeField] private GameObject panelProductoPunto;
    [SerializeField] private GameObject panelProductoCruz;
    [SerializeField] private GameObject panelMagnitud;
    [SerializeField] private GameObject panelNormalizar;
    [SerializeField] private GameObject panelTransponer;
    [SerializeField] private GameObject panelDeterminante;
    [SerializeField] private GameObject panelDescomposicion;
    [SerializeField] private GameObject panelOrtogonalizacion;
    [SerializeField] private GameObject panelSumaMatrices;
    [SerializeField] private GameObject panelRestaMatrices;
    [SerializeField] private GameObject panelMultiplicacionMatrices;

    // para la captacion de que el usuario ingrece
    [SerializeField] InputField inputField;
    [SerializeField] InputField inputField1;
    [SerializeField] InputField inputField2;
    [SerializeField] Text texto;
    [SerializeField] TextMeshPro text;
    [SerializeField] ScriptableObject script;

    private List<TMP_InputField> inputFieldsList = new List<TMP_InputField>();
    List<string> m_historialCalculoAnteriorTexto = new List<string>();


    // llamo mi script no monobehaviour de las operaciones matematicas
    public OperacionesMatematicas OperacionesMatematicas { get; private set; }


    // Para almacenar los vectores y matrices que se dibujarán en Gizmos
    private Vector3? vectorA = null;
    private Vector3? vectorB = null;
    private Matrix4x4? matrixA = null;
    private Matrix4x4? matrixB = null;
    #endregion Variables

    #region Funciones Start Update
    void Start() {
        _historialTMP.text = "Historial:  \n";
        m_inputField.onEndEdit.AddListener(procesamientoLogicoInput);
        InitializeUI();
        OperacionesMatematicas = new OperacionesMatematicas();
        // Llamar a inputUser cuando se termine de editar el campo de texto
        m_inputField.onEndEdit.AddListener((text) => inputUser());

        //void Update() {

        //}
        #endregion Funciones Start Update

        #region Funciones para el análisis del texto y botones
        public void inputUser() {
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
           // FindObjectOfType<OperacionesMatematicas>(userInput);

            //hacerlo 3 veces para cada panel , si hay sumas por ejemplo llamar 2 de estas y 3 cuando hay matrices 3x3
        }
        public void MostrarResultado(string resultado) {
            _historialTMP.text += "Resultado: " + resultado + "\n";
        }

        void InitializeUI() {
            // Asignacion de cada botón a su función específica
            operationButtons[0].onClick.AddListener(() => MostrarPanel("SumaVectores"));
            operationButtons[1].onClick.AddListener(() => MostrarPanel("RestaVectores"));
            operationButtons[2].onClick.AddListener(() => MostrarPanel("ProductoPunto"));
            operationButtons[3].onClick.AddListener(() => MostrarPanel("ProductoCruz"));
            operationButtons[4].onClick.AddListener(() => MostrarPanel("Magnitud"));
            operationButtons[5].onClick.AddListener(() => MostrarPanel("Normalizar"));
            operationButtons[6].onClick.AddListener(() => MostrarPanel("Transponer"));
            operationButtons[7].onClick.AddListener(() => MostrarPanel("Determinante"));
            operationButtons[8].onClick.AddListener(() => MostrarPanel("Descomposicion"));
            operationButtons[9].onClick.AddListener(() => MostrarPanel("Ortogonalizacion"));
            operationButtons[10].onClick.AddListener(() => MostrarPanel("SumaMatrices"));
            operationButtons[11].onClick.AddListener(() => MostrarPanel("RestaMatrices"));
            operationButtons[12].onClick.AddListener(() => MostrarPanel("MultiplicacionMatrices"));
        }

        //para mostrar el panel de la operación seleccionada
        void MostrarPanel(string operacion) {
            OcultarTodosLosPaneles();

            // Mostrar el panel correspondiente a la operación
            switch (operacion) {
                case "SumaVectores":
                    panelSumaVectores.SetActive(true);
                    break;
                case "RestaVectores":
                    panelRestaVectores.SetActive(true);
                    break;
                case "ProductoPunto":
                    panelProductoPunto.SetActive(true);
                    break;
                case "ProductoCruz":
                    panelProductoCruz.SetActive(true);
                    break;
                case "Magnitud":
                    panelMagnitud.SetActive(true);
                    break;
                case "Normalizar":
                    panelNormalizar.SetActive(true);
                    break;
                case "Transponer":
                    panelTransponer.SetActive(true);
                    break;
                case "Determinante":
                    panelDeterminante.SetActive(true);
                    break;
                case "Descomposicion":
                    panelDescomposicion.SetActive(true);
                    break;
                case "Ortogonalizacion":
                    panelOrtogonalizacion.SetActive(true);
                    break;
                case "SumaMatrices":
                    panelSumaMatrices.SetActive(true);
                    break;
                case "RestaMatrices":
                    panelRestaMatrices.SetActive(true);
                    break;
                case "MultiplicacionMatrices":
                    panelMultiplicacionMatrices.SetActive(true);
                    break;
            }

        }

        void OcultarTodosLosPaneles() {
            panelSumaVectores.SetActive(false);
            panelRestaVectores.SetActive(false);
            panelProductoPunto.SetActive(false);
            panelProductoCruz.SetActive(false);
            panelMagnitud.SetActive(false);
            panelNormalizar.SetActive(false);
            panelTransponer.SetActive(false);
            panelDeterminante.SetActive(false);
            panelDescomposicion.SetActive(false);
            panelOrtogonalizacion.SetActive(false);
            panelSumaMatrices.SetActive(false);
            panelRestaMatrices.SetActive(false);
            panelMultiplicacionMatrices.SetActive(false);
        }

        void procesamientoLogicoInput(string usuarioInput) {
            m_historialCalculoAnteriorTexto.Add(usuarioInput);
            actualizacionHistorialTexto();
            m_inputField.text = "";
        }

        void actualizacionHistorialTexto() {
            _historialTMP.text = "Historial:  \n ";
            foreach (string calculoImprida in m_historialCalculoAnteriorTexto) {
                _historialTMP.text += calculoImprida + "\n";
            }
        }
        #endregion  Funciones para el análisis del texto y botones
        // Mostrar el resultado de las operaciones
        //public void MostrarResultado(string resultado) {
        //    _historialTMP.text += resultado + "\n";
        //}

        #region Dibujar Gizmos
        void OnDrawGizmos() {
            if (vectorA.HasValue) {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(Vector3.zero, vectorA.Value);
            }

            if (vectorB.HasValue) {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(Vector3.zero, vectorB.Value);
            }

            if (matrixA.HasValue) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(matrixA.Value.GetColumn(0), matrixA.Value.GetColumn(1));
            }
        }
        #endregion Dibujar Gizmos
    }
}

