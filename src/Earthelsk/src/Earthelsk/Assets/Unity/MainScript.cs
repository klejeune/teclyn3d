using Assets.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    private MovementController movement = new MovementController();
    private GameObject camera;


    // Use this for initialization
    void Start () {
        Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);

        this.camera = this.GetFactory().CreateCamera(camera1 =>
        {
            camera1.transform.position = new Vector3(0, 10, 0);
            camera1.transform.LookAt(new Vector3(2, 0, 2));
        });

        this.AddChild(this.camera);

        this.AddChild(this.GetFactory().CreateLight(light1 =>
        {
            light1.transform.position = new Vector3(0, 3, 0);
            light1.color = Color.red;
            light1.intensity *= 10;
        }));

	    for (var i = -10; i < 10; i++)
	    {
            for (var j = -10; j < 10; j++)
            {
                var tile = this.GetFactory().CreateTile(Color.grey);
                tile.transform.position = new Vector3(i, 0, j);
                this.AddChild(tile);
            }
        }

        //var camera = gameObject.AddComponent<Camera>();
        ////var camera = new Camera();
        //camera.transform.position = new Vector3(0, 0, 10);
        //camera.transform.LookAt(new Vector3(2, 2, 0));

	    //Instantiate(camera, new Vector3(0, 0, 10), Quaternion.identity);
        //camera.transform.LookAt(new Vector3(2, 2, 0));
	    //camera.enabled = true;
        //gameObject.GetComponent<Camera>().transform.LookAt(new Vector3(2, 2, 0));

	    //var light = gameObject.AddComponent<Light>();
     //   light.color = Color.green;
     //   //light.transform.position = new Vector3(0, 3, 0);

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 2, 0);
        cube.GetComponent<Renderer>().material.color = Color.black;

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(2, 0, 0);
        cube.GetComponent<Renderer>().material.color = Color.blue;

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 2);
        cube.GetComponent<Renderer>().material.color = Color.red;

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, -2, 0);
        cube.GetComponent<Renderer>().material.color = Color.cyan;

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(-2, 0, 0);
        cube.GetComponent<Renderer>().material.color = Color.gray;

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, -2);
        cube.GetComponent<Renderer>().material.color = Color.green;


        //var sceneManager = this.GetComponent<SceneManager>();

        //this.GetHashCode()/
    }

    // Update is called once per frame
    void Update () {
	    this.movement.Compute(camera);
	}
}
