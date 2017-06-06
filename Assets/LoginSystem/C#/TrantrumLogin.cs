using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;


public class TrantrumLogin : MonoBehaviour
{
    public string loginUrl = "http://34.208.221.68/php/login.php";
    public string registerURL = "http://34.208.221.68/php/register.php";

    void Start()
    {
        if (PlayerPrefs.GetInt("LoginRemember") == 1)
        {
            GameObject _go = GameObject.Find("Canvas").transform.FindChild("Login").gameObject;
            _go.transform.FindChild("EmployeeID").gameObject.GetComponent<InputField>().text = PlayerPrefs.GetString("LoginEmployeeID");
            _go.transform.FindChild("Email").gameObject.GetComponent<InputField>().text = PlayerPrefs.GetString("LoginEmail");
            _go.transform.FindChild("Remember Me").gameObject.GetComponent<Toggle>().isOn = true;
        }
    }

    public void Login(GameObject _go)
    {
        string _employeeID = _go.transform.FindChild("EmployeeID").gameObject.GetComponent<InputField>().text;
        string _email = _go.transform.FindChild("Email").gameObject.GetComponent<InputField>().text;

        _go.transform.FindChild("EmployeeID").gameObject.GetComponent<InputField>().enabled = false;
        _go.transform.FindChild("Email").gameObject.GetComponent<InputField>().enabled = false;
        _go.transform.FindChild("Remember Me").gameObject.GetComponent<Toggle>().enabled = false;
        _go.transform.FindChild("Login").gameObject.GetComponent<Button>().enabled = false;
        _go.transform.FindChild("Register").gameObject.GetComponent<Button>().enabled = false;

        _go.transform.FindChild("Msg").GetComponent<Text>().text = "...";
        StartCoroutine(LoginIE(_employeeID, _email, _go));
    }
    IEnumerator LoginIE(string _employeeID, string _email, GameObject _go)
    {
        WWWForm form = new WWWForm();
        form.AddField("employeeIDPost", _employeeID);
        form.AddField("emailPost", _email);

        WWW www = new WWW(loginUrl, form);
        yield return www;
        string _return = www.text;
        print(_return);

        if (_return == "")
        {
            _go.transform.FindChild("Msg").GetComponent<Text>().text = "Server offline";
        }
        else if (_return == _email)
        {
            _go.transform.FindChild("Msg").GetComponent<Text>().text = "Welcome";
            if (_go.transform.FindChild("Remember Me").gameObject.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("LoginRemember", 1);
                PlayerPrefs.SetString("LoginEmployeeID", _employeeID);
                PlayerPrefs.SetString("LoginEmail", _email);
            }
            else
            {
                PlayerPrefs.SetInt("LoginRemember", 0);
            }

            GameObject _goEmployeeID = new GameObject("EmployeeID: " + _employeeID);
            DontDestroyOnLoad(_goEmployeeID);
            Application.LoadLevel("Game");
            //SceneManagement.LoadScene("Game", LoadSceneMode.Single);
        }
        else
        {
            _go.transform.FindChild("Msg").GetComponent<Text>().text = "Incorrect employeeID or email";
            _go.transform.FindChild("EmployeeID").gameObject.GetComponent<InputField>().enabled = true;
            _go.transform.FindChild("Email").gameObject.GetComponent<InputField>().enabled = true;
            _go.transform.FindChild("Remember Me").gameObject.GetComponent<Toggle>().enabled = true;
            _go.transform.FindChild("Login").gameObject.GetComponent<Button>().enabled = true;
            _go.transform.FindChild("Register").gameObject.GetComponent<Button>().enabled = true;
            _go.transform.FindChild("Forgot").gameObject.GetComponent<Button>().enabled = true;
        }
    }

/*
    public void ResetRegister(GameObject _go)
    {
        InputField _employeeID = _go.transform.FindChild("EmployeeID").gameObject.GetComponent<InputField>();
        InputField _email = _go.transform.FindChild("Email").gameObject.GetComponent<InputField>();
        InputField _emailComfirm = _go.transform.FindChild("Email Comfirm").gameObject.GetComponent<InputField>();
        Toggle _termsToggle = _go.transform.FindChild("Toggle").gameObject.GetComponent<Toggle>();
        Button _terms = _go.transform.FindChild("Terms").gameObject.GetComponent<Button>();
        Text _msg = _go.transform.FindChild("Msg").gameObject.GetComponent<Text>();

        _employeeID.text = "";
        _email.text = "";
        _emailComfirm.text = "";
        _termsToggle.isOn = false;
        _msg.text = "";

        _employeeID.enabled = true;
        _email.enabled = true;
        _emailComfirm.enabled = true;
        _termsToggle.enabled = true;
        _go.transform.FindChild("Back").gameObject.GetComponent<Button>().enabled = true;
        _go.transform.FindChild("Submit").gameObject.GetComponent<Button>().enabled = true;
    }
    public void Register(GameObject _go)
    {
        StartCoroutine(RegisterIE(_go));
    }
    IEnumerator RegisterIE(GameObject _go)
    {
        InputField _employeeID = _go.transform.FindChild("EmployeeID").gameObject.GetComponent<InputField>();
        InputField _email = _go.transform.FindChild("Email").gameObject.GetComponent<InputField>();
        InputField _emailComfirm = _go.transform.FindChild("Email Comfirm").gameObject.GetComponent<InputField>();
        Toggle _termsToggle = _go.transform.FindChild("Toggle").gameObject.GetComponent<Toggle>();
        Button _terms = _go.transform.FindChild("Terms").gameObject.GetComponent<Button>();
        Text _msg = _go.transform.FindChild("Msg").gameObject.GetComponent<Text>();

        _go.transform.FindChild("Back").gameObject.GetComponent<Button>().enabled = false;
        _go.transform.FindChild("Submit").gameObject.GetComponent<Button>().enabled = false;

        _employeeID.enabled = false;
        _email.enabled = false;
        _emailComfirm.enabled = false;
        _termsToggle.enabled = false;
        _terms.enabled = false;
        _msg.text = "";

        bool _error = false;
        if (_employeeID.text == "")
        {
            _employeeID.image.color = Color.red;
            _msg.text = "Enter employeeID";
            _error = true;
        }

        if (!_error)
        {
            if (_email.text == "")
            {
                _email.image.color = Color.red;
                _msg.text = "Enter password";
                _error = true;
            }
            else
            {
                _email.image.color = Color.white;

                if (_email.text != _email.text)
                {
                    _emailComfirm.image.color = Color.red;
                    _msg.text = "Passwords does not match";
                    _error = true;
                }
                else
                {
                    _emailComfirm.image.color = Color.white;
                }
            }
        }

        if (!_error)
        {
            if (!_termsToggle.isOn)
            {
                _termsToggle.image.color = Color.red;
                _error = true;
            }
            else
            {
                _termsToggle.image.color = Color.white;
            }
        }

        if (!_error)
        {
            WWWForm form = new WWWForm();
            form.AddField("employeeID", _employeeID.text);
            form.AddField("email", _email.text);

            WWW www = new WWW(registerURL, form);
            yield return www;
            string _return = www.text;

            if (_return == "true")
            {
                _msg.text = "Registration is complete";
                yield return new WaitForSeconds(1);
                Application.LoadLevel(Application.loadedLevel);
            }
            else
            {
                _msg.text = "Server offline";
                _error = true;
            }
        }

        if (_error)
        {
            _employeeID.enabled = true;
            _email.enabled = true;
            _emailComfirm.enabled = true;
            _termsToggle.enabled = true;
            _terms.enabled = true;
            _go.transform.FindChild("Back").gameObject.GetComponent<Button>().enabled = true;
            _go.transform.FindChild("Submit").gameObject.GetComponent<Button>().enabled = true;
        }
    }
*/

