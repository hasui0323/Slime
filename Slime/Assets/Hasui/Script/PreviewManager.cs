using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PreviewManager : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Button8;
    public GameObject Button9;
    public GameObject Button10;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public Sprite Sprite7;
    public Sprite Sprite8;
    public Sprite Sprite9;
    public Sprite Sprite10;
    public Sprite Sprite11;
  

    public Image previewImage1;
    public Image previewImage2;
    public Image previewImage3;
    public Image previewImage4;
    public Image previewImage5;
    public Image previewImage6;
    public Image previewImage7;
    public Image previewImage8;
    public Image previewImage9;
    public Image previewImage10;
    public Image previewImage11;

    void Start()
    {
        previewImage1.enabled = false;
        previewImage2.enabled = false;
        previewImage3.enabled = false;
        previewImage4.enabled = false;
        previewImage5.enabled = false;
        previewImage6.enabled = false;
        previewImage7.enabled = false;
        previewImage8.enabled = false;
        previewImage9.enabled = false;
        previewImage10.enabled = false;
        previewImage11.enabled = false;

        previewImage1.color = new Color(1, 1, 1, 0);
        previewImage2.color = new Color(1, 1, 1, 0);
        previewImage3.color = new Color(1, 1, 1, 0);
        previewImage4.color = new Color(1, 1, 1, 0);
        previewImage5.color = new Color(1, 1, 1, 0);
        previewImage6.color = new Color(1, 1, 1, 0);
        previewImage7.color = new Color(1, 1, 1, 0);
        previewImage8.color = new Color(1, 1, 1, 0);
        previewImage9.color = new Color(1, 1, 1, 0);
        previewImage10.color = new Color(1, 1, 1, 0);
        previewImage11.color = new Color(1, 1, 1, 0);

    }


    void Update()
    {
        GameObject current = EventSystem.current.currentSelectedGameObject;

        if (current == Button1)
        {
            previewImage1.sprite = Sprite1;
            previewImage2.sprite = Sprite2;

            previewImage1.enabled = true;
            previewImage2.enabled = true;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage2.color = new Color(1, 1, 1, 1);

        }
        else if (current == Button2)
        {
            previewImage1.sprite = Sprite1;
            previewImage3.sprite = Sprite3;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = true;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage3.color = new Color(1, 1, 1, 1);

        }
        else if (current == Button3)
        {
            previewImage1.sprite = Sprite1;
            previewImage4.sprite = Sprite4;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = true;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage4.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button4)
        {
            previewImage1.sprite = Sprite1;
            previewImage5.sprite = Sprite5;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = true;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage5.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button5)
        {
            previewImage1.sprite = Sprite1;
            previewImage6.sprite = Sprite6;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = true;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage6.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button6)
        {
            previewImage1.sprite = Sprite1;
            previewImage7.sprite = Sprite7;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = true;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage7.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button7)
        {
            previewImage1.sprite = Sprite1;
            previewImage8.sprite = Sprite8;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = true;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage8.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button8)
        {
            previewImage1.sprite = Sprite1;
            previewImage8.sprite = Sprite9;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = true;
            previewImage10.enabled = false;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage9.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button9)
        {
            previewImage1.sprite = Sprite1;
            previewImage10.sprite = Sprite10;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = true;
            previewImage11.enabled = false;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage10.color = new Color(1, 1, 1, 1);
        }
        else if (current == Button10)
        {
            previewImage1.sprite = Sprite1;
            previewImage11.sprite = Sprite11;

            previewImage1.enabled = true;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = true;

            previewImage1.color = new Color(1, 1, 1, 1);
            previewImage11.color = new Color(1, 1, 1, 1);
        }
        else
        {
            previewImage1.enabled = false;
            previewImage2.enabled = false;
            previewImage3.enabled = false;
            previewImage4.enabled = false;
            previewImage5.enabled = false;
            previewImage6.enabled = false;
            previewImage7.enabled = false;
            previewImage8.enabled = false;
            previewImage9.enabled = false;
            previewImage10.enabled = false;
            previewImage11.enabled = false;
        }
    }
}
