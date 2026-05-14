using UnityEngine;
using UnityEngine.EventSystems;

public class UISelect : MonoBehaviour
{
    public GameObject firstButton;

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }
}