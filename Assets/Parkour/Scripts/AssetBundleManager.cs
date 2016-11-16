using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssetBundleManager {
	
	private static AssetBundleManager _instance;

	private Dictionary<string,AssetBundleRequest> dictAssetBundles;

	public static AssetBundleManager instance
	{
		get
		{
			if (_instance == null) {
				_instance = new AssetBundleManager ();
				_instance.dictAssetBundles = new Dictionary<string,AssetBundleRequest> ();
			}
			return _instance;
		}
	}

	public AssetBundleRequest getAssetBundle(string keyName){
		AssetBundleRequest fin;
		if (dictAssetBundles.TryGetValue (keyName, out fin))
			return fin;
		else
			return null;
	}

	public IEnumerator downLoadAssetBundle(string URL,string keyName,string name){
		WWW www = new WWW (URL+keyName+".assetbundle");
		yield return www;
		yield return new WaitForSeconds (0.02f);
		AssetBundle assetbundle = www.assetBundle;
		AssetBundleRequest abr = assetbundle.LoadAssetAsync (name,typeof(GameObject));
		www.Dispose();
		dictAssetBundles.Add (keyName,abr);

	}
}
