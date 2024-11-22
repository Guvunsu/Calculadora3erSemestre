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

    private List<TMP_InputField> inputFieldsList = new List<TMP_InputField>();
    List<string> m_historialCalculoAnteriorTexto = new List<string>();

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
    }

    void Update() {

    }
    #endregion Funciones Start Update

    #region Funciones para el análisis del texto y botones
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
    public void MostrarResultado(string resultado) {
        _historialTMP.text += resultado + "\n";
    }
    // implementar las operaciones que nos dio el profe para implementarlas, estan en mi cuaderno
    #region Operaciones Matemáticas
    // Suma de vectores

    // hacer un metodo donde me llame estos metodos porque no jala al llamar vectores
    // ponerlo en un gameObject vacio o en un monobehaviour que llame los valores 
    // 
    public void SumarVectores(Vector3 v1, Vector3 v2) {
        //    vectorA = v1;
        //    vectorB = v2;
        //    Vector3 resultado = v1 + v2;
        //    MostrarResultado(resultado.ToString());
        new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        //MostrarResultado(resultado.ToString());
    }

    // Resta de vectores
    public void RestarVectores(Vector3 v1, Vector3 v2) {
        /* vectorA = v1;
         vectorB = v2;
         Vector3 resultado = v1 - v2;
         MostrarResultado(resultado.ToString());*/
        new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }

    // Producto punto
    public void ProductoPunto(Vector3 v1, Vector3 v2) {
        /* float resultado = Vector3.Dot(v1, v2);
         MostrarResultado(resultado.ToString());*/
        float resultado = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        MostrarResultado(resultado.ToString());

    }

    // Producto cruzado
    public void ProductoCruz(Vector3 v1, Vector3 v2) {
        //vectorA = v1;
        //vectorB = v2;
        //Vector3 resultado = Vector3.Cross(v1, v2);
        //MostrarResultado(resultado.ToString());
        float x = (v1.y * v2.z) - (v1.z * v2.y);
        float y = (v1.z * v2.x) - (v1.x * v2.z);
        float z = (v1.x * v2.y) - (v1.y * v2.x);

        Vector3 resultado = new Vector3(x, y, z);
        MostrarResultado(resultado.ToString());
    }

    // Magnitud
    public void Magnitud(Vector3 v) {
        //float resultado = v.magnitude;
        //MostrarResultado(resultado.ToString());
        float resultado = Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
        MostrarResultado(resultado.ToString());
    }

    // Normalizar un vector
    public void Normalizar(Vector3 v) {
        //Vector3 resultado = v.normalized;
        //MostrarResultado(resultado.ToString());
        float magnitud = Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        if (magnitud > 0) {
            MostrarResultado($"({v.x / magnitud}, {v.y / magnitud}, {v.z / magnitud})");
        } else {
            MostrarResultado("No se puede normalizar un vector de magnitud 0");
        }
    }

    // Transponer una matriz (Ejemplo con 2x2)
    public void Transponer(Matrix4x4 matriz) {
        //matrixA = matriz;
        //Matrix4x4 resultado = Matrix4x4.Transpose(matriz);
        //MostrarResultado(resultado.ToString());
        float[,] transpuesta = new float[3, 3];

        // Intercambiar filas y columnas
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                transpuesta[i, j] = matriz[j, i];
            }
        }

        // Mostrar la matriz transpuesta
        string resultado = "Matriz Transpuesta:\n";
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                resultado += transpuesta[i, j] + " ";
            }
            resultado += "\n";
        }
        MostrarResultado(resultado);
    }

    // Determinante de una matriz 3x3
    public void Determinante(Matrix4x4 matriz) {
        //matrixA = matriz;
        //float resultado = DeterminanteMatriz3x3(matriz);
        //MostrarResultado(resultado.ToString());

    }
    //determinante de una matriz 3x3
        public float Determinante3x3(float[,] matriz) {
            float determinante = matriz[0, 0] * (matriz[1, 1] * matriz[2, 2] - matriz[1, 2] * matriz[2, 1])
                               - matriz[0, 1] * (matriz[1, 0] * matriz[2, 2] - matriz[1, 2] * matriz[2, 0])
                               + matriz[0, 2] * (matriz[1, 0] * matriz[2, 1] - matriz[1, 1] * matriz[2, 0]);

            return determinante;
        }

    // Descomposición de un vector en componentes paralela y ortogonal
    public void Descomposicion(Vector3 v1, Vector3 v2) {
        Vector3 componenteParalela = Vector3.Project(v1, v2);
        Vector3 componenteOrtogonal = v1 - componenteParalela;
        MostrarResultado($"Paralela: {componenteParalela}, Ortogonal: {componenteOrtogonal}");
    }

    // Ortogonalización de Gram-Schmidt (Ejemplo con un array de vectores)
    public void Ortogonalizacion(Vector3[] vectores) {
        // Implementación de Gram-Schmidt
    }

    // Suma de matrices (Ejemplo con matrices 2x2)
    public void SumarMatrices(Matrix4x4 m1, Matrix4x4 m2) {
        matrixA = m1;
        matrixB = m2;
        Matrix4x4 resultado = new Matrix4x4();

        // Sumar elemento por elemento
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                resultado[i, j] = m1[i, j] + m2[i, j];
            }
        }

        MostrarResultado(resultado.ToString());
    }

    #endregion Operaciones Matemáticas

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