    /*
    public void Forgot(GameObject _go)
    {
        StartCoroutine(ForgotIE(_go));
    }
    IEnumerator ForgotIE(GameObject _go)
    {
        InputField _email = _go.transform.FindChild("Email").gameObject.GetComponent<InputField>();
        Text _msg = _go.transform.FindChild("Msg").gameObject.GetComponent<Text>();

        Button _back = _go.transform.FindChild("Back").gameObject.GetComponent<Button>();
        Button _send = _go.transform.FindChild("Send").gameObject.GetComponent<Button>();

        if (_email.text == "")
        {
            _msg.text = "Enter email";
        }
        else
        {
            if (!VerifyEmailAddress(_email.text))
            {
                _msg.text = "Email not valid";
            }
            else
            {
                _back.enabled = false;
                _send.enabled = false;
                _email.enabled = false;

                WWWForm form = new WWWForm();
                form.AddField("email", _email.text);

                WWW www = new WWW(forgotUrl, form);
                yield return www;
                string _return = www.text;

                if (_return == "")
                {
                    _msg.text = "Server offline";
                    _back.enabled = true;
                    _send.enabled = true;
                    _email.enabled = true;
                }
                else
                {
                    _msg.text = "Reset code has been sent to your email";

                    resetCode = _return;
                    resetEmail = _email.text;

                    yield return new WaitForSeconds(1);

                    _back.enabled = true;
                    _send.enabled = true;
                    _email.enabled = true;
                    _email.text = "";

                    _go.transform.parent.FindChild("ResetCode").gameObject.SetActive(true);
                    _go.SetActive(false);
                }
            }
        }
    }

    public void ResetCode(GameObject _go)
    {
        InputField _code = _go.transform.FindChild("Code").gameObject.GetComponent<InputField>();
        Text _msg = _go.transform.FindChild("Msg").gameObject.GetComponent<Text>();

        if (_code.text != resetCode)
        {
            _msg.text = "Reset code not valid";
        }
        else
        {
            _code.text = "";
            _go.transform.parent.FindChild("NewPassword").gameObject.SetActive(true);
            _go.SetActive(false);
        }
    }

    public void NewPassword(GameObject _go)
    {
        StartCoroutine(NewPasswordIE(_go));
    }
    IEnumerator NewPasswordIE(GameObject _go)
    {
        InputField _password = _go.transform.FindChild("Password").gameObject.GetComponent<InputField>();
        InputField _passwordComfirm = _go.transform.FindChild("Password Comfirm").gameObject.GetComponent<InputField>();

        Text _msg = _go.transform.FindChild("Msg").gameObject.GetComponent<Text>();


        if (_password.text == "")
        {
            _msg.text = "Enter new password";
        }
        else
        {
            if (_passwordComfirm.text != _password.text)
            {
                _msg.text = "Passwords does not match";
            }
            else
            {
                WWWForm form = new WWWForm();
                form.AddField("email", resetEmail);
                form.AddField("pass", Md5Sum(_password.text));
                form.AddField("key", Md5Sum(resetEmail + secretGameKey).ToLower());

                WWW www = new WWW(newPasswordURL, form);
                yield return www;
                string _return = www.text;

                if (_return == "")
                {
                    _msg.text = "Server offline";
                }
                else
                {
                    _msg.text = "Your password has been changed";
                }

                yield return new WaitForSeconds(1);
                _go.transform.parent.FindChild("Login").gameObject.SetActive(true);
                _go.SetActive(false);
            }
        }
    }


    public bool VerifyEmailAddress(string address)
    {
        string[] atCharacter;
        string[] dotCharacter;

        atCharacter = address.Split("@"[0]);
        if (atCharacter.Length == 2)
        {
            dotCharacter = atCharacter[1].Split("."[0]);
            if (dotCharacter.Length >= 2)
            {
                if (dotCharacter[dotCharacter.Length - 1].Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public string Md5Sum(string _data)
    {
        // step 1, calculate MD5 hash from input
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_data);
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
    */
}
