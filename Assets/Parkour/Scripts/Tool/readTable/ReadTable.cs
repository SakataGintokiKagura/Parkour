using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
/// <summary>
/// 读表辅助类
/// 唐耀 全部
/// </summary>
public class ReadTable {

    //TextAsset tableIndex;

    byte[] buffer;
    int position = 0;
    /// <summary>
    /// 记录有哪些表（Key），表对饮个目录结构（value）
    /// </summary>
    Dictionary<string, string[]> tableIndex = new Dictionary<string, string[]>();
    /// <summary>
    /// 记录对应表中的信息
    /// </summary>
    Dictionary<string, List<string[]>> tableContent = new Dictionary<string, List<string[]>>();
    //List<string[]> tableIndex = new List<string[]>();
    //ArrayList tableIndex = new ArrayList();

    /// <summary>
    /// 判断是否可以继续读表
    /// </summary>
    bool canRead { get { return (buffer != null && position < buffer.Length); } }

    static ReadTable table;
    /// <summary>
    /// 单例获取
    /// </summary>
    public static ReadTable getTable{
        get
        {
            if(table == null)
            {
                table = new ReadTable();
            }
            return table;
        }
    }
    /// <summary>
    /// 读入索引表
    /// </summary>
    ReadTable()
    {
		TextAsset tableIndex = AssetBundleManager.instance.getAssetBundle ("Table/tableDate").mainAsset as TextAsset;
        //TextAsset tableIndex = Resources.Load<TextAsset>("tableDate");
        buffer =tableIndex.bytes;
        while (canRead)
        {
            string line = OnReadLine();
            if (line == null) continue;
            string[] temp = line.Split('\t');
            this.tableIndex.Add(temp[0],temp[1].Split('/'));
        }
        OnRestore();
    }
    /// <summary>
    /// 根据信息找到对应信息
    /// </summary>
    /// <param name="table">需要读的表明</param>
    /// <param name="id">需要读的物品的ID</param>
    /// <param name="content">对应物品的需求内容</param>
    /// <returns>返回读到的内容</returns>
    public string OnFind(string table,string id , string content)
    {
        if (!tableIndex.ContainsKey(table))
        {
			Debug.Log("没有找到对应的表 "+ table);
            return "1111";
        }
        if (!tableContent.ContainsKey(table))
        {
            OnAddContent(table);
        }
        return OnFindContent(table, id, content);
    }
    /// <summary>
    /// 同上（所需表已在内存中时）
    /// </summary>
    /// <param name="table"></param>
    /// <param name="id"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    private string OnFindContent(string table, string id, string content) {

        //List<string[]> contentTemp = tableContent[table];
        int index = Array.IndexOf(tableIndex[table], content);
        if (index < 0)
        {
            Debug.Log(table+"表内没有对应内容"+content);
            return "1111";
        }
        foreach (string[] item in tableContent[table])
        {
            if (item[0] == id)
            {
                return item[index];
            }
        }
		Debug.Log("没有找到 对应ID");
        return "1111";
    }
    /// <summary>
    /// 将所需要的表的内容读入
    /// </summary>
    /// <param name="table">需要读如的表的名称</param>
    private void OnAddContent(string table)
    {
        if (buffer != null || position != 0)
            OnRestore();
        //TextAsset tableIndex = Resources.Load<TextAsset>(table);
		TextAsset tableIndex = AssetBundleManager.instance.getAssetBundle ("Table/"+table).mainAsset as TextAsset;
        buffer = tableIndex.bytes;
        List<string[]> content = new List<string[]>();
        while (canRead)
        {
            string line = OnReadLine();
            if (line == null) continue;
            string[] temp = line.Split('\t');
            content.Add(temp);
        }
        tableContent.Add(table, content);
        OnRestore();
    }
    /// <summary>
    /// 读行
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    string OnReadLine(byte[] buffer, int start, int count)
    {
#if UNITY_FLASH
		
#else
        return Encoding.UTF8.GetString(buffer, start, count);
#endif
    }
    /// <summary>
    /// 判断行对应的位置从读入
    /// </summary>
    /// <returns></returns>
    string OnReadLine()
    {
        int max = buffer.Length;
        while (position < max && buffer[position] < 32) ++position;
        int end = position;
        if (end < max)
        {
            while (true)
            {
                if (end < max)
                {
                    int temp = buffer[end++];
                    if (temp != '\n' && temp != '\r') continue;
                }
                else
                    ++end;
                string line = OnReadLine(buffer, position, end - position - 1);
                position = end;
                return line;
            }
        }
        position = max;
        return null;
    }
    /// <summary>
    /// 重置读表参数
    /// </summary>
    void OnRestore()
    {
        buffer = null;
        position = 0;
    }
}
