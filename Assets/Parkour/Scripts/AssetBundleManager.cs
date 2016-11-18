
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleManager {
	
	private static AssetBundleManager _instance;

	private Dictionary<string,AssetBundleRequest> dictAssetBundlesRequest;

	private Dictionary<string,AssetBundle> dictAssetBundles;

	public static AssetBundleManager instance
	{
		get
		{
			if (_instance == null) {
				_instance = new AssetBundleManager ();
				_instance.dictAssetBundlesRequest = new Dictionary<string,AssetBundleRequest> ();
				_instance.dictAssetBundles = new Dictionary<string, AssetBundle> ();
			}
			return _instance;
		}
	}

	public AssetBundleRequest getAssetBundleRequest(string keyName){
		AssetBundleRequest fin;
		if (dictAssetBundlesRequest.TryGetValue (keyName, out fin))
			return fin;
		else
			return null;
	}

	public AssetBundle getAssetBundle(string keyName){
		AssetBundle fin;
		if (dictAssetBundles.TryGetValue (keyName, out fin))
			return fin;
		else
			return null;
	}

	public void loadAssetBundle(string URL,string keyName){
		if(!dictAssetBundles.ContainsKey(keyName)){
			AssetBundle assetBundle = AssetBundle.LoadFromFile (URL+keyName+".assetbundle");
			dictAssetBundles.Add (keyName, assetBundle);
		}
	}

	 public IEnumerator loadAssetBundleRequest(string URL, string keyName, string name)
	{
		WWW www = new WWW(URL + keyName + ".assetbundle");
		yield return www;
		AssetBundle assetbundle = www.assetBundle;
		AssetBundleRequest abr = assetbundle.LoadAssetAsync(name);
		yield return abr;
		dictAssetBundlesRequest.Add(keyName,abr);
		www.Dispose();
	}


	public void addAssetBundlesRequest(string keyName,AssetBundleRequest a){
		if(!dictAssetBundlesRequest.ContainsKey(keyName))
			dictAssetBundlesRequest.Add (keyName,a);
	}
}
