using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataLoader : MonoBehaviour
{
    public string[] users;
	IEnumerator Start ()
    {
        WWW data = new WWW("http://34.208.221.68/pcPHP/api.php");
        yield return data;
        string dataString = data.text;
        print (dataString);
        users = dataString.Split('>');
	}
	
}
