﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class dataInsert : MonoBehaviour
{
    public int employeeID;
    public string email;

    string registerURL = "http://34.208.221.68/pcPHP/register.php";

    void Start()
    {
        print("it has began");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Register(employeeID, email);
            print("register user");
        }
    }

    public void Register(int employeeID, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("employeeIDPost", employeeID);
        form.AddField("emailPost", email);

        WWW www = new WWW(registerURL, form);
    }
}
