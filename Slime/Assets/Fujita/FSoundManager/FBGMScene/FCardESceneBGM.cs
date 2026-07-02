using UnityEngine;
using UnityEngine.SceneManagement;

public class FCardESceneBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CardEffectScene")
        {
            //カードシーンBGM再生
            FSoundManager.soundManager.PlayBgm(BGMType.CardSelect);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //選択SEを再生------------------------------------------
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //SE再生(Select)
            FSoundManager.soundManager.SEPlay(SEType.Select);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //SE再生(Select)
            FSoundManager.soundManager.SEPlay(SEType.Select);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //SE再生(Select)
            FSoundManager.soundManager.SEPlay(SEType.Select);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //SE再生(Select)
            FSoundManager.soundManager.SEPlay(SEType.Select);
        }
        //------------------------------------------------------
        //キャンセルSEを再生------------------------------------
        if (Input.GetKeyDown(KeyCode.X))
        {
            //SE再生(Cancel)
            FSoundManager.soundManager.SEPlay(SEType.Cancel);
        }
        //------------------------------------------------------
    }
}
