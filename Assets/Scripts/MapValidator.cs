using System.Linq;
/// <summary>
/// Here are all the rules for a map object to be valid
/// </summary>
public static class MapValidator
{
    public static bool HasEnoughObjects(this Map map)
    {
        // TODO: Logic
        return true;
    }

    public static bool HasEnoughLength(this Map map)
    {
        // TODO: Logic
        return true;
    }

    public static bool HasObjectsSpacedCorrectly(this Map map)
    {
        // TODO: Logic
        return true;
    }

    public static bool HasObjectsOnPlayfield(this Map map)
    {
        return map.Objects.Select(x => x.Coordinates.X > -3 && x.Coordinates.X < 3 && x.Coordinates.Y > 0)
                          .Any(x => !x);
    }
}