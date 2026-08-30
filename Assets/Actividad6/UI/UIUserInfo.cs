using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class UIUserInfo : MonoBehaviour, IUIUserInfo
{
    public TextMeshProUGUI agentName, agentLastName, agentAge, agentPhone, agentAddress, agentEmail;
    public Button logout;
    public Image agentImage;
    public UIManager_Act6 UIManager;
    public IPresenterUserInfo userInfoPresenter;

    public void ShowuserInfoPanel()
    {
        UIManager.ChangeLogPanelToDataPanel();
    }
    public void ShowUsername(string username)
    {
        userInfoPresenter.showUser(username);
    }
    public void LogoutUser()
    {
        UIManager.ChangeDataPanelToLogPanel();
    }
    public void showName(string name)
    {
        agentName.text = name;     
    }
    public void showLastName(string lastName)
    {
        agentLastName.text = lastName;
    }
    public void showAge(string age)
    {
        agentAge.text = age;
    }
    public void showPhone(string phone)
    {
        agentPhone.text = phone;
    }
    public void showAddress(string address)
    {
        agentAddress.text = address;
    }
    public void showEmail(string email)
    {
        agentEmail.text = email;
    }
    public void showImage(Sprite image)
    {
        agentImage.sprite = image;
    }


    // Start is called before the first frame update
    void Start()
    {
        userInfoPresenter = new PresenterUserInfo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
