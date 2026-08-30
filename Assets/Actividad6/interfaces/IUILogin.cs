using System.Threading.Tasks;

interface IUILogin
{
    void LoginUser();
    void showUser();
    void ShowAdmin();
    void showUserNotFound();
    void showIncorrectPassword();
}