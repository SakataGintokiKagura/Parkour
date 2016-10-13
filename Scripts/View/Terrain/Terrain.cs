using UnityEngine;
using System.Collections;
using System;
public class Terrain : MonoBehaviour {
    private ITerrainMediator terrainMediator;
    [SerializeField]
    private Player player;
    [SerializeField]
    private UI ui;
    private ApplicationFacade facade;
    // Use this for initialization
    void Start () {
        Monster monster = GetComponent<Monster>();
        if(monster == null)
        {
            Debug.Log(1111);
        }
        facade = new ApplicationFacade(player, ui, this, monster);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnSetTerrain(ITerrainMediator terrainMediator)
    {
        this.terrainMediator = terrainMediator;
    }
}
