using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Actividad2_B : MonoBehaviour
{
    private int n = 10;
    private static int MAX = 1000;
    private static int MIN = 1;
    // Start is called before the first frame update
    void Start()
    {
        string listaMostrar = "";
        string arregloImparInvertidoMostrar = "";
        int[] arregloDeDistintos = crearArreglo(lista10NumerosRandom());
        for (int i = 0; i < arregloDeDistintos.Length; i++)
        {
            listaMostrar += arregloDeDistintos[i] + " ";
        }
        Debug.Log("Lista de Distintos: " + listaMostrar);

        int[] arregloInvertidoImpar = invertirYeliminarPar(arregloDeDistintos);

        for (int i = 0; i < arregloInvertidoImpar.Length; i++)
        {
            arregloImparInvertidoMostrar += arregloInvertidoImpar[i] + " ";
        }
        Debug.Log("Arreglo sin Pares e invertido: " + arregloImparInvertidoMostrar);
    }
    private int[] invertirYeliminarPar(int[] arregloNros)
    {
        List<int> listaInvertidaImpar;

        listaInvertidaImpar = new List<int>();
        for (int i = arregloNros.Length - 1; i >= 0; i--)
        {
            if(arregloNros[i] % 2 != 0){
                listaInvertidaImpar.Add(arregloNros[i]);
            }
        }

        return listaInvertidaImpar.ToArray();
    }

    private int[] nroRandomDistinto(List<int> listaNrosEvitar)
    {
        int[] nroIntentos;
        int nroReturn, intentos;
        System.Random random;

        nroIntentos = new int[2];
        random = new System.Random();
        nroReturn = random.Next(MIN, MAX);
        intentos = 1;
        while (listaNrosEvitar.Contains(nroReturn))
        {
            //Debug.Log("nro:" + nroReturn + "Intento nro:" + intentos);
            nroReturn = random.Next(MIN, MAX);
            intentos++;
        }
        //Debug.Log("nroReturn: "+nroReturn+"-> " +intentos);
        nroIntentos[0] = nroReturn;
        nroIntentos[1] = intentos;
        return nroIntentos;
    }
    private int[] crearArreglo(List<int> listaNumerosEvitar)
    {
        int[] arregloN, nroIntentos;
        System.Random random;
        int cantIntentosTotales;

        arregloN = new int[n];
        random = new System.Random();
        cantIntentosTotales = 0;
        for (int i = 0; i < n; i++)
        {
            nroIntentos = nroRandomDistinto(listaNumerosEvitar);
            arregloN[i] = nroIntentos[0];
            cantIntentosTotales += nroIntentos[1];
        }
        Debug.Log("Cantidad intentos: " + cantIntentosTotales.ToString());

        return arregloN;
    }
    private List<int> lista10NumerosRandom()
    {
        List<int> listaNumeros;
        string lista = "";
        listaNumeros = new List<int>();
        System.Random random = new System.Random();
        for (int i = 0; i < 10; i++)
        {
            listaNumeros.Add(random.Next(MIN, MAX));
            lista += listaNumeros.Last().ToString() + " ";
        }
        Debug.Log("Lista de Conjunto a evitar: "+lista);
        return listaNumeros;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
