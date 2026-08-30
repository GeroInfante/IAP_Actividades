using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class ParseadorJson : MonoBehaviour
{
    // Start is called before the first frame update
    public Persona parsearPersona(string pathJson)
    {
        JObject objetoJson = JObject.Parse(pathJson);


        var personaJson = objetoJson["results"][0];
        Persona persona = new Persona();
        persona.Nombre = (string)personaJson["name"]["first"];
        persona.Apellido = (string)personaJson["name"]["last"];
        persona.Edad = (string)personaJson["dob"]["age"];
        persona.Telefono = (string)personaJson["phone"];
        persona.Direccion = (string)personaJson["location"]["street"]["name"] + " " + (string)personaJson["location"]["street"]["number"];
        persona.Email = (string)personaJson["email"];
        persona.Imagen = (string)personaJson["picture"]["large"];

        return persona;
    }
}
