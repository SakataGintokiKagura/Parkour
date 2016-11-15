using UnityEngine;
using System.Collections;

public class GameManager{
	
	private static GameManager _instance;

	private ApplicationFacade facade;

	public static GameManager instance
	{
		get
		{
			if (_instance == null) {
				_instance = new GameManager ();
			}
			return _instance;
		}
	}

	public void init(){
		//facade = new ApplicationFacade();
	}
}
