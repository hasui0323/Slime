using UnityEngine;

public class FRandmCardSceneBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //‘I‘ğSE‚ğÄ¶------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //SEÄ¶(Select)
            FSoundManager.soundManager.SEPlay(SEType.Select);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //SEÄ¶(Select)
            FSoundManager.soundManager.SEPlay(SEType.Select);
        }
        //------------------------------------------------------
        //Œˆ’èSE‚ğÄ¶-----------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //SEÄ¶(Decision)
            FSoundManager.soundManager.SEPlay(SEType.Decision);
        }
        //------------------------------------------------------
    }
}
