using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Item
{
    public int ID;
    public string Name;
    public string Dis;

    public Item(int id, string name, string dis)
    {
        ID = id;
        Name = name;
        Dis = dis;
    }
}

public class JsonMgr : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();

    private void Start()
    {
        ItemList.Add(new Item(0, "검", "검이다."));
        ItemList.Add(new Item(1, "방패", "검이다."));
        ItemList.Add(new Item(2, "활", "검이다."));
        ItemList.Add(new Item(3, "포션", "검이다."));
    }

    public void Save()
    {
        Debug.Log("저장하기");
        //for(int i = 0; i < ItemList.Count; i++)
        //{
        //    Debug.Log(ItemList[i].ID);
        //}
        JsonData ItemJson = JsonMapper.ToJson(ItemList);

        File.WriteAllText(Application.dataPath + "/Resources/ItemData.json", ItemJson.ToString());
    }

    public void Load()
    {
        Debug.Log("불러오기");

        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/ItemData.json");

        Debug.Log(Jsonstring);

        JsonData itemData = JsonMapper.ToObject(Jsonstring);

        for(int i = 0; i< itemData.Count; i++)
        {
            Debug.Log(itemData[i]["ID"].ToString());
            Debug.Log(itemData[i]["Name"].ToString());
            Debug.Log(itemData[i]["Dis"].ToString());
        }
    }

}


