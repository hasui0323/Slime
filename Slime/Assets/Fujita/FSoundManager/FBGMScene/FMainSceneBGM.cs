using UnityEngine;
using UnityEngine.SceneManagement;

public class FMainSceneBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // BGM停止
        FSoundManager.soundManager.StopBgm();

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            //カードシーンBGM再生
            FSoundManager.soundManager.PlayBgm(BGMType.InGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
