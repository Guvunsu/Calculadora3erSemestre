using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using JetBrains.Annotations;
using UnityEditor;

public class Calculadora : MonoBehaviour {
    #region Variables
    public OperacionesMatematicas matematicas;

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

    #region Llamado a las operaciones

    // funciona en ui , ocupas 2 paneles xyz
    /* public void SumarVectores(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
         // Llama la función SumarVectores de OperacionesMatematicas
         Vector3 resultadoSuma = operaciones.SumarVectores(v1, v2);
         //    // Mostramos el resultado en un TextMeshPro
         resultado.text = $"Suma: ({resultadoSuma.x}, {resultadoSuma.y}, {resultadoSuma.z})";
     }*/

    // funciona en ui , ocupas 2 paneles xyz
    /*  public void RestarVectores(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
          Vector3 resultadoResta = operaciones.RestarVectores(v1, v2);
          resultado.text = $"Resta: ({resultadoResta.x}, {resultadoResta.y}, {resultadoResta.z})";
      }*/

    //funciona en ui, ocupas 2 paneles xyz
    /* public void ProductoPunto(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
         float resultadoProductoPunto = operaciones.ProductoPunto(v1, v2);
         resultado.text = $"ProductoPunto: ({resultadoProductoPunto})";
     }*/

    // funciona en ui ,ocupas 2 paneles xyz
    /* public void ProductoCruz(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
         Vector3 resultadoProductoCruz = operaciones.ProductoCruz(v1, v2);
         resultado.text = $"ProductoCruz: ({resultadoProductoCruz.x}, {resultadoProductoCruz.y}, {resultadoProductoCruz.z})";
     }*/

    // funciona en ui , ocupas solo el 1er panel
    /* public void Magnitud(OperacionesMatematicas operaciones, Vector3 v1) {
         float resultadoMagnitud = operaciones.Magnitud(v1);
         resultado.text = $"ProductoMagnitud: ({resultadoMagnitud})";
     }*/

    //si funciona en ui solo pon tu magnitud en el 1er panel
    /*public void Normalizar(OperacionesMatematicas operaciones, Vector3 v1) {
        Vector3 resultadoNormalizar = operaciones.Normalizar(v1);
        resultado.text = $"ProductoNormalizar: ({resultadoNormalizar})";
    }*/

    //funciona, hay que modificarla aqui en el metodo la matriz 
    /* public void Transponer(OperacionesMatematicas operaciones) {
         {
             // modificar la matriz para que de :D
             float[,] matriz = {
             {14, 18, 17, 20},
             {1, 0, 14, 120},
             {20, 2, 150, 74},
             {7, 47, 800, 0}
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
     }*/

    //pendiente con posible logro de que funcione
    /*public void Determinante3x3(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2, Vector3 v3) {
        // Crear una matriz 3x3 a partir de los tres vectores queda pendiente
        float[,] matriz = new float[,]
        {
        { v1.x, v1.y, v1.z },
        { v2.x, v2.y, v2.z }, // tal vez deba modificar el valor ahi adentro 
        { v3.x, v3.y, v3.z }
        };

        float resultadoDeterminante3x3 = operaciones.Determinante3x3(matriz);
        resultado.text = $"Determinante de la matriz 3x3: {resultadoDeterminante3x3}";
    }*/

    //funciona en ui el 1era panel imputs field son Punto&Paralela y el 2ndo la Magnitud&Ortogonal 
    /*  public void Descomposicion(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
          //Llamamos al método Descomposicion, que devuelve dos vectores
          (Vector3 componenteParalela, Vector3 componenteOrtogonal) = operaciones.Descomposicion(v1, v2);
          resultado.text = $"Componente Paralela: ({componenteParalela.x}, {componenteParalela.y}, {componenteParalela.z})\n" +
                           $"Componente Ortogonal: ({componenteOrtogonal.x}, {componenteOrtogonal.y}, {componenteOrtogonal.z})";

      }*/

    //funciona en ui primer panel de inputfileds para el 1er vector xyz el 2ndo es un vector ortogonal
    /*  public void Ortogonalizacion(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
          Vector3[] vectores = new Vector3[] { v1, v2 };  // Dos vectores a ortogonalizar

          // Llamamos al método Ortogonalizacion
          List<Vector3> resultadoOrtogonalizacion = operaciones.Ortogonalizacion(vectores);
          string resultadoTexto = "Vectores Ortogonales: \n";
          foreach (Vector3 v in resultadoOrtogonalizacion) {
              resultadoTexto += $"({v.x}, {v.y}, {v.z})\n";
          }

          resultado.text = resultadoTexto;  // Mostramos el resultado final
      }*/

