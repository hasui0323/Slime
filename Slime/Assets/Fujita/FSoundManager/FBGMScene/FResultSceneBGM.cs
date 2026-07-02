using UnityEngine;
using UnityEngine.SceneManagement;

public class FResultSceneBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // BGM停止
        FSoundManager.soundManager.StopBgm();

        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            //カードシーンBGM再生
            FSoundManager.soundManager.PlayBgm(BGMType.CardSelect);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //決定SEを再生-----------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //SE再生(Decision)
            FSoundManager.soundManager.SEPlay(SEType.Decision);
        }
        //------------------------------------------------------
    }
}
