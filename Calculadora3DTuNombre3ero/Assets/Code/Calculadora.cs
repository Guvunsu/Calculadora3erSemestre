using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Calculadora : MonoBehaviour
{
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


    [SerializeField] private TextMeshProUGUI _historialTMP;
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
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField inputXField;
    [SerializeField] TMP_InputField inputYField;
    [SerializeField] TMP_InputField inputZField;
    [SerializeField] TMP_InputField inputXField2;
    [SerializeField] TMP_InputField inputYField2;
    [SerializeField] TMP_InputField inputZField2;
    [SerializeField] TextMeshProUGUI resultado;
    [SerializeField] TextMeshProUGUI resultados;
    [SerializeField] TMP_InputField inputFieldRestaVectores;
    [SerializeField] TMP_InputField inputXFieldRestaVectores;
    [SerializeField] TMP_InputField inputYFieldRestaVectores;
    [SerializeField] TMP_InputField inputZFieldRestaVectores;
    [SerializeField] TMP_InputField inputXField2RestaVectores;
    [SerializeField] TMP_InputField inputYField2RestaVectores;
    [SerializeField] TMP_InputField inputZField2RestaVectores;

    #endregion
    public void lineRender()
    {
        sphere = transform.Find("Sphere");
        sphere.localScale = 0.3f * Vector3.one;
        head = transform.Find("Head");
        head.localScale = 0.25f * Vector3.one;
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
        GetComponent<LineRenderer>().positionCount = 2;
    }
    public void inputUser()
    {
        // son los datos ingresados por el usuario desde cero.
        float result1 = 0, result2 = 0, result3 = 0, result4 = 0, result5 = 0, result6 = 0, result7 = 0, result8 = 0, result9 = 0;

        // Intentamos parsear el tercer input field. Si falla, el valor resultará en 0.
        if (!float.TryParse(inputXField.text, out result1))
            result1 = 0;
        if (!float.TryParse(inputYField.text, out result2))
            result2 = 0;
        if (!float.TryParse(inputZField.text, out result3))
            result3 = 0;
        if (!float.TryParse(inputXField2.text, out result4))
            result4 = 0;
        if (!float.TryParse(inputYField2.text, out result5))
            result5 = 0;
        if (!float.TryParse(inputZField2.text, out result6))
            result6 = 0;
        if (!float.TryParse(inputXField2.text, out result4))
            result7 = 0;
        if (!float.TryParse(inputYField2.text, out result5))
            result8 = 0;
        if (!float.TryParse(inputZField2.text, out result6))
            result9 = 0;

        string userInput = resultado.text;
        resultado.text = "" + userInput;// o solo le quito SumarVectores y ya?

        Vector3 v1 = new Vector3(result1, result2, result3);
        Vector3 v2 = new Vector3(result4, result5, result6);
        Vector3 v3 = new Vector3(result7, result8, result9);
        // Buscamos el script en la escena
        OperacionesMatematicas operaciones = FindObjectOfType<OperacionesMatematicas>();

        if (operaciones != null)
        {
            // Llamamos a la función SumarVectores del script OperacionesMatematicas
            Vector3 resultadoSuma = operaciones.SumarVectores(v1, v2);

            // Mostramos el resultado en el TextMeshPro
            resultado.text = $"Suma: ({resultadoSuma.x}, {resultadoSuma.y}, {resultadoSuma.z})";

            //agregar a las demas, solo hay que lograr que funcione este primero 
        }
        if (operaciones != null)
        {
            Vector3 resultadoResta = operaciones.RestarVectores(v1, v2);
            resultado.text = $"Resta: ({resultadoResta.x}, {resultadoResta.y}, {resultadoResta.z})";
        }
        if (operaciones != null)
        {
            float resultadoProductoPunto = operaciones.ProductoPunto(v1, v2);
            resultado.text = $"ProductoPunto: ({resultadoProductoPunto})";
        }
        if (operaciones != null)
        {
            Vector3 resultadoProductoCruz = operaciones.ProductoCruz(v1, v2);
            resultado.text = $"ProductoCruz: ({resultadoProductoCruz.x}, {resultadoProductoCruz.y}, {resultadoProductoCruz.z})";
        }
        if (operaciones != null) {
            float resultadoMagnitud = operaciones.Magnitud(v1);
            resultado.text = $"ProductoMagnitud: ({resultadoMagnitud})";
        }
        if (operaciones != null) {
            Vector3 resultadoNormalizar = operaciones.Normalizar(v1);
            resultado.text = $"ProductoNormalizar: ({resultadoNormalizar})";
        } //chatgpt
        if (operaciones != null) {
            // Ejemplo: Matriz de entrada creada manualmente
            float[,] matriz = new float[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            // Obtener las dimensiones de la matriz
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);

            // Crear una matriz para almacenar la transpuesta
            float[,] transpuesta = new float[columnas, filas];

            // Inicializar el texto del resultado
            resultado.text = "Transpuesta de la matriz:\n";

            // Proceso para calcular la transpuesta
            for (int i = 0; i < filas; i++) {
                for (int j = 0; j < columnas; j++) {
                    // Realizar la transposición
                    transpuesta[j, i] = matriz[i, j];

                    // Agregar el valor actual al texto (en formato fila x columna)
                    resultado.text += $"[{i},{j}]: {matriz[i, j]} -> [{j},{i}]: {transpuesta[j, i]}\n";
                }
            }
            // Mostrar el resultado completo
            resultado.text += "\nMatriz transpuesta completa:\n";

            // Formatear la matriz transpuesta para que se vea bien en el texto
            for (int i = 0; i < columnas; i++) {
                for (int j = 0; j < filas; j++) {
                    resultado.text += $"{transpuesta[i, j]} ";
                }
                resultado.text += "\n"; // Salto de línea por cada fila
            }
        }
        if (operaciones != null) {
            // Crear una matriz 3x3 a partir de los tres vectores
            float[,] matriz = new float[,]
            {
        { v1.x, v1.y, v1.z },
        { v2.x, v2.y, v2.z },
        { v3.x, v3.y, v3.z }
            };

            // Llamar al método con la matriz
            float resultadoDeterminante3x3 = operaciones.Determinante3x3(matriz);

            // Mostrar el resultado en el texto
            resultado.text = $"Determinante de la matriz 3x3: {resultadoDeterminante3x3}";
        }
        if (operaciones != null) {
            // Llamamos al método Descomposicion, que devuelve dos vectores
            (Vector3 componenteParalela, Vector3 componenteOrtogonal) = operaciones.Descomposicion(v1, v2);

            // Mostramos ambas componentes en el texto del resultado
            resultado.text = $"Componente Paralela: ({componenteParalela.x}, {componenteParalela.y}, {componenteParalela.z})\n" +
                             $"Componente Ortogonal: ({componenteOrtogonal.x}, {componenteOrtogonal.y}, {componenteOrtogonal.z})";
        }
        if (operaciones != null)
            if (operaciones != null) {
                // Si v1 es un solo vector, lo envolvemos en un arreglo
                Vector3[] vectores = new Vector3[] { v1 };  // Aquí envolvemos v1 en un arreglo

                // Llamamos al método Ortogonalizacion, que ahora recibe un arreglo de vectores
                List<Vector3> resultadoOrtogonalizacion = operaciones.Ortogonalizacion(vectores);  // Usamos vectores aquí

                // Mostramos los vectores ortogonales en el TextMeshPro
                string resultadoTexto = "Vectores Ortogonales: \n";
                foreach (Vector3 v in resultadoOrtogonalizacion) {
                    resultadoTexto += $"({v.x}, {v.y}, {v.z})\n";
                }

                resultado.text = resultadoTexto;  // Mostramos el resultado final
            }
        //if (operaciones != null) {
        //    float[,] v1 = new float[,] { { 1, 2 }, { 3, 4 } };  // Ejemplo de matriz 2x2
        //    float[,] v2 = new float[,] { { 5, 6 }, { 7, 8 } };  // Ejemplo de matriz 2x2
        //    float[,] resultadoSumarMatrices = operaciones.SumarMatrices(v1, v2);

        //    // Mostrar el resultado en un TextMeshPro (esto depende de cómo quieras representar la matriz)
        //    string resultadoTexto = "Resultado de la suma de matrices: \n";
        //    for (int i = 0; i < resultadoSumarMatrices.GetLength(0); i++) {
        //        for (int j = 0; j < resultadoSumarMatrices.GetLength(1); j++) {
        //            resultadoTexto += $"{resultadoSumarMatrices[i, j]} ";
        //        }
        //        resultadoTexto += "\n";
        //    }

        //    resultado.text = resultadoTexto;
        //}
        //llamo a las acciones especificas segun el tipo de operacion y si inputfield es normalizar,llamo ese panel
        if (userInput.Equals("SumaVectores", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelSumaVectores);
        }
        else if (userInput.Equals("RestarVectores", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelRestarVectores);
        }
        else if (userInput.Equals("ProductoPunto", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelProductoPunto);
        }
        else if (userInput.Equals("ProductoCruz", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelProductoCruz);
        }
        else if (userInput.Equals("Magnitud", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelMagnitud);
        }
        else if (userInput.Equals("Normalizar", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelNormalizar);
        }
        else if (userInput.Equals("Transponer", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelTransponer);
        }
        else if (userInput.Equals("Determinante3x3", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelDeterminante3x3);
        }
        else if (userInput.Equals("Descomposicion", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelDescomposicion);
        }
        else if (userInput.Equals("Ortogonalizacion", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelOrtogonalizacion);
        }
        else if (userInput.Equals("SumarMatrices", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelSumarMatrices);
        }
        else if (userInput.Equals("AnguloEntreVectores", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelAnguloEntreVectores);
        }
        else if (userInput.Equals("MultiplicarEscalar", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelMultiplicarEscalar);
        }
        else if (userInput.Equals("Reflejar", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelReflejar);
        }
        else if (userInput.Equals("InterseccionLineaPlano", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelInterseccionLineaPlano);
        }
        else if (userInput.Equals("DistanciaPuntoPlano", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelDistanciaPuntoPlano);
        }
        else if (userInput.Equals("Rotacion2D", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelRotacion2D);
        }
        else if (userInput.Equals("Rotacion3D", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelRotacion3D);
        }
        else if (userInput.Equals("ConvertirAHomogeneas", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelConvertirAHomogeneas);
        }
        else if (userInput.Equals("ReflejoEscalar", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelReflejoEscalar);
        }
        else if (userInput.Equals("TransformacionRotacion", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelTransformacionRotacion);
        }
        else if (userInput.Equals("MultiplicarMatrices", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelMultiplicarMatrices);
        }
        else if (userInput.Equals("RestarMatrices", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelRestarMatrices);
        }
        else if (userInput.Equals("InterseccionTresPlanos", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelInterseccionTresPlanos);
        }
        else if (userInput.Equals("InversaMatriz3x3", System.StringComparison.OrdinalIgnoreCase))
        {
            MostrarPanel(panelInversaMatriz3x3);
        }
        else
        {
            // Si el input no coincide con ninguna operación, muestra un mensaje.
            resultados.text = "Operación no reconocida.";
        }
    }
    #region Unity Methods
    private void Start()
    {
        _historialTMP.text = "";//no se si mejor le pongo esto Historial: \n
        inputField.onEndEdit.AddListener(ProcesarInputUsuario);
        InitializeUI();
        lineRender();
    }

    private void OnDrawGizmos()
    {
        if (vectorA.HasValue)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, vectorA.Value);
        }

        if (vectorB.HasValue)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, vectorB.Value);
        }
    }
    #endregion

    #region UI Management
    public void InitializeUI()
    {
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

    public void MostrarPanel(GameObject panel)
    {
        panel.SetActive(true);
        OcultarTodosLosPaneles();
    }

    public void OcultarTodosLosPaneles()
    {
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
    public void ProcesarInputUsuario(string usuarioInput)
    {
        if (!string.IsNullOrWhiteSpace(usuarioInput))
        {
            historialCalculo.Add(usuarioInput);
            ActualizarHistorial();
        }
        inputField.text = "";
    }

    public void ActualizarHistorial()
    {
        _historialTMP.text = "Historial: \n";
        foreach (var entrada in historialCalculo)
        {
            _historialTMP.text += entrada + "\n";
        }
    }
    #endregion

    #region Result Display
    public void MostrarResultado(string resultado)
    {
        historialCalculo.Add("Resultado: " + resultado);
        ActualizarHistorial();
    }
    #endregion
}


