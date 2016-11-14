using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener (delegate() {
			this.GoNextScene("LoadingScene");
		});
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	public void GoNextScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
