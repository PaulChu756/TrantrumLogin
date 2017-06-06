using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class dataInsert : MonoBehaviour
{
    public int inputEmployeeID;
    public string inputEmail;

    string registerURL = "http://34.208.221.68/php/register.php";

    void Start()
    {
        print("it has began");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Register(inputEmployeeID, inputEmail);
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
