using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    [Serializable]
    public class ColorToPrefab
    {
        public Color color;
        public GameObject Prefab;
    }

    [SerializeField] private float cellSize;
    [SerializeField] private Texture2D map;

    [SerializeField] private List<ColorToPrefab> colorToPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLevel()
    {
        Debug.Log("Generating level");

        for(int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                SpawnPrefab(x, y);
            }
        }
    }

    private void SpawnPrefab(int x, int y)
    {
        map.GetPixel(x, y);
    }
}
