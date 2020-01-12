using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    private MapGenerator mMapGenerator = new MapGenerator();
    private Map mCurrentMap;
    private List<MapObject> mMapObjectsLeft;

    private float mCurrentLowestY;
    private float mCurrentHighestY;

    private Queue<GameObject> mDisplayedObjects;

    public GameObject MagnetObject;
    public float MovingSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        mCurrentMap = mMapGenerator.GenerateNewMap();
        mMapObjectsLeft = mCurrentMap.Objects;

        mCurrentLowestY = -5;
        mCurrentHighestY = 5;;

        mDisplayedObjects = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadIncomingObjects();

        mCurrentLowestY += MovingSpeed;
        mCurrentHighestY += MovingSpeed;

        ProcessDisplayedObjects();
    }

    private void ProcessDisplayedObjects()
    {
        foreach (var @object in mDisplayedObjects)
        {
            @object.transform.Translate(new Vector3(0, -MovingSpeed, 0));

            if (@object.transform.localPosition.y < -10)
            {
                mDisplayedObjects.Dequeue();
            }
        }
    }

    private void LoadIncomingObjects()
    {
        var currentObjects = mMapObjectsLeft.Where(x => x.Coordinates.Y <= mCurrentHighestY && x.Coordinates.Y >= mCurrentLowestY)
                                            .OrderBy(x => x.Coordinates.Y);

        foreach (var @object in currentObjects)
        {
            switch (@object.Type)
            {
                case ObjectType.Magnet:
                    {
                        var magnet = Instantiate(MagnetObject,
                                                 new Vector3(@object.Coordinates.X, @object.Coordinates.Y),
                                                 Quaternion.identity,
                                                 this.gameObject.transform);
                            
                        magnet.transform.localScale = new Vector3(@object.Size, @object.Size);

                        mDisplayedObjects.Enqueue(magnet);
                    } break;
            }

            mMapObjectsLeft.Remove(@object);
        }
    }
}
