using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculadora : MonoBehaviour {
    #region Variables
    [SerializeField] private TMP_InputField m_inputField;
    [SerializeField] private TMP_InputField _historialTMP;
    [SerializeField] private Button[] operationButtons;

    // Paneles de operaciones
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
    [SerializeField] private GameObject panelAnguloEntreVectores;
    [SerializeField] private GameObject panelMultiplicarEscalar;
    [SerializeField] private GameObject panelReflejar;
    [SerializeField] private GameObject panelInterseccionLineaPlano;
    [SerializeField] private GameObject panelDistanciaPuntoPlano;
    [SerializeField] private GameObject panelConvertirAHomogeneas;
    [SerializeField] private GameObject panelRotacion2D;
    [SerializeField] private GameObject panelRotacion3D;

    private List<string> historialCalculo = new List<string>();

    // Para dibujar en Gizmos
    private Vector3? vectorA = null;
    private Vector3? vectorB = null;
    private Matrix4x4? matrixA = null;
    #endregion

    #region Unity Methods
    private void Start() {
        _historialTMP.text = "Historial: \n";
        m_inputField.onEndEdit.AddListener(ProcesarInputUsuario);
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
        operationButtons[1].onClick.AddListener(() => MostrarPanel(panelRestaVectores));
        operationButtons[2].onClick.AddListener(() => MostrarPanel(panelProductoPunto));
        operationButtons[3].onClick.AddListener(() => MostrarPanel(panelProductoCruz));
        operationButtons[4].onClick.AddListener(() => MostrarPanel(panelMagnitud));
        operationButtons[5].onClick.AddListener(() => MostrarPanel(panelNormalizar));
        operationButtons[6].onClick.AddListener(() => MostrarPanel(panelTransponer));
        operationButtons[7].onClick.AddListener(() => MostrarPanel(panelDeterminante));
        operationButtons[8].onClick.AddListener(() => MostrarPanel(panelDescomposicion));
        operationButtons[9].onClick.AddListener(() => MostrarPanel(panelOrtogonalizacion));
        operationButtons[10].onClick.AddListener(() => MostrarPanel(panelSumaMatrices));
        operationButtons[11].onClick.AddListener(() => MostrarPanel(panelRestaMatrices));
        operationButtons[12].onClick.AddListener(() => MostrarPanel(panelMultiplicacionMatrices));
        operationButtons[13].onClick.AddListener(() => MostrarPanel(panelAnguloEntreVectores));
        operationButtons[14].onClick.AddListener(() => MostrarPanel(panelMultiplicarEscalar));
        operationButtons[15].onClick.AddListener(() => MostrarPanel(panelReflejar));
        operationButtons[16].onClick.AddListener(() => MostrarPanel(panelInterseccionLineaPlano));
        operationButtons[17].onClick.AddListener(() => MostrarPanel(panelRotacion2D));
        operationButtons[17].onClick.AddListener(() => MostrarPanel(panelRotacion3D));
        operationButtons[17].onClick.AddListener(() => MostrarPanel(panelConvertirAHomogeneas));

    }

    private void MostrarPanel(GameObject panel) {
        OcultarTodosLosPaneles();
        panel.SetActive(true);
    }

    private void OcultarTodosLosPaneles() {
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
        panelAnguloEntreVectores.SetActive(false);
        panelMultiplicarEscalar.SetActive(false);
        panelReflejar.SetActive(false);
        panelInterseccionLineaPlano.SetActive(false);
        panelDistanciaPuntoPlano.SetActive(false);
        panelConvertirAHomogeneas.SetActive(false);
        panelRotacion3D.SetActive(false);
        panelRotacion2D.SetActive(false);
    }
    #endregion

    #region Input Processing
    private void ProcesarInputUsuario(string usuarioInput) {
        if (!string.IsNullOrWhiteSpace(usuarioInput)) {
            historialCalculo.Add(usuarioInput);
            ActualizarHistorial();
        }
        m_inputField.text = "";
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


