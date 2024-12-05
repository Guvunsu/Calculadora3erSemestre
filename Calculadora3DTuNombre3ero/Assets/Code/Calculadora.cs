using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using JetBrains.Annotations;

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
    [SerializeField] private GameObject panelSumarMatrices;
    [SerializeField] private GameObject panelRestarMatrices;
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
    [SerializeField] private GameObject panelInterseccionTresPlanos;
    [SerializeField] private GameObject panelInversaMatriz3x3;



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


    public Dictionary<string, List<TMP_InputField>> operacionesInputs = new Dictionary<string, List<TMP_InputField>>();

    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField inputXField;
    [SerializeField] TMP_InputField inputYField;
    [SerializeField] TMP_InputField inputZField;
    [SerializeField] TMP_InputField inputWField;
    [SerializeField] TMP_InputField inputXField2;
    [SerializeField] TMP_InputField inputYField2;
    [SerializeField] TMP_InputField inputZField2;
    [SerializeField] TMP_InputField inputWField2;
    //aplica para Determinantes3x3, SUMASMATRICES4X4
    [SerializeField] TMP_InputField inputXField3;
    [SerializeField] TMP_InputField inputYField3;
    [SerializeField] TMP_InputField inputZField3;
    [SerializeField] TMP_InputField inputWField3;
    [SerializeField] TextMeshProUGUI resultado;


    #endregion

    #region linerenderer
    public void lineRender() {
        sphere = transform.Find("Sphere");
        sphere.localScale = 0.3f * Vector3.one;
        head = transform.Find("Head");
        head.localScale = 0.25f * Vector3.one;
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
        GetComponent<LineRenderer>().positionCount = 2;
    }
