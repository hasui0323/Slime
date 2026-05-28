using UnityEngine;

public class FBreakBlock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たった時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ハンマーに当たった
        if (collision.gameObject.tag == "Hammer")
        {
            //ハンマーを消す
            Destroy(collision.gameObject);

            //ブロックを壊す
            Destroy(gameObject);
        }
    }
}
