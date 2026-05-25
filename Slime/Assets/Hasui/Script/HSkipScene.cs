using UnityEngine;
using UnityEngine.SceneManagement;

public class HSkipScene : MonoBehaviour
{
    //次のシーン名
    public string skipSceneName;

    // Update is called once per frame
    void Update()
    {
        //Zキーが押された場合、指定のシーンへ
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(skipSceneName);
        }
    }
}
