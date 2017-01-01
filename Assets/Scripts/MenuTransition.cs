using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuTransition : MonoBehaviour {

    public RectTransform[] panels;

    private int MoveIn = 0;
    private int MoveOut = 1;

    private int currentPanel = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        panels[MoveIn].anchoredPosition = Vector2.Lerp(panels[MoveIn].anchoredPosition, new Vector2(0, 0), Time.deltaTime * 2);
        panels[MoveOut].anchoredPosition = Vector2.Lerp(panels[MoveOut].anchoredPosition, new Vector2(-2000, 0), Time.deltaTime * 2);
    }

    public void callPanel(int PanelNo)
    {
        MoveIn = PanelNo;
        MoveOut = currentPanel;
        currentPanel = PanelNo;

        panels[MoveIn].anchoredPosition = new Vector3(2000, 0, 0);
    }

}
