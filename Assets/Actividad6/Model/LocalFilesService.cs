using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalFilesService : ILocalFileService
{
    const String jsonsPathfolder = "./Json/Actividad6";
    public IParser parser;

    public LocalFilesService()
    {
        parser = new ModelParser();
    }

    public bool CheckIfUserExist(string username)
    {
        bool userNotFound = true;
        bool userFound = false;
        string userJsonpath, currentUser;


        IEnumerable<string> usersJsons = Directory.EnumerateFiles(jsonsPathfolder);
        IEnumerator<string> iteratorUserJsons = usersJsons.GetEnumerator();

        while (userNotFound && iteratorUserJsons.MoveNext())
        {
            userJsonpath = iteratorUserJsons.Current;
            currentUser = Path.GetFileName(userJsonpath);
            if (username.Equals(currentUser))
                userNotFound = false;
        }
        userFound = !userNotFound;
        Debug.Log("User foud: " + userFound);
        return userFound;
    }

    public bool CheckIfPasswordIsCorrect(string username, string password)
    {
        string json = GetJsonTextwithUsername(username);
        string realPassword = parser.getPassword(json);
        bool passwordIscorrect = realPassword.Equals(password);
        Debug.Log("Password Correct: " + passwordIscorrect);
        return passwordIscorrect;
    }
    public Persona GetAgent(string username)
    {
        string json = GetJsonTextwithUsername(username);
        Persona agentOrdered = parser.getUser(json);
        return agentOrdered;
    }
    private string GetJsonTextwithUsername(string username)
    {
        string usernameJsonPath = GetUserJsonPath(username);
        string json = File.ReadAllText(usernameJsonPath);
        return json;
    }
    private string GetUserJsonPath(string username)
    {
        string userJsonpath = "";
        string currentUser;
        bool userNotFound = true;

        IEnumerable<string> usersJsons = Directory.EnumerateFiles(jsonsPathfolder);
        IEnumerator<string> iteratorUserJsons = usersJsons.GetEnumerator();

        while (userNotFound && iteratorUserJsons.MoveNext())
        {
            userJsonpath = iteratorUserJsons.Current;
            currentUser = Path.GetFileName(userJsonpath);
            if (username.Equals(currentUser))
                userNotFound = false;
        }
        return userJsonpath;
    }
}
