using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Text;

public class RightClickMenu {
	[MenuItem("Assets/Create AssetBunldes/For Android")]
	static void CreateAssetBunldesAndroid ()
	{
		//获取在Project视图中选择的所有游戏对象
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
			
		foreach (Object obj in SelectedAsset) 
		{
			string sourcePath = AssetDatabase.GetAssetPath (obj);
			//本地测试：建议最后将Assetbundle放在StreamingAssets文件夹下，如果没有就创建一个，因为移动平台下只能读取这个路径
			//StreamingAssets是只读路径，不能写入
			//服务器下载：就不需要放在这里，服务器上客户端用www类进行下载。
			string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
			if (BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies| BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android)) {
				Debug.Log(obj.name +"资源打包成功");
			} 
			else 
			{
				Debug.Log(obj.name +"资源打包失败");
			}
		}
	
		AssetDatabase.Refresh ();	

	}

	[MenuItem("Assets/Create AssetBunldes/For Windows")]
	static void CreateAssetBunldesWin ()
	{
		//获取在Project视图中选择的所有游戏对象
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

		foreach (Object obj in SelectedAsset) 
		{
			string sourcePath = AssetDatabase.GetAssetPath (obj);
			string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
			if (BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies| BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows)) {
				Debug.Log(obj.name +"资源打包成功");
			} 
			else 
			{
				Debug.Log(obj.name +"资源打包失败");
			}
		}

		AssetDatabase.Refresh ();	
	}
    [MenuItem("Assets/Auto CreateTable")]
    static void CreateTable()
    {
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        StringBuilder result = new StringBuilder("ID"+"\t"+"Path"+"\n");
        int id = 0;
        foreach(var item in SelectedAsset)
        {
            string sourcePath = AssetDatabase.GetAssetPath(item);
            string[] temp = sourcePath.Split('.');
            if (temp[temp.Length - 1] != "assetbundle")
                continue;
            int index = indexOf(temp[0], '/', 3);
            string outPut = temp[0].Remove(0, index + 1);
            id++;
            result.Append(id.ToString() + "\t" + outPut + "\n");
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
