using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PresenterUserInfo : IPresenterUserInfo
{
    public UIUserInfo userInfoUI;
    public IModelUserInfo userInfoModel;

    public PresenterUserInfo(UIUserInfo ui)
    {
        userInfoUI = ui;
        userInfoModel = new ModelUserInfo();
    }
    public async Task showUser(string username)
    {
        Persona agent = userInfoModel.GetAgentWithUsername(username);
        Sprite image = await userInfoModel.GetAgentImage(agent.Imagen);
        showAgentInuserInfoInterface(agent, image);
        userInfoUI.ShowuserInfoPanel();
        
    }

    private void showAgentInuserInfoInterface(Persona agentToShow, Sprite image)
    {
        userInfoUI.showName(agentToShow.Nombre);
        userInfoUI.showLastName(agentToShow.Apellido);
        userInfoUI.showAge(agentToShow.Edad);
        userInfoUI.showPhone(agentToShow.Telefono);
        Debug.Log(agentToShow.Telefono);
        userInfoUI.showAddress(agentToShow.Direccion);
        userInfoUI.showEmail(agentToShow.Email);
        userInfoUI.showImage(image);
    }

}
