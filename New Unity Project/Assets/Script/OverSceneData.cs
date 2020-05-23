using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class OverSceneData : MonoBehaviour
{

    public string SelectedName;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ToNextScene(string sceneName)
    {
        SelectedName = sceneName ;

        SceneManager.LoadScene("SampleScene");
    }




}
