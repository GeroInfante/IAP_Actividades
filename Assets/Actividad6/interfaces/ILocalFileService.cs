
public interface ILocalFileService
{
    Persona GetAgent(string username);
    bool CheckIfPasswordIsCorrect(string username, string password);
    bool CheckIfUserExist(string username);

}
