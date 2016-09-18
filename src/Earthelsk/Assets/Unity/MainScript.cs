using Assets.Core.Buildings.Models.Saloons;
using Assets.Core.ValueTypes;
using Assets.Lib;
using Assets.Lib.Commands;
using Assets.Lib.Ioc;
using Assets.Movement;
using Assets.Unity.Logs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    private MovementController movement = new MovementController();
    private GameObject camera;
    private TeclynUnity teclyn;
    private CommandService commandService;


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

	    //for (var i = -10; i < 10; i++)
	    //{
     //       for (var j = -10; j < 10; j++)
     //       {
     //           var tile = this.GetFactory().CreateTile(Color.grey);
     //           tile.transform.position = new Vector3(i, 0, j);
     //           this.AddChild(tile);
     //       }
     //   }

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

        this.teclyn = TeclynUnity.Initialize();
        this.teclyn.Get<BasicIocContainer>().Register<Assets.Lib.Logs.ILogger, UnityLogger>();

        this.commandService = teclyn.Get<CommandService>();

    }

    // Update is called once per frame
    void Update () {
	    this.movement.Compute(camera);
	}

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
        {
            var command = this.commandService.Create<StartSaloonConstruction>();
            command.Location = new TileLocation(10, 10);
            command.Orientation = Orientation.East;
            commandService.Execute(command);
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Level 2"))
        {
            //Application.LoadLevel(2);
        }
    }
}
