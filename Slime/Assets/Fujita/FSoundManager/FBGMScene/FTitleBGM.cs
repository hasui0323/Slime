using UnityEngine;

public class FTitleBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // BGM’â~
        FSoundManager.soundManager.StopBgm();
    }

    // Update is called once per frame
    void Update()
    {
        //Œˆ’èSE‚ğÄ¶-----------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //SEÄ¶(Decision)
            FSoundManager.soundManager.SEPlay(SEType.Decision);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //SEÄ¶(Decision)
            FSoundManager.soundManager.SEPlay(SEType.Decision);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SEÄ¶(Decision)
            FSoundManager.soundManager.SEPlay(SEType.Decision);
        }
        //------------------------------------------------------
    }
}
