using UnityEngine;

public class MapLoader : MonoBehaviour
{
    private MapGenerator mMapGenerator = new MapGenerator();

    // Start is called before the first frame update
    void Start()
    {
        var currentMap = mMapGenerator.GenerateNewMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
