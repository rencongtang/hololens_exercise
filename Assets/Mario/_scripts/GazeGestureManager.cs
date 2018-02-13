using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject current;
    public GameObject manager;

    GestureRecognizer recognizer;
    InteractibleManager interactibleScript = null;

    // Use this for initialization
    void Start()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (current != null)
            {
                this.BroadcastMessage("OneSelect");
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        interactibleScript = manager.GetComponent<InteractibleManager>();
        current = interactibleScript.GetTarget();
        // Figure out which hologram is focused this frame.

        GameObject oldFocusObject = current;


        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (current != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}