    //funciona parece ser , en ui solo 1 panel xyz
    /*  public void ConvertirAHomogeneas(OperacionesMatematicas operaciones, Vector3 v1) {

          Vector4 vectorHomogeneo = operaciones.ConvertirAHomogeneas(v1);
          resultado.text = $"Vector Homogéneo: ({vectorHomogeneo.x}, {vectorHomogeneo.y}, {vectorHomogeneo.z}, {vectorHomogeneo.w})";
      }*/

    //probarla de nuevo 
    /*  public void SumaMatrices(OperacionesMatematicas operaciones, float result1, float result2, float result3, float result4, float result5, float result6, float result7, float result8, float result9) {

          // Crear dos matrices manualmente
          Matrix4x4 m1 = new Matrix4x4();
          Matrix4x4 m2 = new Matrix4x4();

          // Asignar valores a las matrices (puedes hacerlo dinámico con inputs)
         //pero modificando aqui eh 

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
      }*/

    //funciona, solo hya una ligera muy ligera variacion en decimales 
    /* public void AnguloEntreVectores(OperacionesMatematicas operaciones, Vector3 v1, Vector3 v2) {
        // hacer el producto punto de v1 y v2
         v1 = new Vector3(90, 787, 10);
         v2 = new Vector3(49, 242, 222);

         float angulo = operaciones.AnguloEntreVectores(v1, v2);
         resultado.text = $"Ángulo entre los vectores: ({angulo}, {angulo}, {angulo})";
     }*/

    //funciona ,modificar las matrices con los datos , solo funciona 2x2,querres el 3x3 , agrega una matrizC (queda pendiendte el for)
    /* public void RestaMatrices(OperacionesMatematicas operaciones) {
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
     }*/

    public void RestaMatrices3x3() {
        
    }

    //funciona pero uno le debe de modificar manualmente desde aqui 
    /* public void MultiplicacionMatrices(OperacionesMatematicas operaciones) {
         // Definimos las dos matrices de ejemplo para un 2x2, solo sirve para ese tipo de multiplicacion
         float[,] matrizA = new float[,] {
              { 24, 70},
              { 3, 4 }
          };

         float[,] matrizB = new float[,] {
             { 75, 10 },
             { 52, 39 }
         };

         try {
             // Llamamos al método MultiplicarMatrices
             float[,] resultadoMultiplicacionMatrices = operaciones.MultiplicarMatrices(matrizA, matrizB);

             // Mostramos el resultado en el TextMeshPro
             string resultadoTexto = "Resultado de la multiplicaciónMatrices:\n";
             for (int i = 0; i < resultadoMultiplicacionMatrices.GetLength(0); i++) {
                 for (int j = 0; j < resultadoMultiplicacionMatrices.GetLength(1); j++) {
                     resultadoTexto += $"{resultadoMultiplicacionMatrices[i, j]} ";
                 }
                 resultadoTexto += "\n";
             }
             resultado.text = resultadoTexto;
         } catch (InvalidOperationException ex) {
             // En caso de que las matrices no sean multiplicables
             resultado.text = ex.Message;
         }
     }*/

    //Funciona, ligera incremento en la X pero los dema sis dan en el blanco, hay que modiciar desde aqui el vector y el escalar
    /* public void MultiplicarEscalar(OperacionesMatematicas operaciones, Vector3 v1, float escalar) {
          v1 = new Vector3(210, 312, -4); // PUEDO CAMBIAR AMBOS DATOS
          escalar = 95;
          Vector3 resultadoMultiplicacionEscalar = operaciones.MultiplicarEscalar(v1, escalar);
          resultado.text = $"Multiplicación por Escalar: ({resultadoMultiplicacionEscalar.x}, {resultadoMultiplicacionEscalar.y}, {resultadoMultiplicacionEscalar.z})";
      }*/

    //funciona, modificar aqui
    /* public void Reflejar(OperacionesMatematicas operaciones) {
         //Definimos v= vector y n=normal
         Vector3 v = new Vector3(151, 1545, 157);
         Vector3 n = new Vector3(458, 103, 19);

         Vector3 resultadoReflejo = operaciones.Reflejar(v, n);
         resultado.text = $"Reflejo: ({resultadoReflejo.x}, {resultadoReflejo.y}, {resultadoReflejo.z})";
     }*/

