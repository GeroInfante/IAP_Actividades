using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Actividad1 : MonoBehaviour
{
    private string pathObj;
    private string pathCsv;
    private StreamWriter escritor;
    // Start is called before the first frame update
    void Start()
    {
        pathObj = "Assets/Objetos/ClassicTable.obj";
        pathCsv = "Assets/archivoCSV.csv";

        using (escritor= new StreamWriter(pathCsv))
        {
            escritor.WriteLine("Tipo,X,Y,Z");
            leerArchivo();            
        }

    }


    private void leerArchivo()
    {
        string linea;
        try
        {
            using (StreamReader lector = new StreamReader(pathObj))
            {
                while ((linea = lector.ReadLine()) != null)
                {
                    if (linea[0] == 'v')
                    {
                        switch (linea[1])
                        {
                            case ' ':
                                escritor.WriteLine(formarNuevaLineaV(linea));
                            break;

                            case 't':
                               escritor.WriteLine(formarNuevaLineaVT(linea));
                            break;

                            case 'n':
                                escritor.WriteLine(formarNuevaLineaVN(linea));
                            break;
                        }
                    }
                    else
                    {
                        if (linea[0] == 'f')
                        {
                            escritor.WriteLine(formarNuevaLineaF(linea));
                        }
                    }
                }    
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e.Message);
        }

    }

    private int mayorNro(int x, int y)
    {
        int retornar;
        
        if (x >= y)
            retornar = x;
        else
            retornar = y;
        return retornar;
    }
    
    private string formarNuevaLineaF(string linea)
    {
        string lineaNueva;
        int cantBarrasLeidas;
        int primerN, segundoN, tercerN, mayor;



        lineaNueva = "f,";
        cantBarrasLeidas = 0;
        primerN = 0;
        segundoN = 0;
        tercerN = 0;
        mayor = 0;
        Debug.Log(linea);
        for (int i = 2; i < linea.Length; i++)
        {
            if (linea[i] == ' ')
            {
                Debug.Log(primerN + " " + segundoN + " " + tercerN);
                mayor = mayorNro(primerN, mayorNro(segundoN, tercerN));
                //Debug.Log(lineaNueva + mayor.ToString());
                lineaNueva = lineaNueva + "" + mayor.ToString()+",";
                //Reseteo
                cantBarrasLeidas = 0;
                primerN = 0;
                segundoN = 0;
                tercerN = 0;
            }
            
            else
            {   
                if (linea[i] != '/')
                {
                    Debug.Log("No lei espacio, lei nro: "+linea[i]);
                    switch (cantBarrasLeidas)
                    {
                        case 0:
                            {
                                primerN = primerN * 10 + (linea[i] - '0');
                                Debug.Log(primerN);
                                break;
                            }
                        case 1:
                            {
                                segundoN = segundoN * 10 + (linea[i] - '0');
                                Debug.Log(segundoN);
                                break;
                            }

                        case 2:
                            {
                                tercerN = tercerN * 10 + (linea[i] - '0');
                                Debug.Log(tercerN);
                                break;
                            }
                    }
                }
                else
                {
                    cantBarrasLeidas++;
                }
            }
        }
        mayor = mayorNro(primerN, mayorNro(segundoN, tercerN));
        lineaNueva = lineaNueva + "" + mayor.ToString();//Agrego el ultimo

        return lineaNueva;
    }
    private string formarNuevaLineaVN(string linea)
    {
        string lineaNueva = "vn";
        bool leiPunto = false;
        int posUltimoChar = 0;
        int cantDecimalesLeer = -1;
        for (int i = 2; i < linea.Length; i++)
        {
            posUltimoChar = lineaNueva.Length - 1;//Posicion de ultimo char en la linea CSV

            if (lineaNueva[posUltimoChar] != ',')
            {
                if (linea[i] == ' ')
                {
                    lineaNueva += ',';
                    cantDecimalesLeer = -1;
                    leiPunto = false;
                }
                else
                {
                    if (linea[i] == '.')
                    {
                        cantDecimalesLeer = 2;
                        leiPunto = true;
                    }
                    if (!leiPunto)
                        lineaNueva += linea[i];
                    else
                    {
                        if (cantDecimalesLeer >= 0)
                        {
                            lineaNueva += linea[i];
                            cantDecimalesLeer--;
                        }
                    }
                }
            }
            else
            {
                if (linea[i] != ' ')
                    lineaNueva += linea[i];
            }
        }
        return lineaNueva;
    }
    private string formarNuevaLineaVT(string linea)
    {
        string lineaNueva;
        bool leyendoX;
        float x, y, z;
        string stringX, stringY;

        lineaNueva = "vt";
        leyendoX = false;
        x = 0;
        y = 0;
        z = 0;
        stringX = "";
        stringY = "";

        for (int i = 2; i < linea.Length; i++)
        {
            if (linea[i] != ' ')
            {
                lineaNueva += linea[i];
                if (leyendoX)
                    stringX += linea[i];
                else
                    stringY += linea[i];
            }
            else
            {
                lineaNueva += ',';
                if (!leyendoX)
                    leyendoX = true;
                else
                    leyendoX = false;

            }
        }
        //Una vez recorrida toda la linea, debemos agregar el numero resultante de la suma.
        float.TryParse(stringX, out x);
        float.TryParse(stringY, out y);
        z = x + y;
        lineaNueva += "," + z;
        return lineaNueva;
    }
    private string formarNuevaLineaV(string linea)
    {
        string lineaNueva = "v";
        int posUltimoChar = 0;
        bool esNegativo = false;
        for (int i = 1; i < linea.Length; i++)
        {
            posUltimoChar = lineaNueva.Length - 1;//Posicion de ultimo char en la linea CSV

            if (linea[i] == '-')    //Guardo informacion que se trata de numero a leer negativo.
                esNegativo = true;


            if (lineaNueva[posUltimoChar] != ',')
            {
                if (linea[i] == ' ')//SI se trata del primer espacio leido lo cambio por ","
                    lineaNueva += ',';
                else
                    lineaNueva += linea[i];//Si estoy leyendo mitad de un numero se agrega el char directo
            }
            else
            {
                if (lineaNueva[posUltimoChar] == ',' && linea[i] != '-' && linea[i] != ' ' && !esNegativo)//Si el numero que estoy por leer es Positivo, le agrego un -
                {
                    lineaNueva += "-" + linea[i];
                }
                else
                {
                    if (lineaNueva[posUltimoChar] == ',' && linea[i] != '-' && linea[i] != ' ' && esNegativo)//Si lei un - y ahora es el 1er char del numero, agrego directamente el char y digo que ya lo hice positivo.
                    {
                        lineaNueva += linea[i];
                        esNegativo = false;
                    }
                }
            }
        }
        return lineaNueva;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
