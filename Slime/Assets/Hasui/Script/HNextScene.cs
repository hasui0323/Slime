using UnityEngine;
using UnityEngine.SceneManagement;

public class HNextScene : MonoBehaviour
{
    //次のシーン名
    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        //Zキーが押された場合、指定のシーンへ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
