using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.ComponentModel;

public class Actividad_C : MonoBehaviour
{
    private static int MAX = 20;
    private static int MIN = 1;
    private static int N = 70;

    // Start is called before the first frame update
    void Start()
    {
        List<int> listaNros = listaNNumerosRandom(N);
        Debug.Log("Lista N RANDOM: " + listaToString(listaNros));
        Dictionary<int, int> diccionario = new Dictionary<int, int>();

        llenarDiccionario(diccionario, listaNros);
        Debug.Log("Diccionario: "+diccionarioToString(diccionario));
        Debug.Log("Suma total de apariciones: " + sumaTodasApariciones(diccionario));

        //Parte2:
        exportarDiccionarioToCSV(diccionario, "Assets/Actividad2/tablaCSV.csv");


        //Parte3
        List<int> listaRepetidos = EliminarRepetidos(listaNros);
        Debug.Log("Lista de repetidos: " + listaToString(listaRepetidos));

        List<int> listaKrepeticiones = nuevaListaConKRepeticionesPorNumero(listaRepetidos);
        Debug.Log("Lista K repetido: " + listaToString(listaKrepeticiones));

        Dictionary<int, int> diccionarioKRepetidos = new Dictionary<int, int>();
        llenarDiccionario(diccionarioKRepetidos, listaKrepeticiones);
        Debug.Log("Diccionario: "+diccionarioToString(diccionarioKRepetidos));
        exportarDiccionarioToCSV(diccionarioKRepetidos, "Assets/Actividad2/tablaCSVKrepetido.csv");
    }
    private List<int> nuevaListaConKRepeticionesPorNumero(List<int> lista)
    {
        List<int> listaConNumerosRepetidos = new List<int>();
        foreach (int numero in lista) {

            for (int i = 0; i < numero; i++)
            {
                listaConNumerosRepetidos.Add(numero);
            }
        }
        return listaConNumerosRepetidos;
    }
    private string listaToString(List<int> lista)
    {
        string stringLista = "";
        for (int i = 0; i < lista.Count; i++)
        {
            stringLista += lista[i].ToString();
            if (i != lista.Count - 1)
                stringLista += ",";    
        }
        return stringLista;
    }
    private void eliminarElementosDeLista(List<int> elementosAEliminar, List<int> lista)
    {
        foreach (int numeroAeliminar in elementosAEliminar)
        {
            lista.RemoveAll(nroEnLista => nroEnLista == numeroAeliminar);
        }
    }
    private bool perteneceALista(int numero, List<int> listaNumeros)
    {
        return listaNumeros.Contains(numero);
    }
    private List<int> EliminarRepetidos(List<int> listaNumerosAnalizar)
    {
        List<int> sinNumerosRepetidos;
        sinNumerosRepetidos = new List<int>();
        foreach (int numero in listaNumerosAnalizar)
        {
            if(!sinNumerosRepetidos.Contains(numero))
            {
                sinNumerosRepetidos.Add(numero);
            }
        }
        return sinNumerosRepetidos;
    }
    private void exportarDiccionarioToCSV(Dictionary<int, int> diccionario, string pathCSV)
    {

        using (StreamWriter escritor = new StreamWriter(pathCSV, false))//Se usa para que no se deje el recurso hasta que no termine de escribir
        {
            escritor.WriteLine("Clave,Valor");
            foreach (KeyValuePair<int, int> indice in diccionario)
            {
                escritor.WriteLine(indice.Key + "," + indice.Value);
            }
        }
    }

    private int cantidadEspaciosAgregar(int numero, int maximoEspacio)
    {
        int numeroMaximoDeLugares = maximoEspacio.ToString().Length;
        return numeroMaximoDeLugares - numero.ToString().Length;
    }
    private string diccionarioToString(Dictionary<int, int> diccionario)
    {
        string cadenaConDiccionario;
        int cantEspacios;
        cadenaConDiccionario = "clave|valor\n";

        foreach (KeyValuePair<int, int> indice in diccionario)
        {
            cantEspacios = cantidadEspaciosAgregar(indice.Key, MAX);
            for (int i = 0; i < cantEspacios; i++)
            {
                cadenaConDiccionario += " ";
            }
            cadenaConDiccionario += indice.Key + " ";
            cantEspacios = cantidadEspaciosAgregar(indice.Value, N*10);
            for (int j = 0; j < cantEspacios; j++)
            {
                cadenaConDiccionario += " ";
            }
            cadenaConDiccionario += indice.Value + "\n";
        }
        return cadenaConDiccionario;
    }
    private int sumaTodasApariciones(Dictionary<int, int> diccionario)
    {
        int sumaTotalApariciones;

        sumaTotalApariciones = 0;

        foreach (KeyValuePair<int, int> indice in diccionario)
        {
            sumaTotalApariciones += indice.Value;
        }
        return sumaTotalApariciones;
    }
    private void llenarDiccionario(Dictionary<int, int> diccionario, List<int> listaClaves)
    {

        for (int clave = MIN; clave <= MAX; clave++)
        {
            diccionario.Add(clave, cantApariciones(clave, listaClaves));
        }

    }
    private int cantApariciones(int nroBuscado, List<int> listaClaves)
    {
        int cant = 0;
        foreach (int numeroEnLista in listaClaves)
        {
            if (numeroEnLista == nroBuscado)
                cant++;
        }
        return cant;
    }
    private List<int> listaNNumerosRandom(int n)
    {
        List<int> listaNumeros;
        string lista = "";
        listaNumeros = new List<int>();
        System.Random random = new System.Random();
        for (int i = 0; i < n; i++)
        {
            listaNumeros.Add(generarNroRandom());
            lista += listaNumeros.Last().ToString() + " ";
        }
        return listaNumeros;
    }
    private int generarNroRandom()
    {
        System.Random random = new System.Random();
        return random.Next(MIN, MAX);
    }

    void Update()
    {
        
    }
}