# endregion linerenderer

    #region Llamado a las operaciones
    public void SumarVectores(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        // Llama la función SumarVectores de OperacionesMatematicas
        Vector3 resultadoSuma = operaciones.SumarVectores(v1, v2);
        //    // Mostramos el resultado en un TextMeshPro
        resultado.text = $"Suma: ({resultadoSuma.x}, {resultadoSuma.y}, {resultadoSuma.z})";
    }
    public void RestarVectores(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        Vector3 resultadoResta = operaciones.RestarVectores(v1, v2);
        resultado.text = $"Resta: ({resultadoResta.x}, {resultadoResta.y}, {resultadoResta.z})";
    }
    public void ProductoPunto(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        float resultadoProductoPunto = operaciones.ProductoPunto(v1, v2);
        resultado.text = $"ProductoPunto: ({resultadoProductoPunto})";
    }
    public void ProductoCruz(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        Vector3 resultadoProductoCruz = operaciones.ProductoCruz(v1, v2);
        resultado.text = $"ProductoCruz: ({resultadoProductoCruz.x}, {resultadoProductoCruz.y}, {resultadoProductoCruz.z})";
    }
    public void Magnitud(OperacionesMatematicas operaciones, Vector3 v1) {
        float resultadoMagnitud = operaciones.Magnitud(v1);
        resultado.text = $"ProductoMagnitud: ({resultadoMagnitud})";
    }
    public void Normalizar(OperacionesMatematicas operaciones, Vector3 v1) {
        Vector3 resultadoNormalizar = operaciones.Normalizar(v1);
        resultado.text = $"ProductoNormalizar: ({resultadoNormalizar})";
    }
    public void Transponer(OperacionesMatematicas operaciones) {
        {
            // Crear una matriz de ejemplo
            float[,] matriz = {
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };

            // Llamar al método Transponer
            float[,] resultadoTranspuesta = operaciones.Transponer(matriz);

            // Convertir la matriz transpuesta a un formato adecuado para mostrar
            string resultadoTexto = "";
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    resultadoTexto += resultadoTranspuesta[i, j] + " ";
                }
                resultadoTexto += "\n";  // Salto de línea para cada fila
            }

            // Mostrar el resultado en el TextMeshPro
            resultado.text = $"Matriz Transpuesta:\n{resultadoTexto}";
        }
    }
    public void Determinante3x3(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2, Vector3 v3) {
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
    //checar este porque deberia de hacere igual un calculo del producto punto con mi paralela de su resultado
    public void Descomposicion(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        //Llamamos al método Descomposicion, que devuelve dos vectores
        (Vector3 componenteParalela, Vector3 componenteOrtogonal) = operaciones.Descomposicion(v1, v2);

        // Mostramos ambas componentes en el texto del resultado
        resultado.text = $"Componente Paralela: ({componenteParalela.x}, {componenteParalela.y}, {componenteParalela.z})\n" +
                         $"Componente Ortogonal: ({componenteOrtogonal.x}, {componenteOrtogonal.y}, {componenteOrtogonal.z})";
    }
    //checar este porque deberia de hacere igual un calculo del producto punto
    public void Ortogonalizacion(OperacionesMatematicas operaciones, Vector3 v1) {
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
    public void SumaMatrices(OperacionesMatematicas operaciones, float result1, float result2, float result3, float result4, float result5, float result6, float result7, float result8, float result9) {

        // Crear dos matrices manualmente
        Matrix4x4 m1 = new Matrix4x4();
        Matrix4x4 m2 = new Matrix4x4();

        // Asignar valores a las matrices (puedes hacerlo dinámico con inputs)

        m1.SetRow(0, new Vector4(result1, result2, result3, 0));
        m1.SetRow(1, new Vector4(result4, result5, result6, 0));
        m1.SetRow(2, new Vector4(result7, result8, result9, 0));
        m1.SetRow(3, new Vector4(0, 0, 0, 0)); // Matriz homogénea

        m2.SetRow(0, new Vector4(result1, result2, result3, 0));
        m2.SetRow(1, new Vector4(result4, result5, result6, 0));
        m2.SetRow(2, new Vector4(result7, result8, result9, 0));
        m2.SetRow(3, new Vector4(0, 0, 0, 0)); // Matriz homogénea

        Matrix4x4 resultadoSumarMatrices = operaciones.SumarMatrices(m1, m2);
        resultado.text = "R= suma de matrices:\n";
        for (int i = 0; i < 4; i++) {
            Vector4 fila = resultadoSumarMatrices.GetRow(i);
            resultado.text += $"{fila.x}, {fila.y}, {fila.z}, {fila.w}\n";
        }
    }
    //falta probarla
    public void RestaMatrices(OperacionesMatematicas operaciones) {
        //Definimos las dos matrices de ejemplo
        float[,] matrizA = new float[,] {
            { 5, 7 },
            { 9, 3 }
        };

        float[,] matrizB = new float[,] {
            { 2, 4 },
            { 6, 8 }
        };

        try {
            // Llamamos al método RestarMatrices
            float[,] resultadoResta = operaciones.RestarMatrices(matrizA, matrizB);

            //Mostramos el resultado en el TextMeshPro
            string resultadoTexto = "Resultado de la resta:\n";
            for (int i = 0; i < resultadoResta.GetLength(0); i++) {
                for (int j = 0; j < resultadoResta.GetLength(1); j++) {
                    resultadoTexto += $"{resultadoResta[i, j]} ";
                }
                resultadoTexto += "\n";
            }
            resultado.text = resultadoTexto;
        } catch (InvalidOperationException ex) {
            //En caso de que las matrices no tengan las mismas dimensiones
            resultado.text = ex.Message;
        }
    }
    //pendiente en probarla ;)
    public void MultiplicacionMatrices(OperacionesMatematicas operaciones) {
        // Definimos las dos matrices de ejemplo
        float[,] matrizA = new float[,] {
             { 1, 2 },
             { 3, 4 }
         };

        float[,] matrizB = new float[,] {
            { 5, 6 },
            { 7, 8 }
        };

        try {
            // Llamamos al método MultiplicarMatrices
            float[,] resultadoMultiplicacion = operaciones.MultiplicarMatrices(matrizA, matrizB);

            // Mostramos el resultado en el TextMeshPro
            string resultadoTexto = "Resultado de la multiplicación:\n";
            for (int i = 0; i < resultadoMultiplicacion.GetLength(0); i++) {
                for (int j = 0; j < resultadoMultiplicacion.GetLength(1); j++) {
                    resultadoTexto += $"{resultadoMultiplicacion[i, j]} ";
                }
                resultadoTexto += "\n";
            }
            resultado.text = resultadoTexto;
        } catch (InvalidOperationException ex) {
            // En caso de que las matrices no sean multiplicables
            resultado.text = ex.Message;
        }
    }


    public void AnguloEntreVectores() {

    }
    public void MultiplicarEscalar(OperacionesMatematicas operaciones, Vector3 v1, float escalar) {
        //v = new Vector3(2, 3, 4); // PUEDO CAMBIAR AMBOS DATOS
        Vector3 resultadoMultiplicacionEscalar = operaciones.MultiplicarEscalar(v1, escalar);
        resultado.text = $"Multiplicación por Escalar: ({resultadoMultiplicacionEscalar.x}, {resultadoMultiplicacionEscalar.y}, {resultadoMultiplicacionEscalar.z})";
    }
    public void Reflejar(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        // Definimos un vector y una normal
        //Vector3 v = new Vector3(2, 3, 4);
        //Vector3 n = new Vector3(0, 1, 0);

        Vector3 resultadoReflejo = operaciones.Reflejar(v1, v2);
        resultado.text = $"Reflejo: ({resultadoReflejo.x}, {resultadoReflejo.y}, {resultadoReflejo.z})";
    }
    public void InterseccionLineaPlano(OperacionesMatematicas operaciones, Vector3 puntoLinea, Vector3 direccionLinea, Vector3 puntoPlano, Vector3 normalPlano) {

        Vector3 resultadoInterseccion = operaciones.InterseccionLineaPlano(puntoLinea, direccionLinea, puntoPlano, normalPlano);
        resultado.text = $"IntersecciónLineaPlano: ({resultadoInterseccion.x}, {resultadoInterseccion.y}, {resultadoInterseccion.z})";
    }

    public void DistanciaPuntoPlano(OperacionesMatematicas operaciones) {
        Vector3 punto = new Vector3(1, 2, 3);
        Vector3 puntoPlano = new Vector3(0, 0, 0);
        Vector3 normalPlano = new Vector3(0, 1, 0);

        float resultadoDistancia = operaciones.DistanciaPuntoPlano(punto, puntoPlano, normalPlano);
        resultado.text = $"DistanciaPuntoPlano: {resultadoDistancia}";
    }
    //queda probar
    public void ConvertirAHomogeneas(OperacionesMatematicas operaciones, Vector3 v1) {

        Vector4 vectorHomogeneo = operaciones.ConvertirAHomogeneas(v1);
        resultado.text = $"Vector Homogéneo: ({vectorHomogeneo.x}, {vectorHomogeneo.y}, {vectorHomogeneo.z}, {vectorHomogeneo.w})";
    }
    public void Rotacion2D(OperacionesMatematicas operaciones) {
        float anguloRotation = 0f; // Cambiar este valor por lo que necesito en la operacion :3

        Matrix4x4 resultadoRotacion2D = operaciones.Rotacion2D(anguloRotation);
        resultado.text = $"Matriz de Rotación 2D: {resultadoRotacion2D}";
    }

   /* public void Rotacion3D(OperacionesMatematicas operaciones) {
        Vector3 eje = new Vector3(0, 1, 0);
        float angulo = 45f;

        Matrix4x4 resultadoRotacion3D = operaciones.Rotacion3D(eje, angulo);
        resultado.text = $"Matriz de Rotación 3D:\n{resultadoRotacion3D}";
    }*/
    public void ReflejoEscalar(OperacionesMatematicas operaciones) {
       
    }
    //esta parece que me la da mal
    /*public void TransformacionRotacion(OperacionesMatematicas operaciones) {
        Vector4 vector = new Vector4(1, 0, 0, 1);
        Matrix4x4 matrizRotacion = operaciones.Rotacion3D(new Vector3(0, 0, 0), 90);

        Vector4 resultadoRotacion = operaciones.TransformacionRotacion(vector, matrizRotacion);
        resultado.text = $"Resultado de la TransformacionRotación: ({resultadoRotacion.x}, {resultadoRotacion.y}, {resultadoRotacion.z}, {resultadoRotacion.w})";
    }*/
   
    public void MultiplicarMatrices(OperacionesMatematicas operaciones) {
        
    }
    //si lo tenog activa me aparece este primero en vez de la que solicito
   /* public void InterseccionTresPlanos(OperacionesMatematicas operaciones) {
        // Definimos tres planos como Vectores 4D (Ax + By + Cz + D = 0)
        Vector4 plano1 = new Vector4(1, 0, 0, -5); // Ejemplo de plano 1: x = 5
        Vector4 plano2 = new Vector4(0, 1, 0, -3); // Ejemplo de plano 2: y = 3
        Vector4 plano3 = new Vector4(0, 0, 1, -4); // Ejemplo de plano 3: z = 4

        try {
            // Llamamos al método InterseccionTresPlanos
            Vector3 puntoInterseccion = operaciones.InterseccionTresPlanos(plano1, plano2, plano3);

            // Mostramos el resultado en el TextMeshPro
            resultado.text = $"Punto de intersección 3 Planos: ({puntoInterseccion.x}, {puntoInterseccion.y}, {puntoInterseccion.z})";
        } catch (InvalidOperationException ex) {
            // En caso de que los planos no se crucen en un punto único
            resultado.text = ex.Message;
        }
    }*/
    //parece que funciona pero cuando esta activo el programa se rompe y no sirve otra cosa a excepcion de este
   /* public void InversaMatriz3x3(OperacionesMatematicas operaciones) {
        //Definimos una matriz 3x3 para ejemplo
        float[,] matriz = {
            { 3, -2,  5 },
            { 1,  0,  4 },
            { 2,  3, -1 }
        };

        try {
            // Llamamos al método InversaMatriz3x3
            float[,] inversa = operaciones.InversaMatriz3x3(matriz);

            // Mostramos el resultado en el TextMeshPro
            string resultadoInversa = "InversaMatriz3x3:\n";
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    resultadoInversa += inversa[i, j] + " ";
                }
                resultadoInversa += "\n";
            }
            resultado.text = resultadoInversa;
        } catch (InvalidOperationException ex) {
            // En caso de que la matriz no tenga inversa
            resultado.text = ex.Message;
        }
    }*/

    #endregion Llamado a las operaciones

    #region InputUserField
    private float ParseInputField(TMP_InputField inputField) {
        return float.TryParse(inputField.text, out float value) ? value : 0;
    }
    public void inputUser() {

        float result1 = ParseInputField(inputXField);
        float result2 = ParseInputField(inputYField);
        float result3 = ParseInputField(inputZField);
        float result4 = ParseInputField(inputXField2);
        float result5 = ParseInputField(inputYField2);
        float result6 = ParseInputField(inputZField2);
        float result7 = ParseInputField(inputXField2);//tenia en 2 aquui para abajo y funcionaba
        float result8 = ParseInputField(inputYField2);
        float result9 = ParseInputField(inputZField2);

        Vector3 v1 = new Vector3(result1, result2, result3);
        Vector3 v2 = new Vector3(result4, result5, result6);
        Vector3 v3 = new Vector3(result7, result8, result9);

        float escalar = 0; // para la multiplicacion de matrices debo de modificar este valor por el escalar que quiiero multiplicar
        Vector3 puntoLinea = new Vector3(0, 0, 0), direccionLinea = new Vector3(0, 0, 0), puntoPlano = new Vector3(0, 0, 0), normalPlano = new Vector3(0, 0, 0);

        //SCRIPT IMPORTANTE QUE HEREDA DE CALCULADORA, LAS HABILIDADES DE MI CARTA DE ENCANTAMIENTO AZUL,PAGO 25 MANAS Y LLAMO SI....
        OperacionesMatematicas operaciones = FindObjectOfType<OperacionesMatematicas>();
        if (operaciones != null) {
            SumarVectores(operaciones, v1, v2);
            RestarVectores(operaciones, v1, v2);
            ProductoPunto(operaciones, v1, v2);
            ProductoCruz(operaciones, v1, v2);
            Magnitud(operaciones, v1);
            Normalizar(operaciones, v1);
            Transponer(operaciones);
            Determinante3x3(operaciones, v1, v2, v3);
            Descomposicion(operaciones, v1, v2);
            Ortogonalizacion(operaciones, v1);
            SumaMatrices(operaciones, result1, result2, result3, result4, result5, result6, result7, result8, result9);
            RestaMatrices(operaciones);
            MultiplicacionMatrices(operaciones);
            ConvertirAHomogeneas(operaciones, v1);
            MultiplicarEscalar(operaciones, v1, escalar);
            Reflejar(operaciones, v1, v2);
            InterseccionLineaPlano(operaciones, puntoLinea, direccionLinea, puntoPlano, normalPlano);
            DistanciaPuntoPlano(operaciones);
            Rotacion2D(operaciones);
            //Rotacion3D(operaciones);
           // ReflejoEscalar(operaciones);
            //TransformacionRotacion(operaciones);
           // MultiplicarMatrices(operaciones);
            //InterseccionTresPlanos(operaciones);
            //InversaMatriz3x3(operaciones);
        }
    }
    #endregion InputUserField

    #region Unity Methods
    private void Start() {
        _historialTMP.text = "";
        inputField.onEndEdit.AddListener(ProcesarInputUsuario);
        InitializeUI();
        lineRender();
    }
    #endregion

    #region UI Management
    public void InitializeUI() {
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

    public void MostrarPanel(GameObject panel) {
        panel.SetActive(true);
      
    }

  
    #endregion

    #region Input Processing
    public void ProcesarInputUsuario(string usuarioInput) {
        if (!string.IsNullOrWhiteSpace(usuarioInput)) {
            historialCalculo.Add(usuarioInput);
            ActualizarHistorial();
        }
        inputField.text = "";
        //chat gpt me lo recomienda , es tentativo quedarmelo o no 
        // Opcionalmente, puedes poner el foco de nuevo en el InputField para continuar escribiendo
        inputField.ActivateInputField();
    }

    public void ActualizarHistorial() {
        _historialTMP.text = "\n";
        foreach (var entrada in historialCalculo) {
            _historialTMP.text += entrada + "\n";
        }
    }


    #endregion

    #region Result Display
    public void MostrarResultado(string resultado) {
        historialCalculo.Add("R=" + resultado);
        ActualizarHistorial();
    }
    #endregion
}


