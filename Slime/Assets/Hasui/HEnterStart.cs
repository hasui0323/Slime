using UnityEngine;
using UnityEngine.SceneManagement;

public class HEnterStart : MonoBehaviour
{
    //次のシーン名
    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        //Enterキーが押された場合
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
