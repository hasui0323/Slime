using UnityEngine;
using UnityEngine.SceneManagement;

public class HExplanation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //カード効果説明シーンに移動
        if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("CardEffectScene");
        }
    }
}
