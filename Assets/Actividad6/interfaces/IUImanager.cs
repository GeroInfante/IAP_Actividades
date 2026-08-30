using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUImanager
{
    void showUser(string username);
    void ChangeDataPanelToLogPanel();
    void ChangeLogPanelToDataPanel();

    void changeLogPanelToAdminPanel();
}
