using UnityEngine;
using UnityEngine.SceneManagement;

public class HReturnScene : MonoBehaviour
{
    //次のシーン名
    public string ReturnSceneName;

    // Update is called once per frame
    void Update()
    {
        //Zキーが押された場合、指定のシーンへ
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(ReturnSceneName);
        }
    }
}
