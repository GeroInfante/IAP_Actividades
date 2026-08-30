using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public interface IUIUserInfo
{
    void ShowuserInfoPanel();
    void ShowUsername(string username);
    void LogoutUser();
    void showName(string name);
    void showLastName(string lastName);
    void showAge(string age);
    void showPhone(string phone);
    void showAddress(string address);
    void showEmail(string email);
    void showImage(Sprite image);
}
