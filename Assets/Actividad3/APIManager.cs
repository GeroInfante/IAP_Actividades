using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
public class APIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator GetUser(UIManager uiManager)
    {
        bool exito = false;

        while (!exito)  // Reintenta hasta que funcione
        {
            UnityWebRequest www = UnityWebRequest.Get("https://randomuser.me/api/");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Parseo JSON
                string jsonCrudo = www.downloadHandler.text;
                Debug.Log(jsonCrudo);
                JObject objetoJson = JObject.Parse(jsonCrudo);

                if (objetoJson["results"] != null && objetoJson["results"].HasValues)
                {
                    var personaJson = objetoJson["results"][0];
                    Persona persona = new Persona();
                    persona.Nombre = (string)personaJson["name"]["first"];
                    persona.Apellido = (string)personaJson["name"]["last"];
                    persona.Edad = (string)personaJson["dob"]["age"];
                    persona.Telefono = (string)personaJson["phone"];
                    persona.Direccion = (string)personaJson["location"]["street"]["name"] + " " + (string)personaJson["location"]["street"]["number"];
                    persona.Email = (string)personaJson["email"];
                    persona.Imagen = (string)personaJson["picture"]["large"];

                    uiManager.setearPersona(persona);
                    exito = true; // Salimos del while
                }
                else
                {
                    Debug.LogWarning("JSON inválido, reintentando...");
                    yield return new WaitForSeconds(1f); // Espera antes de reintentar
                }
            }
            else
            {
                Debug.LogWarning("Error en la API: " + www.error + ", reintentando...");
                yield return new WaitForSeconds(1f); // Espera antes de reintentar
            }
    }
}

    private void EscribirEnArchivo(String pathAlmacenar, String json)
    {
        StreamWriter escritor = new StreamWriter(pathAlmacenar, false);
        escritor.WriteLine(json);
        escritor.Close();
    }

    public IEnumerator GetTexture(String url, Action<Texture2D> texturaDescargada)
    {
        bool exito = false;
        while (!exito)  // Reintenta hasta que funcione
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                texturaDescargada(texture);
                exito = true; // Salimos del while
            }
            else
            {
                Debug.LogWarning("Error al descargar la imagen: " + www.error + ", reintentando...");
                yield return new WaitForSeconds(1f); // Espera antes de reintentar
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
