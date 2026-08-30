using UnityEngine;

public class TypeOfUserLogin : ITypeOfUserLogin
{
    public TypeOfUser getTypeOfUser(string username)
    {
        if(username=="admin")
        {
            return TypeOfUser.Admin;
        }
        else
        {
            return TypeOfUser.Agent;
        }
    }
}