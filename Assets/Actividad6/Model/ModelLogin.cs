
public class ModelLogin : IModelLogin
{
    public ILocalFileService localFileService;
    public ITypeOfUserLogin typeOfUserLoging;

    public ModelLogin()
    {
        localFileService = new LocalFilesService();
        typeOfUserLoging = new TypeOfUserLogin();
    }
    public AuthResult authenticateLogin(string username, string password)
    {
        AuthResult answerOfAuthentication;
        if (usernameNotFound(username))
        {
            answerOfAuthentication = AuthResult.UserNotFound;
        }
        else
        {
            if (passwordIsInvalid(username, password))
            {
                answerOfAuthentication = AuthResult.IncorrectPassword;
            }
            else
            {
                answerOfAuthentication = AuthResult.Success;
            }
        }
        return answerOfAuthentication;
    }
    public TypeOfUser getTypeOfUser(string username)
    {
        TypeOfUser userType;
        userType = typeOfUserLoging.getTypeOfUser(username);
        return userType;
    }


    private bool usernameNotFound(string username)
    {
        return !localFileService.CheckIfUserExist(username);
    }

    private bool passwordIsInvalid(string username, string password)
    {
        return !localFileService.CheckIfPasswordIsCorrect(username, password);
    }
}
