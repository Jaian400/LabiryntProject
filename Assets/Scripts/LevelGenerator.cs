using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{
    [Serializable]
    public class ColorToPrefab
    {
        public Color color;
        public GameObject Prefab;
    }

    [Serializable]
    public class mapLayer
    {
        [SerializeField] private string name;
        [SerializeField] public Texture2D map;
        [SerializeField] public List<ColorToPrefab> colorToPrefabs;
    }

    [SerializeField] private List<mapLayer> mapLayers;
    [SerializeField] private float cellSize;

    public void GenerateLevel()
    {
        Debug.Log("Generating level");

        for(int c = transform.childCount - 1; c>=0; c--)
        {
            DestroyImmediate(transform.GetChild(c).gameObject);
        }

        foreach(var mapLayer in mapLayers)
        {
            var map = mapLayer.map;
            for(int x = 0; x < map.width; x++)
            {
                for(int y = 0; y < map.height; y++)
                {
                    SpawnPrefab(x, y, map, mapLayer.colorToPrefabs);
                }
            }
        }
    }

    private void SpawnPrefab(int x, int y, Texture2D map, List<ColorToPrefab>colorToPrefabs)
    {
        var colorToPrefab = colorToPrefabs.Find((colorToPrefab) => colorToPrefab.color == map.GetPixel(x, y));

        if (colorToPrefab == null)
        {
            Debug.LogError("No such prefab for given color");
        }
        else 
        {
            var go = PrefabUtility.InstantiatePrefab(colorToPrefab.Prefab) as GameObject;
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(x * cellSize, 0f, y * cellSize);
        }
    }
}