    //Funciona, pero puede ser inesacta en numeros altos y si es en linea y punto , se dara a si misma
    /*public void InterseccionLineaPlano(OperacionesMatematicas operaciones) {
        Vector3 puntoLinea = new Vector3(1545, 15786, 15453);
        Vector3 direccionLinea = new Vector3(454, 12, 103);
        Vector3 puntoPlano = new Vector3(152, 155, 158);
        Vector3 normalPlano = new Vector3(459, 178, 10);

        Vector3 resultadoInterseccion = operaciones.InterseccionLineaPlano(puntoLinea, direccionLinea, puntoPlano, normalPlano);
        resultado.text = $"IntersecciónLineaPlano: ({resultadoInterseccion.x}, {resultadoInterseccion.y}, {resultadoInterseccion.z})";
    }*/

    //fuciona,modificar desde aqui los parametros
    /* public void DistanciaPuntoPlano(OperacionesMatematicas operaciones) {
         Vector3 punto = new Vector3(1, 2, 3);
         Vector3 puntoPlano = new Vector3(0, 0, 0);
         Vector3 normalPlano = new Vector3(0, 1, 0);

         float resultadoDistancia = operaciones.DistanciaPuntoPlano(punto, puntoPlano, normalPlano);
         resultado.text = $"DistanciaPuntoPlano: {resultadoDistancia}";
     }*/

    //funciona, pero aqui deberas modificar ek angulo de rotacion y en el otro script los vectores para que de seno y coseno 
    /*  public void Rotacion2D(OperacionesMatematicas operaciones) {
           float anguloRotation = 105f; // Cambiar este valor por lo que necesito en la operacion :3

           Matrix4x4 resultadoRotacion2D = operaciones.Rotacion2D(anguloRotation);
           resultado.text = $"Matriz de Rotación 2D: {resultadoRotacion2D}";
       }*/

    //funciona mas o menos, tiene un detalle que no lo hace perfecta
    /*  public void Rotacion3D(OperacionesMatematicas operaciones) {
          Vector3 eje = new Vector3(124, 10, 890);
          float angulo = 45f;

          Matrix4x4 resultadoRotacion3D = operaciones.Rotacion3D(eje, angulo);
          resultado.text = $"Matriz de Rotación 3D:\n{resultadoRotacion3D}";
      }*/

    //no entiendo como arreglarlo
    /*  public void ReflejoEscalar(OperacionesMatematicas operaciones) {
          Vector3 vector = new Vector3(1, 2, 3);  // Puedes cambiar este vector
          float escalar = 2f;  // Puedes cambiar este valor también

          Vector3 resultadoReflejo = operaciones.ReflejoEscalar(vector, escalar);
          string vectorOriginal = $"({vector.x}, {vector.y}, {vector.z})";
          string resultado = $"({resultadoReflejo.x}, {resultadoReflejo.y}, {resultadoReflejo.z})";
          string resultadoString = $"Reflejo escalar del vector {vectorOriginal} por el escalar {escalar} es: {resultado}";
          resultado.text = resultadoString;
      }*/

    //funciona pero cuando le preguntaba al ChatGpt en fase de pruebas de resultados, no podia , pero tengo fe que funciona
    /*public void TransformacionRotacion(OperacionesMatematicas operaciones) {
        Vector4 vector = new Vector4(1, 10, 20, 1);
        Matrix4x4 matrizRotacion = operaciones.Rotacion3D(new Vector3(0, 0, 0), 90);

        Vector4 resultadoRotacion = operaciones.TransformacionRotacion(vector, matrizRotacion);
        resultado.text = $"Resultado de la TransformacionRotación: ({resultadoRotacion.x}, {resultadoRotacion.y}, {resultadoRotacion.z}, {resultadoRotacion.w})";
    }*/
    //Funciona, hay que modifcar ambas matrices e ingresar o
    /* public void MultiplicarMatrices(OperacionesMatematicas operaciones) {

         float[,] matrizA = new float[,] {
             { 1, 2, 3 },
             { 4, 5, 6 }
         };

         float[,] matrizB = new float[,] {
             { 7, 8 },
             { 9, 10 },
             { 11, 12 }
         };

         float[,] resultadoMultiMatrices = operaciones.MultiplicarMatrices(matrizA, matrizB);
         string resultadoString = $"la multiplicación de matrices:\n";
         // Recorrer la matriz resultado y añadir sus elementos a la cadena
         for (int i = 0; i < resultadoMultiMatrices.GetLength(0); i++) {
             for (int j = 0; j < resultadoMultiMatrices.GetLength(1); j++) {
                 resultadoString += resultadoMultiMatrices[i, j] + " ";
             }
             resultadoString += "\n";
         }
         resultado.text = resultadoString;
     }*/

