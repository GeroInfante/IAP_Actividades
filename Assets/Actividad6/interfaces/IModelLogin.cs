using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModelLogin
{
    AuthResult authenticateLogin(string username, string password);
    TypeOfUser getTypeOfUser(string username);
}
