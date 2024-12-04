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
    [SerializeField] TMP_InputField inputXField2;
    [SerializeField] TMP_InputField inputYField2;
    [SerializeField] TMP_InputField inputZField2;
    [SerializeField] TextMeshProUGUI resultado;
    //[SerializeField] TextMeshProUGUI resultados;
    //[SerializeField] TMP_InputField inputFieldRestaVectores;
    //[SerializeField] TMP_InputField inputXFieldRestaVectores;
    //[SerializeField] TMP_InputField inputYFieldRestaVectores;
    //[SerializeField] TMP_InputField inputZFieldRestaVectores;
    //[SerializeField] TMP_InputField inputXField2RestaVectores;
    //[SerializeField] TMP_InputField inputYField2RestaVectores;
    //[SerializeField] TMP_InputField inputZField2RestaVectores;

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
        //SCRIPT IMPORTANTE QUE HEREDA DE CALCULADORA LAS HABILIDADES DE MI CARTA DE INSTANT....
        OperacionesMatematicas operaciones = FindObjectOfType<OperacionesMatematicas>();

        if (operaciones != null) {
            // Llama la función SumarVectores de OperacionesMatematicas
            Vector3 resultadoSuma = operaciones.SumarVectores(v1, v2);
            // Mostramos el resultado en un TextMeshPro
            resultado.text = $"Suma: ({resultadoSuma.x}, {resultadoSuma.y}, {resultadoSuma.z})";

            //agregar a las demas, solo hay que lograr que funcione este primero 
        }
        if (operaciones != null) {
            Vector3 resultadoResta = operaciones.RestarVectores(v1, v2);
            resultado.text = $"Resta: ({resultadoResta.x}, {resultadoResta.y}, {resultadoResta.z})";
        }
        if (operaciones != null) {
            float resultadoProductoPunto = operaciones.ProductoPunto(v1, v2);
            resultado.text = $"ProductoPunto: ({resultadoProductoPunto})";
        }
        if (operaciones != null) {
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
        if (operaciones != null) {
            // Crear dos matrices manualmente
            Matrix4x4 m1 = new Matrix4x4();
            Matrix4x4 m2 = new Matrix4x4();

            // Asignar valores a las matrices (puedes hacerlo dinámico con inputs)
            m1.SetRow(0, new Vector4(result1, result2, result3, 0));
            m1.SetRow(1, new Vector4(result4, result5, result6, 0));
            m1.SetRow(2, new Vector4(result7, result8, result9, 0));
            m1.SetRow(3, new Vector4(0, 0, 0, 1)); // Matriz homogénea

            m2.SetRow(0, new Vector4(1, 2, 3, 0));
            m2.SetRow(1, new Vector4(4, 5, 6, 0));
            m2.SetRow(2, new Vector4(7, 8, 9, 0));
            m2.SetRow(3, new Vector4(0, 0, 0, 1));

            // Sumar matrices
            Matrix4x4 resultadoSumarMatrices = operaciones.SumarMatrices(m1, m2);

            // Mostrar el resultado
            resultado.text = "Resultado de la suma de matrices:\n";
            for (int i = 0; i < 4; i++) {
                Vector4 fila = resultadoSumarMatrices.GetRow(i);
                resultado.text += $"{fila.x}, {fila.y}, {fila.z}, {fila.w}\n";
            }
        }
        if (operaciones != null) {
            //Vector3? v11 = new Vector3(1, 0, 0);
            //Vector3? v22 = new Vector3(0, 1, 0);

            float resultadoAngulo = operaciones.AnguloEntreVectores(v1, v2);

            if (float.IsNaN(resultadoAngulo)) {
                //resultado.text = $"ProductoAngulo: ({resultadoAngulo})";
                resultado.text = "Error: No se puede calcular el ángulo entre los vectores.";
            } else {
                resultado.text = $"Ángulo entre vectores: {resultadoAngulo}°";
            }
        }
        // hasta aqui de chat gpt
        if (operaciones != null) {
            Vector3 v = new Vector3(2, 3, 4); // PUEDO CAMBIAR AMBOS DATOS
            float escalar = 5;

            Vector3 resultadoMultiplicacionEscalar = operaciones.MultiplicarEscalar(v, escalar);
            resultado.text = $"Multiplicación por Escalar: ({resultadoMultiplicacionEscalar.x}, {resultadoMultiplicacionEscalar.y}, {resultadoMultiplicacionEscalar.z})";
        }
        if (operaciones != null) {
            // Definimos un vector y una normal
            Vector3 v = new Vector3(2, 3, 4);
            Vector3 n = new Vector3(0, 1, 0);

            Vector3 resultadoReflejo = operaciones.Reflejar(v, n);
            resultado.text = $"Reflejo: ({resultadoReflejo.x}, {resultadoReflejo.y}, {resultadoReflejo.z})";
        }
        if (operaciones != null) {
            Vector3 puntoLinea = new Vector3(1, 2, 3);
            Vector3 direccionLinea = new Vector3(4, 5, 6);
            Vector3 puntoPlano = new Vector3(0, 0, 0);
            Vector3 normalPlano = new Vector3(0, 1, 0);

            Vector3 resultadoInterseccion = operaciones.InterseccionLineaPlano(puntoLinea, direccionLinea, puntoPlano, normalPlano);
            resultado.text = $"IntersecciónLineaPlano: ({resultadoInterseccion.x}, {resultadoInterseccion.y}, {resultadoInterseccion.z})";
        }

        if (operaciones != null) {
            Vector3 punto = new Vector3(1, 2, 3);
            Vector3 puntoPlano = new Vector3(0, 0, 0);
            Vector3 normalPlano = new Vector3(0, 1, 0);

            float resultadoDistancia = operaciones.DistanciaPuntoPlano(punto, puntoPlano, normalPlano);
            resultado.text = $"DistanciaPuntoPlano: {resultadoDistancia}";
        }
        if (operaciones != null) {

            float anguloRotation = 45f; // Cambiar este valor por el angulo que necesito en la operacion :3

            Matrix4x4 resultadoRotacion2D = operaciones.Rotacion2D(anguloRotation);
            resultado.text = $"Matriz de Rotación 2D: {resultadoRotacion2D}";
        }
        if (operaciones != null) {

            Vector3 eje = new Vector3(0, 1, 0);
            float angulo = 45f;

            Matrix4x4 resultadoRotacion3D = operaciones.Rotacion3D(eje, angulo);
            resultado.text = $"Matriz de Rotación 3D:\n{resultadoRotacion3D}";
        }
        if (operaciones != null) {
            Vector3 v = new Vector3(1, 2, 3);

            Vector4 resultadoHomogeneo = operaciones.ConvertirAHomogeneas(v);
            resultado.text = $"Vector de Convertir a Homogéneas Unga Unga: ({resultadoHomogeneo.x}, {resultadoHomogeneo.y}, {resultadoHomogeneo.z}, {resultadoHomogeneo.w})";
        }
        if (operaciones != null) {
            //el valor sera para al que deseo reflejar y referencia con la que se reflejara
            float valor = 3.5f;
            float referencia = 5.0f;

            float resultadoReflejo = operaciones.ReflejoEscalar(valor, referencia);
            resultado.text = $"Reflejo Escalar: ({resultadoReflejo})";
        }
        if (operaciones != null) {
            Vector4 vector = new Vector4(1, 0, 0, 1);
            Matrix4x4 matrizRotacion = operaciones.Rotacion3D(new Vector3(0, 0, 0), 90);

            Vector4 resultadoRotacion = operaciones.TransformacionRotacion(vector, matrizRotacion);
            resultado.text = $"Resultado de la TransformacionRotaciónUngaUnga: ({resultadoRotacion.x}, {resultadoRotacion.y}, {resultadoRotacion.z}, {resultadoRotacion.w})";
        }//chatgpt la siguiente x_x
         //    if (operaciones != null) {
         //        Definimos las dos matrices de ejemplo
         //        float[,] matrizA = new float[,] {
         //    { 1, 2 },
         //    { 3, 4 }
         //};

        //        float[,] matrizB = new float[,] {
        //    { 5, 6 },
        //    { 7, 8 }
        //};

        //        try {
        //            Llamamos al método MultiplicarMatrices
        //            float[,] resultadoMultiplicacion = operaciones.MultiplicarMatrices(matrizA, matrizB);

        //            Mostramos el resultado en el TextMeshPro
        //            string resultadoTexto = "Resultado de la multiplicación:\n";
        //            for (int i = 0; i < resultadoMultiplicacion.GetLength(0); i++) {
        //                for (int j = 0; j < resultadoMultiplicacion.GetLength(1); j++) {
        //                    resultadoTexto += $"{resultadoMultiplicacion[i, j]} ";
        //                }
        //                resultadoTexto += "\n";
        //            }
        //            resultado.text = resultadoTexto;
        //        } catch (InvalidOperationException ex) {
        //            En caso de que las matrices no sean multiplicables
        //            resultado.text = ex.Message;
        //        }
        //    }
        //    if (operaciones != null) {
        //        Definimos las dos matrices de ejemplo
        //        float[,] matrizA = new float[,] {
        //    { 5, 7 },
        //    { 9, 3 }
        //};

        //        float[,] matrizB = new float[,] {
        //    { 2, 4 },
        //    { 6, 8 }
        //};

        //        try {
        //            Llamamos al método RestarMatrices
        //            float[,] resultadoResta = operaciones.RestarMatrices(matrizA, matrizB);

        //            Mostramos el resultado en el TextMeshPro
        //            string resultadoTexto = "Resultado de la resta:\n";
        //            for (int i = 0; i < resultadoResta.GetLength(0); i++) {
        //                for (int j = 0; j < resultadoResta.GetLength(1); j++) {
        //                    resultadoTexto += $"{resultadoResta[i, j]} ";
        //                }
        //                resultadoTexto += "\n";
        //            }
        //            resultado.text = resultadoTexto;
        //        } catch (InvalidOperationException ex) {
        //            En caso de que las matrices no tengan las mismas dimensiones
        //            resultado.text = ex.Message;
        //        }
        //    }
        //    if (operaciones != null) {
        //        // Definimos tres planos como Vectores 4D (Ax + By + Cz + D = 0)
        //        Vector4 plano1 = new Vector4(1, 0, 0, -5); // Ejemplo de plano 1: x = 5
        //        Vector4 plano2 = new Vector4(0, 1, 0, -3); // Ejemplo de plano 2: y = 3
        //        Vector4 plano3 = new Vector4(0, 0, 1, -4); // Ejemplo de plano 3: z = 4

        //        try {
        //            // Llamamos al método InterseccionTresPlanos
        //            Vector3 puntoInterseccion = operaciones.InterseccionTresPlanos(plano1, plano2, plano3);

        //            // Mostramos el resultado en el TextMeshPro
        //            resultado.text = $"Punto de intersección 3 Planos: ({puntoInterseccion.x}, {puntoInterseccion.y}, {puntoInterseccion.z})";
        //        } catch (InvalidOperationException ex) {
        //            // En caso de que los planos no se crucen en un punto único
        //            resultado.text = ex.Message;
        //        }
        //    }
        //    if (operaciones != null) {
        //        Definimos una matriz 3x3 para ejemplo
        //        float[,] matriz = {
        //    { 3, -2,  5 },
        //    { 1,  0,  4 },
        //    { 2,  3, -1 }
        //};

        //        try {
        //            // Llamamos al método InversaMatriz3x3
        //            float[,] inversa = operaciones.InversaMatriz3x3(matriz);

        //            // Mostramos el resultado en el TextMeshPro
        //            string resultadoInversa = "InversaMatriz3x3:\n";
        //            for (int i = 0; i < 3; i++) {
        //                for (int j = 0; j < 3; j++) {
        //                    resultadoInversa += inversa[i, j] + " ";
        //                }
        //                resultadoInversa += "\n";
        //            }
        //            resultado.text = resultadoInversa;
        //        } catch (InvalidOperationException ex) {
        //            // En caso de que la matriz no tenga inversa
        //            resultado.text = ex.Message;
        //        }
        //    }
        //    hasta aquix2


        ////     lo otro no funciona pero no afecat si esta o no esta comentado , despues de esto hay mas codigo funcional, mas o menos


        //    //llamo a las acciones especificas segun el tipo de operacion y si inputfield es normalizar,llamo ese panel
        //    if (userInput.Equals("SumaVectores", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelSumaVectores);
        //    } else if (userInput.Equals("RestarVectores", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelRestarVectores);
        //    } else if (userInput.Equals("ProductoPunto", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelProductoPunto);
        //    } else if (userInput.Equals("ProductoCruz", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelProductoCruz);
        //    } else if (userInput.Equals("Magnitud", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelMagnitud);
        //    } else if (userInput.Equals("Normalizar", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelNormalizar);
        //    } else if (userInput.Equals("Transponer", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelTransponer);
        //    } else if (userInput.Equals("Determinante3x3", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelDeterminante3x3);
        //    } else if (userInput.Equals("Descomposicion", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelDescomposicion);
        //    } else if (userInput.Equals("Ortogonalizacion", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelOrtogonalizacion);
        //    } else if (userInput.Equals("SumarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelSumarMatrices);
        //    } else if (userInput.Equals("AnguloEntreVectores", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelAnguloEntreVectores);
        //    } else if (userInput.Equals("MultiplicarEscalar", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelMultiplicarEscalar);
        //    } else if (userInput.Equals("Reflejar", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelReflejar);
        //    } else if (userInput.Equals("InterseccionLineaPlano", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelInterseccionLineaPlano);
        //    } else if (userInput.Equals("DistanciaPuntoPlano", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelDistanciaPuntoPlano);
        //    } else if (userInput.Equals("Rotacion2D", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelRotacion2D);
        //    } else if (userInput.Equals("Rotacion3D", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelRotacion3D);
        //    } else if (userInput.Equals("ConvertirAHomogeneas", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelConvertirAHomogeneas);
        //    } else if (userInput.Equals("ReflejoEscalar", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelReflejoEscalar);
        //    } else if (userInput.Equals("TransformacionRotacion", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelTransformacionRotacion);
        //    } else if (userInput.Equals("MultiplicarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelMultiplicarMatrices);
        //    } else if (userInput.Equals("RestarMatrices", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelRestarMatrices);
        //    } else if (userInput.Equals("InterseccionTresPlanos", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelInterseccionTresPlanos);
        //    } else if (userInput.Equals("InversaMatriz3x3", System.StringComparison.OrdinalIgnoreCase)) {
        //        MostrarPanel(panelInversaMatriz3x3);
        //    } else {
        //        // Si el input no coincide con ninguna operación, muestra un mensaje.
        //        resultados.text = "Operación no reconocida.";
        //    }
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
        OcultarTodosLosPaneles();
        panel.SetActive(true);
    }

    public void OcultarTodosLosPaneles() {
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


