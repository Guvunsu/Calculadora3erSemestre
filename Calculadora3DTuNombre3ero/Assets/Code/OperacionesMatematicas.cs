using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperacionesMatematicas {
    public Calculadora Calculadora;
    #region Operaciones Matem�ticas
    // Suma de vectores

    // hacer un metodo donde me llame estos metodos porque no jala al llamar vectores
    // ponerlo en un gameObject vacio o en un monobehaviour que llame los valores 
    // 
    public Vector3 SumarVectores(Vector3 v1, Vector3 v2) {
        //    vectorA = v1;
        //    vectorB = v2;
        //    Vector3 resultado = v1 + v2;
        //    MostrarResultado(resultado.ToString());
        new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        return v1 + v2; //le agrege esto para que la funcion me jalara
        //MostrarResultado(resultado.ToString());
    }

    // Resta de vectores
    public Vector3 RestarVectores(Vector3 v1, Vector3 v2) {
        /* vectorA = v1;
         vectorB = v2;
         Vector3 resultado = v1 - v2;
         MostrarResultado(resultado.ToString());*/
        new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        return v1 - v2;//mismo caso coin la suma 
    }

    // Producto punto
    public float ProductoPunto(Vector3 v1, Vector3 v2) {
        /* float resultado = Vector3.Dot(v1, v2);
         MostrarResultado(resultado.ToString());*/
        float resultado = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        // MostrarResultado(resultado.ToString());
        return resultado;

    }

    // Producto cruzado
    public Vector3 ProductoCruz(Vector3 v1, Vector3 v2) {
        //vectorA = v1;
        //vectorB = v2;
        //Vector3 resultado = Vector3.Cross(v1, v2);
        //MostrarResultado(resultado.ToString());
        float x = (v1.y * v2.z) - (v1.z * v2.y);
        float y = (v1.z * v2.x) - (v1.x * v2.z);
        float z = (v1.x * v2.y) - (v1.y * v2.x);

        Vector3 resultado = new Vector3(x, y, z);
        // MostrarResultado(resultado.ToString());
        return resultado;
    }

    // Magnitud
    public Vector3 Magnitud(Vector3 v) {
        //float resultado = v.magnitude;
        //MostrarResultado(resultado.ToString());
        float resultado = Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
        //MostrarResultado(resultado.ToString());
        return Vector3.zero;
    }

    // Normalizar un vector
    public Vector3 Normalizar(Vector3 v) {
        //Vector3 resultado = v.normalized;
        //MostrarResultado(resultado.ToString());
        float magnitud = Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
        if (magnitud > 0) {
            Vector3 normalizado = new Vector3(v.x / magnitud, v.y / magnitud, v.z / magnitud);
            // MostrarResultado($"Vector normalizado: {normalizado}");
            return normalizado; // Retorna el vector normalizado
        } else {
            //MostrarResultado("No se puede normalizar un vector de magnitud 0");
            return Vector3.zero; // Devuelve un vector nulo
        }
    }

    // Transponer una matriz (Ejemplo con 2x2) //me la dio chatgpt
    public float[,] Transponer(float[,] matriz) {
        //matrixA = matriz;
        //Matrix4x4 resultado = Matrix4x4.Transpose(matriz);
        //MostrarResultado(resultado.ToString());
        // Crear una nueva matriz 4x4 para la transposici�n
        float[,] transpuesta = new float[4, 4];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                transpuesta[i, j] = matriz[j, i];
            }
        }

        return transpuesta;
    }

    // Determinante de una matriz 3x3
    //public void Determinante(Matrix4x4 matriz) {
    //    //matrixA = matriz;
    //    //float resultado = DeterminanteMatriz3x3(matriz);
    //    //MostrarResultado(resultado.ToString());

    //}
    //determinante de una matriz 3x3
    public float Determinante3x3(float[,] matriz) {
        float determinante = matriz[0, 0] * (matriz[1, 1] * matriz[2, 2] - matriz[1, 2] * matriz[2, 1])
                           - matriz[0, 1] * (matriz[1, 0] * matriz[2, 2] - matriz[1, 2] * matriz[2, 0])
                           + matriz[0, 2] * (matriz[1, 0] * matriz[2, 1] - matriz[1, 1] * matriz[2, 0]);

        return determinante;
    }

    // Descomposici�n de un vector en componentes paralela y ortogonal
    // explicacion chatgpt
    public (Vector3, Vector3) Descomposicion(Vector3 v1, Vector3 v2) {
        // Calculamos el producto punto entre los dos vectores
        float productoPunto = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);

        // Calculamos la magnitud al cuadrado de v2 (para la proyecci�n)
        float magnitud = (v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z);

        // Calculamos la componente paralela utilizando la f�rmula de la proyecci�n
        float escalaParalela = productoPunto / magnitud;
        Vector3 componenteParalela = new Vector3(escalaParalela * v2.x, escalaParalela * v2.y, escalaParalela * v2.z);

        // La componente ortogonal es simplemente la diferencia entre v1 y la componente paralela
        Vector3 componenteOrtogonal = new Vector3(v1.x - componenteParalela.x, v1.y - componenteParalela.y, v1.z - componenteParalela.z);

        // Regresamos las componentes paralela y ortogonal
        return (componenteParalela, componenteOrtogonal);
    }



    // Ortogonalizaci�n de Gram-Schmidt (Ejemplo con un array de vectores)
    public void Ortogonalizacion(Vector3[] vectores) {
        // Implementaci�n de Gram-Schmidt
    }

    // Suma de matrices (Ejemplo con matrices 2x2)
    public Matrix4x4 SumarMatrices(Matrix4x4 m1, Matrix4x4 m2) {

        Matrix4x4 resultado = new Matrix4x4();

        // Sumar elemento por elemento
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                resultado[i, j] = m1[i, j] + m2[i, j];
            }
        }
        //MostrarResultado(resultado.ToString());
        return resultado;
    }




    //agregar paneles y botones 
    //Angulo Entre Vectores :3
    public float AnguloEntreVectores(Vector3 v1, Vector3 v2) {
        // Producto punto
        float productoPunto = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);

        // Magnitudes de los vectores
        float magnitudV1 = Mathf.Sqrt((v1.x * v1.x) + (v1.y * v1.y) + (v1.z * v1.z));
        float magnitudV2 = Mathf.Sqrt((v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z));

        // C�lculo del coseno del �ngulo
        float cosenoAngulo = productoPunto / (magnitudV1 * magnitudV2);

        // Devolvemos el �ngulo en grados
        return Mathf.Acos(cosenoAngulo) * Mathf.Rad2Deg;  // Convertir de radianes a grados
    }

    public Vector3 MultiplicarEscalar(Vector3 v, float escalar) {
        // Multiplicamos cada componente por el escalar
        return new Vector3(v.x * escalar, v.y * escalar, v.z * escalar);
    }

    public Vector3 Reflejar(Vector3 v, Vector3 n) {
        // Calculamos el producto punto entre el vector y la normal del plano
        float productoPunto = (v.x * n.x) + (v.y * n.y) + (v.z * n.z);

        // Reflejo del vector
        return new Vector3(
            v.x - 2 * productoPunto * n.x,
            v.y - 2 * productoPunto * n.y,
            v.z - 2 * productoPunto * n.z
        );
    }
    public Vector3 InterseccionLineaPlano(Vector3 puntoLinea, Vector3 direccionLinea, Vector3 puntoPlano, Vector3 normalPlano) {
        // Calculamos el par�metro t
        float t = ((puntoPlano.x - puntoLinea.x) * normalPlano.x +
                   (puntoPlano.y - puntoLinea.y) * normalPlano.y +
                   (puntoPlano.z - puntoLinea.z) * normalPlano.z) /
                  (direccionLinea.x * normalPlano.x +
                   direccionLinea.y * normalPlano.y +
                   direccionLinea.z * normalPlano.z);

        // Calculamos el punto de intersecci�n
        return new Vector3(
            puntoLinea.x + t * direccionLinea.x,
            puntoLinea.y + t * direccionLinea.y,
            puntoLinea.z + t * direccionLinea.z
        );
    }
    public float DistanciaPuntoPlano(Vector3 punto, Vector3 puntoPlano, Vector3 normalPlano) {
        // Calculamos el producto punto entre la diferencia de puntos y la normal
        float productoPunto = (punto.x - puntoPlano.x) * normalPlano.x +
                              (punto.y - puntoPlano.y) * normalPlano.y +
                              (punto.z - puntoPlano.z) * normalPlano.z;

        // Calculamos la magnitud de la normal
        float magnitudNormal = Mathf.Sqrt((normalPlano.x * normalPlano.x) +
                                          (normalPlano.y * normalPlano.y) +
                                          (normalPlano.z * normalPlano.z));

        // Devolvemos la distancia
        return Mathf.Abs(productoPunto) / magnitudNormal;
    }
    public Matrix4x4 Rotacion2D(float angulo) {
        float radianes = angulo * Mathf.Deg2Rad;
        Matrix4x4 rotacion = new Matrix4x4();

        rotacion[0, 0] = Mathf.Cos(radianes);
        rotacion[0, 1] = -Mathf.Sin(radianes);
        rotacion[1, 0] = Mathf.Sin(radianes);
        rotacion[1, 1] = Mathf.Cos(radianes);
        rotacion[2, 2] = 1;
        rotacion[3, 3] = 1;

        return rotacion;
    }
    public Matrix4x4 Rotacion3D(Vector3 eje, float angulo) {
        float radianes = angulo * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radianes);
        float sin = Mathf.Sin(radianes);
        float oneMinusCos = 1 - cos;

        Matrix4x4 rotacion = new Matrix4x4();

        rotacion[0, 0] = cos + eje.x * eje.x * oneMinusCos;
        rotacion[0, 1] = eje.x * eje.y * oneMinusCos - eje.z * sin;
        rotacion[0, 2] = eje.x * eje.z * oneMinusCos + eje.y * sin;

        rotacion[1, 0] = eje.y * eje.x * oneMinusCos + eje.z * sin;
        rotacion[1, 1] = cos + eje.y * eje.y * oneMinusCos;
        rotacion[1, 2] = eje.y * eje.z * oneMinusCos - eje.x * sin;

        rotacion[2, 0] = eje.z * eje.x * oneMinusCos - eje.y * sin;
        rotacion[2, 1] = eje.z * eje.y * oneMinusCos + eje.x * sin;
        rotacion[2, 2] = cos + eje.z * eje.z * oneMinusCos;

        rotacion[3, 3] = 1;

        return rotacion;
    }
    public Vector4 ConvertirAHomogeneas(Vector3 v) {
        return new Vector4(v.x, v.y, v.z, 1); // Convertir a 4D (x, y, z, w)
    }

    #endregion Operaciones Matem�ticas
}