using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlgebraLineal : MonoBehaviour {

    public TMP_InputField[] inputFields; // Array de input fields din�mico
    public TMP_Text resultText; // Para mostrar el resultado en tiempo real
    public Button addInputFieldButton; // Bot�n para a�adir input fields
    public Button removeInputFieldButton; // Bot�n para eliminar input fields
    public Button[] operationButtons; // Array de botones para cada operaci�n

    private Vector2[] vectors; // Ejemplo para manejar vectores 2D
    private Vector3[] vectors3D; // Ejemplo para manejar vectores 3D
    private Matrix4x4 matrix; // Ejemplo para manejar matrices
    private Color inputColor = Color.yellow; // Color para valores ingresados
    private Color resultColor = Color.green; // Color para el resultado

    #region UI�s y botones

    /// <summary>
    ///  UI�s y botones
    /// </summary>

    void Start() {
        InitializeUI(); // Configura los botones y input fields iniciales
    }

    void InitializeUI() {
        addInputFieldButton.onClick.AddListener(AddInputField);
        removeInputFieldButton.onClick.AddListener(RemoveInputField);

        // Asignar cada bot�n a su funci�n espec�fica
        operationButtons[0].onClick.AddListener(() => VectorAddition());
        operationButtons[1].onClick.AddListener(() => VectorSubtraction());
        operationButtons[2].onClick.AddListener(() => VectorDotProduct());
        operationButtons[2].onClick.AddListener(() => VectorCrossProduct());
        operationButtons[2].onClick.AddListener(() => VectorMagnitude());
        operationButtons[2].onClick.AddListener(() => VectorNormalization());
        operationButtons[2].onClick.AddListener(() => MatrixTranspose());
        operationButtons[2].onClick.AddListener(() => MatrixDeterminant());

    }

    void Update() {
        UpdateInputColors();
    }

    // Funci�n auxiliar para cambiar el color de los input fields en tiempo real
    void UpdateInputColors() {
        foreach (var input in inputFields) {
            input.textComponent.color = inputColor;
        }
    }

    // Funci�n para a�adir un nuevo input field
    void AddInputField() {
        // L�gica para a�adir din�micamente un input field al array
    }

    // Funci�n para eliminar el �ltimo input field
    void RemoveInputField() {
        // L�gica para eliminar din�micamente un input field del array
    }


    // Funci�n para mostrar el resultado en el TextMeshPro y en Gizmos
    void DisplayResult(string result) {
        resultText.text = result;
        resultText.color = resultColor;
    }

    // Ejemplo de funci�n para dibujar con Gizmos el vector resultado
    void OnDrawGizmos() {
        Gizmos.color = resultColor;
        Gizmos.DrawLine(Vector3.zero, new Vector3(1, 1, 0)); // Cambiar seg�n el resultado
    }

    // Agrega funciones adicionales como el Producto Cruz, Magnitud, Normalizaci�n, etc.
    // Cada funci�n puede llamar a `DisplayResult` para mostrar el resultado.
    #endregion UI�s y botones



    #region Matematicas 
    /// <summary>
    /// funciones matematicas 
    /// </summary> 


    // Ejemplo de funci�n para la suma de vectores
    void VectorAddition() {
        Vector2 result = Vector2.zero;
        foreach (var input in inputFields) {
            // Convertir los valores de input field a vector y sumarlos
        }
        DisplayResult(result.ToString("F2"));
    }

    // Ejemplo de funci�n para la resta de vectores
    void VectorSubtraction() {
        Vector2 result = Vector2.zero;
        foreach (var input in inputFields) {
            // Convertir los valores de input field a vector y restarlos
        }
        DisplayResult(result.ToString("F2"));
    }


    void VectorDotProduct() {
        float result = Vector3.Dot(vectors3D[0], vectors3D[1]);
        DisplayResult(result.ToString("F2"));
    }
    void VectorCrossProduct() {
        Vector3 result = Vector3.Cross(vectors3D[0], vectors3D[1]);
        DisplayResult(result.ToString("F2"));
    }
    void VectorMagnitude() {
        float result = vectors[0].magnitude;
        DisplayResult(result.ToString("F2"));
    }

    void VectorNormalization() {
        Vector2 result = vectors[0].normalized;
        DisplayResult(result.ToString("F2"));
    }
    void MatrixTranspose() {
        Matrix4x4 transpose = matrix.transpose;
        DisplayResult(transpose.ToString());
    }

    void MatrixDeterminant() {
        float determinant = matrix.determinant;
        DisplayResult(determinant.ToString("F2"));
    }


    #endregion Matematicas

}


