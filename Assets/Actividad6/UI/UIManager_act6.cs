using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Timeline;

public class UIManager_Act6 : MonoBehaviour, IUImanager
{
    public UILogin panelLogin;
    public UIUserInfo panelUserInfo;
    public UIAdmin panelAdmin;

    

    public void showUser(string username)
    {
        panelUserInfo.ShowUsername(username);
    }

    private void ActivateAdminPanel()
    {
        panelAdmin.gameObject.SetActive(true);
    }

     private void DeactivateAdminPanel()
    {
        panelAdmin.gameObject.SetActive(false);
    }   

    private void DeactivateLoginPanel()
    {
        panelLogin.gameObject.SetActive(false);
    }
    private void ActivateLoginPanel()
    {
        panelLogin.gameObject.SetActive(true);
    }

    private void ActivateDataPanel()
    {
        panelUserInfo.gameObject.SetActive(true);
    }

    private void DeactivateDataPanel()
    {
        panelUserInfo.gameObject.SetActive(false);
    }

    public void ChangeLogPanelToDataPanel()
    {
        Debug.Log("Cambiando a panel de datos");
        ActivateDataPanel();
        DeactivateLoginPanel();
    }

    public void ChangeDataPanelToLogPanel()
    {
        ActivateLoginPanel();
        
        DeactivateDataPanel();
    }
    public void changeLogPanelToAdminPanel()
    {
        // Example implementation: hide login panel, show admin panel
        ActivateAdminPanel();
        DeactivateLoginPanel();
    }


    // Start is called before the first frame update
    void Start()
    {
        panelAdmin.gameObject.SetActive(false);
        panelUserInfo.gameObject.SetActive(false);
        panelLogin.gameObject.SetActive(true);

    }



    // Update is called once per frame
    void Update()
    {

    }
}
