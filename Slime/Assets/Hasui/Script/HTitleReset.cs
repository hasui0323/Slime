using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        //ゲームをスタートした時の処理
        if (HItemSelectManager.Instance != null)
        {
            //選択中のアイテムリセット
            HItemSelectManager.Instance.selectedItem =
                ItemType.RandomCard;
        }
        //カード選択画面に移動
        SceneManager.LoadScene("CardSelect");
    }
}