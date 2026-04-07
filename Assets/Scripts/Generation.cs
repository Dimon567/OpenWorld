using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NamedBiomeVoronoi : MonoBehaviour
{
    [SerializeField] Transform objContener;

    public Biome[] biomes; 
    public int mapSize = 500;
    public int sitesPerBiome = 3;
    public float scale = 1.0f;

    private Vector2[] sites;
    private Biome[] siteBiome;
    private Texture2D biomeTexture;

    void Start()
    {
        transform.localScale = Vector3.one * mapSize / 10 * scale;
        transform.position = new Vector3(1, 0, 1) * mapSize / 2 * scale;
        objContener.transform.position = transform.position;
        GenerateBiomeMap();
        ApplyTexture();
    }

    void GenerateBiomeMap()
    {
        
        List<Vector2> siteList = new List<Vector2>();
        List<Biome> biomeList = new List<Biome>();

        foreach (var biome in biomes)
        {
            for (int i = 0; i < sitesPerBiome; i++)
            {
                siteList.Add(new Vector2(
                    Random.Range(0, mapSize),
                    Random.Range(0, mapSize)
                ));
                biomeList.Add(biome);
            }
        }

        sites = siteList.ToArray();
        siteBiome = biomeList.ToArray();
 
        biomeTexture = new Texture2D(mapSize, mapSize);

        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                Vector2 position = new Vector2(x, y);

                int nearest = GetNearestSiteIndex(position);
                biomeTexture.SetPixel(x, y, siteBiome[nearest].color);

                AddObj(nearest, position);
            }
        }
        DrawPoints();
        biomeTexture.Apply();
    }

    int GetNearestSiteIndex(Vector2 point)
    {
        int nearest = 0;
        float minDist = float.MaxValue;

        for (int i = 0; i < sites.Length; i++)
        {
            float dist = Vector2.Distance(point, sites[i]);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = i;
            }
        }

        return nearest;
    }

    void DrawPoints()
    {
        foreach (Vector2 site in sites)
        {

           biomeTexture.SetPixel((int)site.x, (int)site.y, Color.red);
              
        }
    }

    void ApplyTexture()
    {
        GetComponent<Renderer>().material.mainTexture = biomeTexture;
    }

    void AddObj(int site, Vector2 position)
    {
        float perlinValue = Mathf.PerlinNoise(position.x * 0.5f, position.y * 0.5f);

        if(perlinValue < 0.5)
        {
            return;
        }

        GameObject obj = siteBiome[site].GetRandomObj();
        Vector3 objPosition = new Vector3(position.x, 0, position.y) * scale;
        Instantiate(obj, objPosition, Quaternion.Euler(-90, Random.Range(0,359), 0), objContener);
        
    }
    
}

[System.Serializable]
public class Biome
{
    public string name;
    public Color color;
    [SerializeField] private GameObject[] _objects;


    public GameObject GetRandomObj()
    {
        return _objects[Random.Range(0, _objects.Length)];
    }
}

