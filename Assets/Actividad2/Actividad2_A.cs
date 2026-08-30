using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Actividad2_A : MonoBehaviour
{
    // Start is called before the first frame update
    private int[,] matriz;
    private int a = 14;
    private int b = 23;

    private const int MAX = 100000000;
    private const int MIN = 1;
    private static char ESPACIO= '\u2007';


    void Start()
    {
        crearMatriz();
        llenarMatriz(crearListaNumeros());
        imprimirMatriz();
    }

    private void imprimirMatriz()
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        int nroMatriz = 0;
        int longMaxNroConEspacio = MAX.ToString().Length + 1;
        string lineaCompletaConFormato = "Matriz: \n";

        for (int fila = 0; fila < filas; fila++)
        {

            for (int col = 0; col < columnas; col++)
            {//aca
                nroMatriz = matriz[fila, col];
                int cantEspacios = longMaxNroConEspacio - nroMatriz.ToString().Length;
                for (int espacio = 0; espacio < cantEspacios; espacio++)
                {
                    lineaCompletaConFormato += ESPACIO;
                }
                lineaCompletaConFormato += nroMatriz;
            }
            lineaCompletaConFormato += "\n";
        }
        Debug.Log(lineaCompletaConFormato);
    }
    private void llenarMatriz(int[] listaNumeros)
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        int i = 0;
        for (int fila = 0; fila < filas; fila++)
        {
            for (int col = 0; col < columnas; col++)
            {                
                matriz[fila, col] = listaNumeros[i++];
            }
        }
    }

    private int[] crearListaNumeros()
    {
        int[] listaNumeros;
        int n = a * b;
        listaNumeros = new int[n];
        System.Random random = new System.Random();
        for (int i = 0; i < listaNumeros.Length; i++)
        {
            listaNumeros[i] = random.Next(MIN, MAX);
        }
        return listaNumeros;

    }

    private void crearMatriz()
    {
        int filas = a;
        int columnas = b;
        matriz = new int[filas, columnas];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

