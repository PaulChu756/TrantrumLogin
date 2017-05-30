using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class Connection : MonoBehaviour
{
    [SerializeField] private static string UNITY_PRIVATE_KEY = "set_this_to_something_hard_to_guess";
    private string url_string = "http://master.ignition-games.com/unityTest/manager.php?pk=" + UNITY_PRIVATE_KEY + "&uid=";
    private string user_id = "";

    private void ConnectLogin()
    {
        user_id = PlayerPrefs.GetString("userID");
        user_id = user_id == null ? "0" : user_id;
        DownloadData();
    }

    private void DownloadData()
    { 
        StartCoroutine(_DownloadData());
    }

    private IEnumerator _DownloadData()
    {
        yield return null;
        WWW dataGet = new WWW(url_string + user_id);
        yield return new WaitUntil(() => dataGet.isDone);
        if (dataGet.error != null)
        {
            Debug.Log(dataGet.error + " " + dataGet.text);
        }
    }
}

class ConnectionObject
{
    private int id = 0;
    private string username = "";
    private int serverTime = 0;
    private Vector3 lastPosition = Vector3.zero;
    private string exampleDatabaseVariable = "";
}