    //funciona, desde aqui se debe de modificar e ingresar los datos que quieras calcular
    /*  public void InterseccionTresPlanos(OperacionesMatematicas operaciones) {
          // Definimos tres planos como Vectores 4D (Ax + By + Cz + D = 0)
          Vector4 plano1 = new Vector4(100, 74, 0, -5147);
          Vector4 plano2 = new Vector4(1000, 561, 0, -39); 
          Vector4 plano3 = new Vector4(80, 104, 123, -478); 

         //chatpgt //sirve para que si donde llamamos el Intereseccion ocurre un problema me ejecute el siguiente y me lo guarde lo intenre corregir y me lance un mensaje
          try {
              Vector3 puntoInterseccion = operaciones.InterseccionTresPlanos(plano1, plano2, plano3);
              resultado.text = $"Punto de intersección 3 Planos: ({puntoInterseccion.x}, {puntoInterseccion.y}, {puntoInterseccion.z})";
          } catch (InvalidOperationException ex) {
              // En caso de que los planos no se crucen en un punto único
              resultado.text = ex.Message;
          }
      }1*/

    //funciona, pero es inexacta, aqui se manipula la matriz para obtener el resutado al cacular en In Game :3
    /*  public void InversaMatriz3x3(OperacionesMatematicas operaciones) {
           //Definimos una matriz 3x3 para ejemplo
           float[,] matriz = {
               { 10, -4,  25 },
               { 12,  -90,  44 },
               { 200,  30, -10 }
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
        float result7 = ParseInputField(inputXField2);//tenia en 3 aqui para abajo y NO funcionaba,pero jala
        float result8 = ParseInputField(inputYField2);
        float result9 = ParseInputField(inputZField2);

        Vector3 v1 = new Vector3(result1, result2, result3);
        Vector3 v2 = new Vector3(result4, result5, result6);
        Vector3 v3 = new Vector3(result7, result8, result9);

        //ACTIVAR ESTAS SI ES NECESARIO 
        float escalar = 0; // para la multiplicacion de matrices debo de modificar este valor por el escalar que quiiero multiplicar


        //ACTIVAR SI ACTIVAS EL METODO DE LA OPERACION QUE HEREDA 
        //DE CALCULADORA, LAS HABILIDADES DE MI CARTA DE ENCANTAMIENTO AZUL,PAGO 25 MANAS Y LLAMO A....
        OperacionesMatematicas operaciones = FindObjectOfType<OperacionesMatematicas>();
        if (operaciones != null) {
            // SumarVectores(operaciones, v1, v2);
            // RestarVectores(operaciones, v1, v2);
            //ProductoPunto(operaciones, v1, v2);
            //ProductoCruz(operaciones, v1, v2);
            // Magnitud(operaciones, v1);
            // Normalizar(operaciones, v1);
            // Transponer(operaciones);
            //Determinante3x3(operaciones, v1, v2, v3);
            // Descomposicion(operaciones, v1, v2);
            //Ortogonalizacion(operaciones, v1,v2);
            //ConvertirAHomogeneas(operaciones, v1);
            // SumaMatrices(operaciones, result1, result2, result3, result4, result5, result6, result7, result8, result9);
            //AnguloEntreVectores(operaciones, v1, v2);
            //RestaMatrices(operaciones);
            //MultiplicarMatrices(operaciones);
            //MultiplicarEscalar(operaciones, v1, escalar);
            //Reflejar(operaciones);
            // InterseccionLineaPlano(operaciones);
            // DistanciaPuntoPlano(operaciones);
            // Rotacion2D(operaciones);
            //Rotacion3D(operaciones);
            // ReflejoEscalar(operaciones);
            // TransformacionRotacion(operaciones);
            // MultiplicarMatrices(operaciones);
            //InterseccionTresPlanos(operaciones);
            //InversaMatriz3x3(operaciones);
        }
    }
    #endregion InputUserField

    #region Unity Methods
    private void Start() {
        _historialTMP.text = "R=";
        inputField.onEndEdit.AddListener(ProcesarInputUsuario);
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


