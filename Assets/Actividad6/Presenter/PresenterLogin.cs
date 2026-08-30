
using System;
using System.Threading.Tasks;

public class PresenterLogin : IPresenterLogin
{
    public IModelLogin loginModel;
    public UILogin loginUI;

    public PresenterLogin(UILogin loginUI)
    {
        this.loginUI = loginUI;
        loginModel = new ModelLogin();
    }

    public void Login(string usernameToVerify, string passwordToVerify)
    {
        AuthResult loginAnswer = loginModel.authenticateLogin(usernameToVerify, passwordToVerify);
        if (loginAnswer == AuthResult.UserNotFound)
        {
            loginUI.showUserNotFound();
        }
        else
        {
            if (loginAnswer == AuthResult.IncorrectPassword)
            {
                loginUI.showIncorrectPassword();
            }
            else
            {
                TypeOfUser userType = loginModel.getTypeOfUser(usernameToVerify);
                if (userType == TypeOfUser.Admin)
                {
                    loginUI.ShowAdmin();
                }
                else
                {
                    loginUI.showUser();   
                }
            }
        }
    }

}
