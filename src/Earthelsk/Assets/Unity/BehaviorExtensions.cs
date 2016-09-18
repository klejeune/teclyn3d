using UnityEngine;

public static class BehaviorExtensions
{
    private static GameObjectFactory factory = new GameObjectFactory();

    public static GameObject AddChild(this MonoBehaviour behavior, GameObject gameObject)
    {
        gameObject.transform.parent = behavior.transform;

        return gameObject;
    }

    public static GameObjectFactory GetFactory(this MonoBehaviour behavior)
    {
        return factory;
    }
}
