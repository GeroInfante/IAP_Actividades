using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Diagnostics;

public class GestorArchivos
{
    ParseadorJson parser;
    public GestorArchivos()
    {
        parser = new ParseadorJson();
    }
    public List<Persona> obtenerPersonasDeArchivos()
    {
        List<Persona> totalPersonas = new List<Persona>();
        string carpetaUsuarios = "./Json/actividad3";
        Persona agregar;
        foreach (string pathArchivo in Directory.EnumerateFiles(carpetaUsuarios))
        {
            agregar = obtenerPersonaDeArchivoJson(pathArchivo);
            totalPersonas.Add(agregar);
        }
        return totalPersonas;
    }

    private Persona obtenerPersonaDeArchivoJson(String pathJson)
    {
        Persona personaDeJsonDado;
        string json = File.ReadAllText(pathJson);
        UnityEngine.Debug.Log("path: "+pathJson+ "\n JSON file: " + json);
        personaDeJsonDado = parser.parsearPersona(json);
        return personaDeJsonDado;
    }
}
