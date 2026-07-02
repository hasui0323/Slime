using UnityEngine;

public class FStorySceneBGM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            //SEÄ¶(Decision)
            FSoundManager.soundManager.SEPlay(SEType.Decision);
        }
        //------------------------------------------------------
    }
}
