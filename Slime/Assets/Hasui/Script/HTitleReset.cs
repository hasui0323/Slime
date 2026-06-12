using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        if (HItemSelectManager.Instance != null)
        {
            HItemSelectManager.Instance.selectedItem =
                ItemType.RandomCard;
        }

        SceneManager.LoadScene("CardSelect");
    }
}