﻿using UnityEngine;
using System.Collections;
using UnityEditor;
public class ExportAssetBundles : MonoBehaviour {
	[MenuItem("Custom Editor/Create AssetBunldes For Android")]
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

	[MenuItem("Custom Editor/Create AssetBunldes For Windows")]
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
}
