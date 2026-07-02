using UnityEngine;
using UnityEngine.SceneManagement;

public class FOpSceneBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "OperationScene")
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
