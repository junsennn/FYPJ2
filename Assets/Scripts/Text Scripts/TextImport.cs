using UnityEngine;
using System.Collections;

public class TextImport : MonoBehaviour {

	public TextAsset textFile;
	public string[] textLines;

	// Use this for initialization
	void Start () {
		if (textFile != null) {
			//Get the textLines arrays, where the texts are entered in a new line
			textLines = (textFile.text.Split ('\n'));
		}

	}

}
