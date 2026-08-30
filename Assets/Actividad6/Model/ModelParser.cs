using Newtonsoft.Json.Linq;

public class ModelParser : IParser
{
    public string getPassword(string json)
    {
        JObject objetoJson = JObject.Parse(json);
        var personaJson = objetoJson["results"][0];
        string password = (string)personaJson["login"]["password"];
        return password;
    }

    public Persona getUser(string Json)
    {
        JObject objetoJson = JObject.Parse(Json);


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
