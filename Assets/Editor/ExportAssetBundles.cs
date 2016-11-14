using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Text;

public class RightClickMenu {
	[MenuItem("Assets/Create AssetBunldes/For Android")]
	static void CreateAssetBunldesAndroid ()
	{
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
			
		foreach (Object obj in SelectedAsset) 
		{
			string sourcePath = AssetDatabase.GetAssetPath (obj);
			string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
			BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
		}
	
		AssetDatabase.Refresh ();	

	}

	[MenuItem("Assets/Create AssetBunldes/For Windows")]
	static void CreateAssetBunldesWin ()
	{
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

		foreach (Object obj in SelectedAsset) 
		{
			string sourcePath = AssetDatabase.GetAssetPath (obj);
			string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
			BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
		}

		AssetDatabase.Refresh ();	
	}
    [MenuItem("Assets/Auto CreateTable")]
    static void CreateTable()
    {
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        StringBuilder result = new StringBuilder("ID"+"\t"+"Path"+"\t"+"Name"+"\n");
        int id = 0;
        foreach(var item in SelectedAsset)
        {
            string sourcePath = AssetDatabase.GetAssetPath(item);
            string[] temp = sourcePath.Split('.');
            if (temp[temp.Length - 1] != "assetbundle")
                continue;
            int index = indexOf(temp[0], '/', 3);
            string outPut = temp[0].Remove(0, index + 1);
            index = outPut.LastIndexOf('/');

            id++;
            result.Append(id.ToString() + "\t" + outPut +"\t"+outPut.Substring(index+1) + "\n");
        }
        CreateFile(Application.dataPath, "AssetBundleContent.txt", result.ToString());
    }
    static int indexOf(string table,char find,int count)
    {
        int temp = 0;
        int ci = 0;
        foreach(char item in table)
        {
            if(item == find)
            {
                ci++;
                if(ci == count)
                {
                    return temp;
                }
            }
            temp++;
        }
        return -1;
    }
    static void CreateFile(string path, string name, string info)
    {
        // 文件流信息
        StreamWriter sw;
        FileInfo t = new FileInfo(path + "//" + name);
        if (!t.Exists)
        {
            // 如果此文件不存在则创建
            sw = t.CreateText();
            // 以行的形式写入信息
            sw.WriteLine(info);
        }
        else
        {
            // 如果此文件存在则打开
            sw = t.AppendText();
        }


        // 关闭流
        sw.Close();
        // 销毁流
        sw.Dispose();

    }

}
