//Standard Unity/C# functionality
using UnityEngine;
using System;

//These tell our project to use pieces from the Lightship ARDK
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Utilities.Input.Legacy;

//Define our main class
public class ThrowObject : MonoBehaviour
{
    //Variables we'll need to reference other objects in our game
    public GameObject _objectPrefab;  //This will store the Object Prefab we created earlier, so we can spawn a new Object whenever we want
    public Camera _mainCamera;  //This will reference the MainCamera in the scene, so the ARDK can leverage the device camera
    IARSession _ARsession;  //An ARDK ARSession is the main piece that manages the AR experience

    // Start is called before the first frame update
    void Start()
    {
        //ARSessionFactory helps create our AR Session. Here, we're telling our 'ARSessionFactory' to listen to when a new ARSession is created, then call an 'OnSessionInitialized' function when we get notified of one being created
        ARSessionFactory.SessionInitialized += OnSessionInitialized;
    }

/*
    // Update is called once per frame
    void Update()
    {
        //If there is no touch, we're not going to do anything
        if(PlatformAgnosticInput.touchCount <= 0)
        {
            return;
        }

        //If we detect a new touch, call our 'TouchBegan' function
        var touch = PlatformAgnosticInput.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            TouchBegan(touch);
        }
    }
*/

    //This function will be called when a new AR Session has been created, as we instructed our 'ARSessionFactory' earlier
    public void OnSessionInitialized(AnyARSessionInitializedArgs args)
    {
        //Now that we've initiated our session, we don't need to do this again so we can remove the callback
        ARSessionFactory.SessionInitialized -= OnSessionInitialized;

        //Here we're saving our AR Session to our '_ARsession' variable, along with any arguments our session contains
        _ARsession = args.Session;
    }

    //This function will be called when the player touches the screen. For us, we'll have this trigger the shooting of our object from where we touch.
    public void ClickButton()
    {
        System.Random rnd = new System.Random();
        var radius = .2;

        for(int i = 0; i < 5; i++){
            double angle = rnd.NextDouble() * (2 * Math.PI);

            GameObject newObject = Instantiate(_objectPrefab);  //Spawn a new object from our Ball Prefab
            newObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new object
            newObject.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;    //Set the position of our new object to just in front of our Main Camera
            newObject.transform.Translate((float)(radius * Math.Cos(angle)), (float)(radius * Math.Sin(angle)), 0);
            Rigidbody rigbod = newObject.GetComponent<Rigidbody>();
            rigbod.velocity = new Vector3(0f, 0f, 0f);
            float force = 300.0f;
            rigbod.AddForce(_mainCamera.transform.forward * force); 
        }
    }
}