public class MapGenerator
{
    /// <summary>
    /// TODO: Maybe provide configurable seed?
    /// </summary>
    public Map GenerateNewMap()
    {
        // TODO: Make random generation

        var map = new Map();

        map.Objects = new System.Collections.Generic.List<MapObject>
        {
            new MapObject
            {
                Coordinates = new System.Drawing.Point
                {
                    X = -2,
                    Y = 5
                },
                Size = 5,
                Type = ObjectType.Magnet
            },
            new MapObject
            {
                Coordinates = new System.Drawing.Point
                {
                    X = 2,
                    Y = 15
                },
                Size = 5,
                Type = ObjectType.Magnet
            },
            new MapObject
            {
                Coordinates = new System.Drawing.Point
                {
                    X = 0,
                    Y = 25
                },
                Size = 3,
                Type = ObjectType.Magnet
            },
            new MapObject
            {
                Coordinates = new System.Drawing.Point
                {
                    X = 2,
                    Y = 35
                },
                Size = 8,
                Type = ObjectType.Magnet
            }
        };

        return map;

        if (map.HasEnoughObjects() &&
            map.HasEnoughLength() &&
            map.HasObjectsSpacedCorrectly() &&
            map.HasObjectsOnPlayfield())
        {
            return map;
        }

        return null;
    }
}
