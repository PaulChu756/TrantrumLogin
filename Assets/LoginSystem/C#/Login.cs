using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    public int inputEmployeeID;
    public string inputEmail;

    string loginURL = "http://34.208.221.68/pcPHP/Login.php";

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(login(inputEmployeeID, inputEmail));
	}

    IEnumerator login(int employee, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("employeeIDPost", employee);
        form.AddField("emailPost", email);

        WWW www = new WWW(loginURL, form);
        yield return www;
        print(www.text);
    }
}
