using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkTest : MonoBehaviour {
    public string serverUsername = "servername";
    public string serverPassword = "password";
    public string serverHost = "localHost";
    public string serverName = "serverName";
    public string key = "key";
    public string url = "http://studenthome.hku.nl/~marlon.sijnesael/databse/phpretrieval.php";

    private WWWForm Connect2Database() {
        WWWForm connectForm = new WWWForm();
        connectForm.AddField("server_username", serverUsername);
        connectForm.AddField("server_userpassword", serverPassword);
        connectForm.AddField("server_host", serverHost);
        connectForm.AddField("server_name", serverName);
        connectForm.AddField("server_key", key);
        return connectForm;
    }

    void Start() {
        StartCoroutine(Connect());
    }

    IEnumerator Connect() {
        var download = UnityWebRequest.Post(url, Connect2Database());

        // Wait until the download is done
        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError) {
            print("Error downloading: " + download.error);
        } else {
            // show the highscores
            Debug.Log(download.downloadHandler.text);
        }
    }
   

}