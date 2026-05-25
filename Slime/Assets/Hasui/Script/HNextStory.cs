using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HNextStory : MonoBehaviour
{
    public CanvasGroup StoryImage1;
    public CanvasGroup StoryImage2;
    public CanvasGroup StoryImage3;

    public Text Text;

    int cnt = 0;

    float fadeSpeed = 2f;

    //次のシーン名
    public string nextSceneName;

    void Start()
    {
        //1枚目を表示
        StoryImage1.alpha = 1;
        //2枚目以降透過
        StoryImage2.alpha = 0;
        StoryImage3.alpha = 0;

        Text.text = "Zで次へ・Xでスキップ";

        cnt = 0;
    }

    void Update()
    {
        //Zキーが押されたら
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cnt++;

            if (cnt == 1)
            {
                StartCoroutine(Fade(StoryImage1, StoryImage2));
            }

            if (cnt == 2)
            {
                StartCoroutine(Fade(StoryImage2, StoryImage3));
                Text.text = "Zでゲームスタート";
            }
        }
        if (cnt == 3)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    System.Collections.IEnumerator Fade(CanvasGroup oldImage, CanvasGroup newImage)
    {
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime * fadeSpeed;

            //フェードアウト
            oldImage.alpha = 1 - time;

            //フェードイン
            newImage.alpha = time;

            yield return null;
        }

        oldImage.alpha = 0;
        newImage.alpha = 1;
    }
}