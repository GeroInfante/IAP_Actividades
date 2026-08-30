using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI nombre, apellido, edad, telefono, direccion, email, indice;
    public Button siguiente, anterior;
    public Image imagenPerfil;
    public APIManager apiManager;
    private List<Persona> personas;
    private const int CANTIDADPERSONAS = 10;
    private const int INICIO = 0;
    private const int FIN = 9;
    private int indiceActual;
    private int personasCargadas;

    //MALA PRACTICA pero resolucion rapida
    public GameObject muestraDatos, loggueo;

    //bottones y texto de logg:
    public Button api, archivo;
    public TextMeshProUGUI textoEleccion;

    public GestorArchivos gestor;
    // Start is called before the first frame update
    void Start()
    {
        personas = new List<Persona>();
        indiceActual = 0;
        indice.text = "1";
        personasCargadas = 0;
        anterior.gameObject.SetActive(false);
        muestraDatos.SetActive(false);
        loggueo.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void actualizarIndice()
    {
        indice.text = "" + (indiceActual + 1);
    }

    public void setearPersona(Persona persona)
    {
        personas.Add(persona);
        personasCargadas++;
        if (personasCargadas == CANTIDADPERSONAS)
        {
            loggueo.SetActive(false);
            muestraDatos.SetActive(true);
            MostrarUsuario();
        }
    }

    public void obtenerPersonasArchivo()
    {
        gestor = new GestorArchivos();
        personas = gestor.obtenerPersonasDeArchivos();
        loggueo.SetActive(false);
        muestraDatos.SetActive(true);
        MostrarUsuario();
    }

    public void CargarPersonas()
    {
        for (int i = 0; i < CANTIDADPERSONAS; i++)
        {
            StartCoroutine(apiManager.GetUser(this));
        }
    }
    public void Siguiente()
    {
        if (indiceActual < FIN)
        {
            indiceActual++;
            MostrarUsuario();
        }
        if (indiceActual == FIN)
        {
            siguiente.gameObject.SetActive(false);
        }
        if (indiceActual > INICIO)
        {
            anterior.gameObject.SetActive(true);
        }
        actualizarIndice();
    }
    public void Anterior()
    {
        if (indiceActual > INICIO)
        {
            indiceActual--;
            MostrarUsuario();
        }
        if (indiceActual == INICIO)
        {
            anterior.gameObject.SetActive(false);
        }
        if (indiceActual < FIN)
        {
            siguiente.gameObject.SetActive(true);
        }
        actualizarIndice();
    }
    void MostrarUsuario()
    {
        Persona personaMostrar = personas[indiceActual];
        nombre.text = "Nombre: " + personaMostrar.Nombre;
        apellido.text = "Apellido: " + personaMostrar.Apellido;
        edad.text = "Edad: " + personaMostrar.Edad;
        telefono.text = "Telefono: " + personaMostrar.Telefono;
        email.text = "Email: " + personaMostrar.Email;
        direccion.text = "Direccion: " + personaMostrar.Direccion;
        mostrarImagen(personaMostrar.Imagen);
    }

    void mostrarImagen(string url)
    {
        StartCoroutine(apiManager.GetTexture(url, (imagenPerfil=>
        {
            this.imagenPerfil.sprite = Sprite.Create(imagenPerfil, new Rect(0, 0, imagenPerfil.width, imagenPerfil.height), new Vector2(0.5f, 0.5f));
        })));
    }
}
