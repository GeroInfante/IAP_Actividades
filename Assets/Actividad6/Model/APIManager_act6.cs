using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager_act6 :IApiManager
{
    public APIManager_act6()
    {
    }
    public async Task<Texture2D> GetTexture(string url)
    {
        bool exito = false;
        Texture2D texture = null;

        while (!exito)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
            {
                var asyncOp = www.SendWebRequest();

                while (!asyncOp.isDone) // espera sin bloquear
                    await Task.Yield();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                    exito = true;
                }
                else
                {
                    Debug.LogWarning("Error al descargar la imagen: " + www.error + ", reintentando...");
                    await Task.Delay(1000); // espera 1s antes de reintentar
                }
            }
        }
        Debug.Log("Imagen descargada correctamente");

        return texture;
    }
}

