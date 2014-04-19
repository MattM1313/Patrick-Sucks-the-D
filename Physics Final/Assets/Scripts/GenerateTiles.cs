﻿using UnityEngine;
using System.Collections.Generic;

public class GenerateTiles : MonoBehaviour {

    public List<Object> list;
    public GameObject[] tiles;

    public int height;
    public int width;
    public int startingHeight;
    public int startingWidth;

	void Start () {
        height += startingHeight;
        width += startingWidth;

        int k = 0;
        for (int i = startingHeight; i < height; ++i) {
            for (int j = startingWidth; j < width; ++j) {
                ++k;
                list.Add(Instantiate(tiles[Random.Range(0, tiles.Length)], new Vector3(j, i), Quaternion.identity));
            }
        }

        foreach (GameObject tile in list) {
            tile.transform.parent = this.transform;
        }
	}
	
	void Update () {
	
	}
}
