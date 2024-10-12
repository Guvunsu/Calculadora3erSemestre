using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Calculadora : MonoBehaviour {
    #region Variasbles

    [SerializeField] InputField m_inputField;
    [SerializeField] Text _historialTexto;
    List<string> m_historialCalculoAnteriorTexto = new List<string>();

    #endregion Variables

    #region Funciones Publicas

    void Start() {
        _historialTexto.text = "Historial:  \n";
        ///on= InputField , End= EndEditEvent Edit= InputField.onEndEdit {get , set;} me ayudo chatgpt para hacer el inputfield
        //// Agregar el listener para procesar la entrada del usuario
        m_inputField.onEndEdit.AddListener(procesamientoLogicoInput);
    }
    void Update() {

    }

    #region Operaciones Matematicas 

    public Vector3 VectorSuma(Vector3 vectorA, Vector3 vectorB) {
        return vectorA + vectorB;
    }
    public Vector3 VectorResta(Vector3 vectorA, Vector3 vectorB) {
        return vectorA - vectorB;
    }
    public Vector3 MultiplicarPorEscalar(Vector3 vector, float escalar) {
        return vector * escalar;
    }
    public Vector3 ProductoCruz(Vector3 vectorA, Vector3 vectorB) {
        return Vector3.Cross(vectorA, vectorB);
    }
    public float ProductoPunto(Vector3 vectorA, Vector3 vectorB) {
        return Vector3.Dot(vectorA, vectorB);
    }
    public float AnguloEntreVectores(Vector3 vectorA, Vector3 vectorB) {
        return Vector3.Angle(vectorA, vectorB);
    }
    public float Magnitud(Vector3 vector) {
        return vector.magnitude;
    }
    public Vector3 Normalizar(Vector3 vector) {
        return vector.normalized;
    }
    public Vector3 Proyeccion(Vector3 vectorA, Vector3 vectorB) {
        return Vector3.Project(vectorA, vectorB);
    }
    public void Descomposicion(Vector3 vectorA, Vector3 vectorB, out Vector3 componenteParalela, out Vector3 componenteOrtogonal) {
        componenteParalela = Vector3.Project(vectorA, vectorB);
        componenteOrtogonal = vectorA - componenteParalela;
    }
    public Vector3[] OrtogonalizaciónGramSchmidt(Vector3[] vectores) {
        Vector3[] ortogonalizados = new Vector3[vectores.Length];
        ortogonalizados[0] = vectores[0];

        for (int i = 1; i < vectores.Length; i++) {
            ortogonalizados[i] = vectores[i];
            for (int j = 0; j < i; j++) {
                ortogonalizados[i] -= Vector3.Project(ortogonalizados[i], ortogonalizados[j]);
            }
        }

        return ortogonalizados;
    }
    public Matrix4x4 SumarMatrices(Matrix4x4 matrizA, Matrix4x4 matrizB) {
        Matrix4x4 resultado = new Matrix4x4();

        // Sumar cada elemento de la matriz
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                resultado[i, j] = matrizA[i, j] + matrizB[i, j];
            }
        }

        return resultado;
    }
    public Matrix4x4 RestarMatrices(Matrix4x4 matrizA, Matrix4x4 matrizB) {
        Matrix4x4 resultado = new Matrix4x4();

        // Restar cada elemento de la matriz
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                resultado[i, j] = matrizA[i, j] - matrizB[i, j];
            }
        }

        return resultado;
    }
    public Matrix4x4 MultiplicarMatrices(Matrix4x4 matrizA, Matrix4x4 matrizB) {
        return matrizA * matrizB;
    }
    public Matrix4x4 TransponerMatriz(Matrix4x4 matriz) {
        return matriz.transpose;
    }
    public float Determinante3x3(Matrix4x4 matriz) {
        return matriz.m00 * (matriz.m11 * matriz.m22 - matriz.m21 * matriz.m12) -
               matriz.m01 * (matriz.m10 * matriz.m22 - matriz.m20 * matriz.m12) +
               matriz.m02 * (matriz.m10 * matriz.m21 - matriz.m20 * matriz.m11);
    }
    public Matrix4x4 InversaGaussJordan(Matrix4x4 matriz) {
        return matriz.inverse;
    }

    #endregion Operaciones Matematicas

    #endregion Funciones Publicas


    #region Funciones Privadas

    /// <summary>
    /// lo que ara principalmente es tomar , analaizar y ejecutar lo que el usuario agrega en el texto 
    /// llamara mi funcion donde se actualizara el historial almacenandolo en otro texto
    ///  y me ayuda a limpiar mi texto de la entrada principal
    /// </summary>
    /// <param name="usuarioInput"></param>
    void procesamientoLogicoInput(string usuarioInput) {
        m_historialCalculoAnteriorTexto.Add(usuarioInput);
        actualizacionHistorialTexto();
        m_inputField.text = "";
    }

    /// <summary>
    /// me ayudara a actualizar el historial en texto en la visualizacion del canvas
    /// </summary>
    void actualizacionHistorialTexto() {
        _historialTexto.text = "Historial:  \n ";
        foreach (string calculoImprida in m_historialCalculoAnteriorTexto) {
            _historialTexto.text += calculoImprida + "\n";
        }
    }

    /// <summary>
    /// mi funcion para dibujar y colorear mis vectores y su resultado graficamente llamdo igual modo mis funciones matematicas
    /// </summary>
    void OnDrawGizmos() {
        Vector3 vectorA = new Vector3(1, 2, 3);
        Vector3 vectorB = new Vector3(4, 5, 6);

        Vector3 suma = VectorSuma(vectorA, vectorB);
        // me dibuja mis vectores A y B en verde
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, vectorA);
        Gizmos.DrawLine(Vector3.zero, vectorB);
        // el resultado de la suma en azul cyan 
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, suma);

        // Resta de vectores
        Vector3 resta = VectorResta(vectorA, vectorB);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, resta);

        // Multiplicación escalar
        float escalar = 2.0f;
        Vector3 multiplicacionEscalar = MultiplicarPorEscalar(vectorA, escalar);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, multiplicacionEscalar);

        // Producto cruz
        Vector3 productoCruz = ProductoCruz(vectorA, vectorB);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector3.zero, productoCruz);

        // Normalización del vector
        Vector3 vectorNormalizado = Normalizar(vectorA);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, vectorNormalizado);

        // Proyección de un vector sobre otro
        Vector3 proyeccion = Proyeccion(vectorA, vectorB);
        Gizmos.color = Color.gray;
        Gizmos.DrawLine(Vector3.zero, proyeccion);

        // Ortogonalización (Gram-Schmidt) CHATGPT
        Matrix4x4 matrizOriginal = Matrix4x4.identity; // Puedes cambiar los valores por una matriz específica

        // Aplicar la ortogonalización de Gram-Schmidt 
        Matrix4x4 matrizOrtogonalizada = matrizOriginal; // AQUI LE MODIFIQUE PARA NO LLAMR A LA FUNCION 

        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, matrizOrtogonalizada.GetColumn(0)); // Primer vector ortogonalizado
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, matrizOrtogonalizada.GetColumn(1));
        Gizmos.color = Color.gray;
        Gizmos.DrawLine(Vector3.zero, matrizOrtogonalizada.GetColumn(2));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, matrizOrtogonalizada.GetColumn(3)); // ultimo vector ortogonalizado
    }

    #endregion Funciones Privadas
}
