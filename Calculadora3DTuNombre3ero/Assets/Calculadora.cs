using System.Collections;
using System.Collections.Generic;
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
        m_inputField.onEndEdit.AddListener(ProcesamientoLogicoInput);
    }
    void Update() {

    }

    #endregion Funciones Publicas



    #region Funciones Privadas

    /// <summary>
    /// lo que ara principalmente es tomar , analaizar y ejecutar lo que el usuario agrega en el texto 
    /// llamara mi funcion donde se actualizara el historial almacenandolo en otro texto
    ///  y me ayuda a limpiar mi texto de la entrada principal
    /// </summary>
    /// <param name="usuarioInput"></param>
    private void ProcesamientoLogicoInput(string usuarioInput) {
        m_historialCalculoAnteriorTexto.Add(usuarioInput);
        actualizacionHistorialTexto();
        m_inputField.text = "";
    }
    /// <summary>
    /// me ayudara a actualizar el historial en texto en la visualizacion del canvas
    /// </summary>
    private void actualizacionHistorialTexto() {
        _historialTexto.text = "Historial:  \n ";
        foreach (string calculoImprida in m_historialCalculoAnteriorTexto) {
            _historialTexto.text += calculoImprida + "\n";
        }
    }

    #endregion Funciones Privadas
}
