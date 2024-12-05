using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperacionesMatematicas : MonoBehaviour {
    public Calculadora Calculadora;
    #region Operaciones Matemáticas
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
    public float Magnitud(Vector3 v) {
        //float resultado = v.magnitude;
        //MostrarResultado(resultado.ToString());
        float resultado = Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
        //MostrarResultado(resultado.ToString());
        return resultado; //chatgpt me reocmienda que me regrese un float que un vector3
    }
    // Normalizar un vector
    public Vector3 Normalizar(Vector3 v) {
        //Vector3 resultado = v.normalized;
        //MostrarResultado(resultado.ToString());
        float magnitud = Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
        if (magnitud > 0) {
            Vector3 normalizado = new Vector3(v.x / magnitud, v.y / magnitud, v.z / magnitud);
            return normalizado; // Retorna el vector normalizado
        } else {
            return Vector3.zero; // Devuelve un vector nulo
        }
    }
    // Transponer una matriz (Ejemplo con 2x2) //me la dio chatgpt
    public float[,] Transponer(float[,] matriz) {
        //matrixA = matriz;
        //Matrix4x4 resultado = Matrix4x4.Transpose(matriz);
        //MostrarResultado(resultado.ToString());
        // Crear una nueva matriz 4x4 para la transposición
        float[,] transpuesta = new float[4, 4];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                transpuesta[i, j] = matriz[j, i];
            }
        }

        return transpuesta;
    }
    public float Determinante3x3(float[,] matriz) {
        float determinante = matriz[0, 0] * (matriz[1, 1] * matriz[2, 2] - matriz[1, 2] * matriz[2, 1])
                           - matriz[0, 1] * (matriz[1, 0] * matriz[2, 2] - matriz[1, 2] * matriz[2, 0])
                           + matriz[0, 2] * (matriz[1, 0] * matriz[2, 1] - matriz[1, 1] * matriz[2, 0]);

        return determinante;
    }
    // Descomposición de un vector en componentes paralela y ortogonal
    // explicacion chatgpt
    public (Vector3, Vector3) Descomposicion(Vector3 v1, Vector3 v2) {
        // Calculamos el producto punto entre los dos vectores
        float productoPunto = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);

        // Calculamos la magnitud al cuadrado de v2 (para la proyección)
        float magnitud = (v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z);

        // Calculamos la componente paralela utilizando la fórmula de la proyección
        float escalaParalela = productoPunto / magnitud;
        Vector3 componenteParalela = new Vector3(escalaParalela * v2.x, escalaParalela * v2.y, escalaParalela * v2.z);

        // La componente ortogonal es simplemente la diferencia entre v1 y la componente paralela
        Vector3 componenteOrtogonal = new Vector3(v1.x - componenteParalela.x, v1.y - componenteParalela.y, v1.z - componenteParalela.z);

        // Regresamos las componentes paralela y ortogonal
        return (componenteParalela, componenteOrtogonal);
    }
    //No le se joven, por eso no la hice, a ver si me acuerdo mientras hago ajustes 
    //chatgpt al chile esas esstan cabronas
    // Implementación de Gram-Schmidt
    public List<Vector3> Ortogonalizacion(Vector3[] vectores) {

        // Asumimos que el arreglo de vectores tiene al menos 2 vectores
        // Si tienes más vectores, puedes extender el proceso.

        // El primer vector ortogonal es simplemente el primer vector
        Vector3 u1 = vectores[0];

        // Creamos una lista para almacenar los vectores ortogonales resultantes
        List<Vector3> ortogonales = new List<Vector3>();
        ortogonales.Add(u1); // Agregamos el primer vector ortogonal

        // Aplicamos el proceso de Gram-Schmidt a los vectores restantes
        for (int i = 1; i < vectores.Length; i++) {
            // Tomamos el siguiente vector v[i]
            Vector3 v = vectores[i];

            // Proyección de v sobre el vector u1
            float productoPunto = (v.x * u1.x) + (v.y * u1.y) + (v.z * u1.z);
            float magnitudU1Cuadrado = (u1.x * u1.x) + (u1.y * u1.y) + (u1.z * u1.z);
            Vector3 proyeccionSobreU1 = new Vector3((productoPunto / magnitudU1Cuadrado) * u1.x,
                                                     (productoPunto / magnitudU1Cuadrado) * u1.y,
                                                     (productoPunto / magnitudU1Cuadrado) * u1.z);

            // El siguiente vector ortogonal es el vector v menos la proyección sobre u1
            Vector3 u2 = new Vector3(v.x - proyeccionSobreU1.x,
                                      v.y - proyeccionSobreU1.y,
                                      v.z - proyeccionSobreU1.z);

            // Agregamos el nuevo vector ortogonal a la lista
            ortogonales.Add(u2);

            // Actualizamos u1 para el siguiente paso de la proyección (si tienes más vectores)
            u1 = u2;
        }

        // Ahora, ortogonales contiene todos los vectores ortogonales generados
        // Devuelvo la lista con los vectores ortogonales
        return ortogonales;
    }

    // Suma de matrices (Ejemplo con matrices 2x2)
    public Matrix4x4 SumarMatrices(Matrix4x4 m1, Matrix4x4 m2) {
        Matrix4x4 resultado = new Matrix4x4();

        // Sumar elemento por elemento usando las propiedades de Matrix4x4
        resultado.m00 = m1.m00 + m2.m00;
        resultado.m01 = m1.m01 + m2.m01;
        resultado.m02 = m1.m02 + m2.m02;
        resultado.m03 = m1.m03 + m2.m03;

        resultado.m10 = m1.m10 + m2.m10;
        resultado.m11 = m1.m11 + m2.m11;
        resultado.m12 = m1.m12 + m2.m12;
        resultado.m13 = m1.m13 + m2.m13;

        resultado.m20 = m1.m20 + m2.m20;
        resultado.m21 = m1.m21 + m2.m21;
        resultado.m22 = m1.m22 + m2.m22;
        resultado.m23 = m1.m23 + m2.m23;

        resultado.m30 = m1.m30 + m2.m30;
        resultado.m31 = m1.m31 + m2.m31;
        resultado.m32 = m1.m32 + m2.m32;
        resultado.m33 = m1.m33 + m2.m33;

        return resultado;
    }
    //Angulo Entre Vectores :3
    public float AnguloEntreVectores(Vector3 v1, Vector3 v2) {
        // Producto punto
        float productoPunto = (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);

        // Magnitudes de los vectores
        float magnitudV1 = Mathf.Sqrt((v1.x * v1.x) + (v1.y * v1.y) + (v1.z * v1.z));
        float magnitudV2 = Mathf.Sqrt((v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z));

        // Cálculo del coseno del ángulo
        float cosenoAngulo = productoPunto / (magnitudV1 * magnitudV2);

        // Devolvemos el ángulo en grados
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
            v.x - 1 * productoPunto * n.x,
            v.y - 1 * productoPunto * n.y,
            v.z - 1 * productoPunto * n.z
        );
    }
    public Vector3 InterseccionLineaPlano(Vector3 puntoLinea, Vector3 direccionLinea, Vector3 puntoPlano, Vector3 normalPlano) {
        // Calculamos el parámetro t
        float t = ((puntoPlano.x - puntoLinea.x) * normalPlano.x +
                   (puntoPlano.y - puntoLinea.y) * normalPlano.y +
                   (puntoPlano.z - puntoLinea.z) * normalPlano.z) /
                  (direccionLinea.x * normalPlano.x +
                   direccionLinea.y * normalPlano.y +
                   direccionLinea.z * normalPlano.z);

        // Calculamos el punto de intersección
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
    public float ReflejoEscalar(float valor, float referencia) {
        return 2 * referencia - valor;
    }
    public Vector4 TransformacionRotacion(Vector4 vector, Matrix4x4 matrizRotacion) {
        Vector4 resultado = new Vector4(
            vector.x * matrizRotacion[0, 0] + vector.y * matrizRotacion[0, 1] + vector.z * matrizRotacion[0, 2] + vector.w * matrizRotacion[0, 3],
            vector.x * matrizRotacion[1, 0] + vector.y * matrizRotacion[1, 1] + vector.z * matrizRotacion[1, 2] + vector.w * matrizRotacion[1, 3],
            vector.x * matrizRotacion[2, 0] + vector.y * matrizRotacion[2, 1] + vector.z * matrizRotacion[2, 2] + vector.w * matrizRotacion[2, 3],
            vector.x * matrizRotacion[3, 0] + vector.y * matrizRotacion[3, 1] + vector.z * matrizRotacion[3, 2] + vector.w * matrizRotacion[3, 3]
        );
        return resultado;
    }
    public float[,] MultiplicarMatrices(float[,] matrizA, float[,] matrizB) {
        int filasA = matrizA.GetLength(0);
        int columnasA = matrizA.GetLength(1);
        int filasB = matrizB.GetLength(0);
        int columnasB = matrizB.GetLength(1);

        if (columnasA != filasB) {
            throw new InvalidOperationException("Las matrices no son multiplicables.");
        }

        float[,] resultado = new float[filasA, columnasB];

        for (int i = 0; i < filasA; i++) {
            for (int j = 0; j < columnasB; j++) {
                for (int k = 0; k < columnasA; k++) {
                    resultado[i, j] += matrizA[i, k] * matrizB[k, j];
                }
            }
        }

        return resultado;
    }
    public float[,] RestarMatrices(float[,] matrizA, float[,] matrizB) {
        if (matrizA.GetLength(0) != matrizB.GetLength(0) || matrizA.GetLength(1) != matrizB.GetLength(1)) {
            throw new InvalidOperationException("Las dimensiones de las matrices deben ser iguales para restarlas.");
        }

        int filas = matrizA.GetLength(0);
        int columnas = matrizA.GetLength(1);
        float[,] resultado = new float[filas, columnas];

        for (int i = 0; i < filas; i++) {
            for (int j = 0; j < columnas; j++) {
                resultado[i, j] = matrizA[i, j] - matrizB[i, j];
            }
        }

        return resultado;
    }
    public Vector3 InterseccionTresPlanos(Vector4 plano1, Vector4 plano2, Vector4 plano3) {
        // Cada plano se define como Vector4(A, B, C, D) donde Ax + By + Cz + D = 0
        Vector3 normal1 = new Vector3(plano1.x, plano1.y, plano1.z);
        Vector3 normal2 = new Vector3(plano2.x, plano2.y, plano2.z);
        Vector3 normal3 = new Vector3(plano3.x, plano3.y, plano3.z);

        // Determinante de las normales (para verificar si los planos se cruzan en un punto)
        float determinante = Vector3.Dot(normal1, Vector3.Cross(normal2, normal3));
        if (Mathf.Abs(determinante) < 0.0001f) {
            throw new InvalidOperationException("Los planos no se cruzan en un punto único.");
        }

        // Calcular el punto de intersección
        Vector3 punto = (
            -plano1.w * Vector3.Cross(normal2, normal3) -
            plano2.w * Vector3.Cross(normal3, normal1) -
            plano3.w * Vector3.Cross(normal1, normal2)
        ) / determinante;

        return punto;
    }
    public float[,] InversaMatriz3x3(float[,] matriz) {
        if (matriz.GetLength(0) != 3 || matriz.GetLength(1) != 3) {
            throw new InvalidOperationException("La matriz debe ser de 3x3.");
        }

        float determinante =
            matriz[0, 0] * (matriz[1, 1] * matriz[2, 2] - matriz[1, 2] * matriz[2, 1]) -
            matriz[0, 1] * (matriz[1, 0] * matriz[2, 2] - matriz[1, 2] * matriz[2, 0]) +
            matriz[0, 2] * (matriz[1, 0] * matriz[2, 1] - matriz[1, 1] * matriz[2, 0]);

        if (Mathf.Abs(determinante) < 0.0001f) {
            throw new InvalidOperationException("La matriz no tiene inversa (determinante = 0).");
        }

        float[,] adjunta = new float[3, 3];

        adjunta[0, 0] = matriz[1, 1] * matriz[2, 2] - matriz[1, 2] * matriz[2, 1];
        adjunta[0, 1] = -(matriz[1, 0] * matriz[2, 2] - matriz[1, 2] * matriz[2, 0]);
        adjunta[0, 2] = matriz[1, 0] * matriz[2, 1] - matriz[1, 1] * matriz[2, 0];

        adjunta[1, 0] = -(matriz[0, 1] * matriz[2, 2] - matriz[0, 2] * matriz[2, 1]);
        adjunta[1, 1] = matriz[0, 0] * matriz[2, 2] - matriz[0, 2] * matriz[2, 0];
        adjunta[1, 2] = -(matriz[0, 0] * matriz[2, 1] - matriz[0, 1] * matriz[2, 0]);

        adjunta[2, 0] = matriz[0, 1] * matriz[1, 2] - matriz[0, 2] * matriz[1, 1];
        adjunta[2, 1] = -(matriz[0, 0] * matriz[1, 2] - matriz[0, 2] * matriz[1, 0]);
        adjunta[2, 2] = matriz[0, 0] * matriz[1, 1] - matriz[0, 1] * matriz[1, 0];

        float[,] inversa = new float[3, 3];
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                inversa[i, j] = adjunta[i, j] / determinante;
            }
        }

        return inversa;
    }
    #endregion Operaciones Matemáticas
}
