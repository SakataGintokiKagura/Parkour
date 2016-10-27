using UnityEngine;
using System.Collections;
using System;
public class Terrain : MonoBehaviour
{
    private ITerrainMediator terrainMediator;
    [SerializeField]
    private Player player;
    [SerializeField]
    private UI ui;
    private ApplicationFacade facade;
    private float n;

    void Awake()
    {
        Monster monster = GetComponent<Monster>();
        if (monster == null)
        {
            Debug.Log(1111);
        }
        facade = new ApplicationFacade(player, ui, this, monster);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= TerrainParameter.mapDistance + (n * TerrainParameter.mapSize))
        {
            terrainMediator.OnCreateTerrain();
            n++;
        }
    }

    public void OnSetTerrain(ITerrainMediator terrainMediator)
    {
        this.terrainMediator = terrainMediator;
    }

    public float getN()
    {
        return n;
    }
		
}
