using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IAPUI : MonoBehaviour
{
    public TextMeshProUGUI label;
    public string calorNuevo;
    public GameObject panel1, panel2;

    public void PresioneBoton()
    {
        panel2.SetActive(!panel2.active);
        panel1.SetActive(!panel1.active);
    }
}
