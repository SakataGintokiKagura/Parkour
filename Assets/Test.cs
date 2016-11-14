using UnityEngine;
using System.Collections;
using CammerState;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button nearBtn;
    public Button mtnBtn;
    public Button mtfBtn;
    public Button FarBtn;
    public Button haveBoss;
    public Button noBoss;
    // Use this for initialization
    void Start ()
    { 
        nearBtn.onClick.AddListener(OnNear);
        mtnBtn.onClick.AddListener(OnMTN);
        mtfBtn.onClick.AddListener(OnMTF);
        FarBtn.onClick.AddListener(OnFar);
        haveBoss.onClick.AddListener(OnHaveBoss);
        noBoss.onClick.AddListener(OnNoBoss);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnNear()
    {
        
        GameStates.getInstance.OnSwitfRunWay(true);
        Debug.Log(GameStates.getInstance.singleGameState);
    }

    public void OnMTN()
    {
        GameStates.getInstance.OnSwitfRunWay(true);
        Debug.Log(GameStates.getInstance.singleGameState);
    }

    public void OnMTF()
    {
        GameStates.getInstance.OnSwitfRunWay(false);
        Debug.Log(GameStates.getInstance.singleGameState);
    }

    public void OnFar()
    {
        GameStates.getInstance.OnSwitfRunWay(true);
        Debug.Log(GameStates.getInstance.singleGameState);
    }

    public void OnHaveBoss()
    {
        GameStates.getInstance.OnCreateBoss();
    }  public void OnNoBoss()
    {
        GameStates.getInstance.OnCancleBoss();
    }
}
