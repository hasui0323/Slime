using UnityEngine;
using UnityEngine.EventSystems;

public class UISelect : MonoBehaviour
{
    public GameObject firstButton;

    void Update()
    {
        //UI‚Ì‘I‘ğó‘Ô‚ª‚È‚­‚È‚Á‚½‚Æ‚«Å‰‚Ìƒ{ƒ^ƒ“‚É–ß‚é
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }
}