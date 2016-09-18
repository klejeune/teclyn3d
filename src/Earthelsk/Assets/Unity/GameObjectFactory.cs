using System;
using UnityEngine;

public class GameObjectFactory
{
    public GameObject CreateCamera(Action<Camera> cameraConfig = null)
    {
        var gameObject = new GameObject();
        var camera = gameObject.AddComponent<Camera>();

        if (cameraConfig != null)
        {
            cameraConfig(camera);
        }

        return gameObject;
    }

    public GameObject CreateLight(Action<Light> config = null)
    {
        var gameObject = new GameObject();
        var light = gameObject.AddComponent<Light>();

        if (config != null)
        {
            config(light);
        }

        return gameObject;
    }

    public GameObject CreateTile(Color color)
    {
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        gameObject.GetComponent<Renderer>().material.color = color;

        //var texture = 

        return gameObject;
    }
}
