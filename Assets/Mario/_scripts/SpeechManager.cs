using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start()
	{
		keywords.Add("Show Body", () =>
			{
				// Call the ShowBody method on every descendant object.
				this.BroadcastMessage("ShowBody");
			});

		keywords.Add("Show Skelet", () =>
			{
				
				// Call the ShowBone method on just the focused object.
				this.BroadcastMessage("ShowBone");

			});

		keywords.Add("Show Organ", () =>
			{
				
				// Call the ShowOrgan method on just the focused object.
				this.BroadcastMessage("ShowOrgan");
			
			});

        keywords.Add("Return", () =>
            {

            // Call the All back method on just the focused object.
            this.BroadcastMessage("AllBack");


            });

        keywords.Add("Select", () =>
        {

            // Call the OneClick method on just the focused object.
            this.BroadcastMessage("OneClick");


        });

        keywords.Add("Stop", () =>
        {

            // Call the OneClick method on just the focused object.
            this.BroadcastMessage("OneClick");


        });

		keywords.Add("Start", () =>
			{

				// Call the OneClick method on just the focused object.
				this.BroadcastMessage("ShowBody");


			});

		keywords.Add("Remove Skin", () =>
			{

				// Call the OneClick method on just the focused object.
				this.BroadcastMessage("RemoveSkin");


			});
		

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}
}