using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour, IUILogin
{
    public Button togglePasswordVisibility, login;
    public TMP_InputField username, password;

    public TextMeshProUGUI userError, passwordError;
    private Color VISIBLE = Color.green;
    private Color NOTVISIBLE = Color.red;



    private IPresenterLogin loginPresenter;
    public UIManager_Act6 UIManager;
    void Start()
    {
        loginPresenter = new PresenterLogin(this);
        ChangeTogglePasswordVisibilityColors(NOTVISIBLE);
        userError.gameObject.SetActive(false);
        passwordError.gameObject.SetActive(false);
    }

    public void TogglePasswordVisibility()
    {
        bool isVisible = getPasswordVisibility();
        if (isVisible)
        {
            password.contentType = TMP_InputField.ContentType.Password;
            ChangeTogglePasswordVisibilityColors(NOTVISIBLE);
        }
        else
        {
            password.contentType = TMP_InputField.ContentType.Standard;
            ChangeTogglePasswordVisibilityColors(VISIBLE);
        }
        password.ForceLabelUpdate();
    }
    private bool getPasswordVisibility()
    {
        bool isVisible = false;
        if (password.contentType == TMP_InputField.ContentType.Standard)
            isVisible = true;
        return isVisible;
    }

    private void ChangeTogglePasswordVisibilityColors(Color color)
    {
        togglePasswordVisibility.image.color = color;
    }

    public void LoginUser()
    {
        clearErrors();
        loginPresenter.Login(username.text, password.text);
        Debug.Log("Intentando loguear a " + username.text);
        resetAllInputs();
    }
    public void showUser()
    {
        string usernameToshow = username.text;
        UIManager.showUser(usernameToshow);
    }

    public void ShowAdmin()
    {
        UIManager.changeLogPanelToAdminPanel();
    }

    public void showUserNotFound()
    {
        userError.gameObject.SetActive(true);
    }
    public void showIncorrectPassword()
    {
        passwordError.gameObject.SetActive(true);
    }

    private void resetAllInputs()
    {
        username.text = "";
        password.text = "";
    }
    private void clearErrors()
    {
        userError.gameObject.SetActive(false);
        passwordError.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}