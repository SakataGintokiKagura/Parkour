using UnityEngine;
using System.Collections;
using UnityEditor;
public class ExportAssetBundles : MonoBehaviour {
	
	[MenuItem("Custom Editor/Create AssetBunldes For Android")]
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

	[MenuItem("Custom Editor/Create AssetBunldes For Windows")]
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
}
