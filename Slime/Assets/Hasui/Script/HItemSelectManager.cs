using System.Collections.Generic;
using UnityEngine;

public class HItemSelectManager : MonoBehaviour
{
    public static HItemSelectManager Instance;

    public List<ItemType> randomItems = new List<ItemType>();
    public ItemType selectedItem = ItemType.RandomCard;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // シーン切り替え後も消さない
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateRandomItems()
    {
        randomItems.Clear();

        List<ItemType> itemPool = new List<ItemType>()
        {
            ItemType.Bullet,
            ItemType.Hammer,
            ItemType.Heart,
            ItemType.Heaven,
            ItemType.Invincibl,
            ItemType.Jump,
            ItemType.NoSkill,
            ItemType.Shoes,
            ItemType.TimeReset
        };

        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, itemPool.Count);

            randomItems.Add(itemPool[rand]);
            itemPool.RemoveAt(rand); //重複防止
        }
    }
    public void SelectItem(int index)
    {
        selectedItem = randomItems[index];

        Debug.Log("選択：" + selectedItem);

        Debug.Log("SelectItem実行");
        Debug.Log("index = " + index);
        Debug.Log("selectedItem = " + selectedItem);
    }
}