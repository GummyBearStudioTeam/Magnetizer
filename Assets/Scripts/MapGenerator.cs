public class MapGenerator
{
    /// <summary>
    /// TODO: Maybe provide configurable seed?
    /// </summary>
    public Map GenerateNewMap()
    {
        // TODO: Make random generation

        var map = new Map();

        if (map.HasEnoughObjects() &&
            map.HasEnoughLength() &&
            map.HasObjectsSpacedCorrectly())
        {
            return map;
        }

        return null;
    }
}
