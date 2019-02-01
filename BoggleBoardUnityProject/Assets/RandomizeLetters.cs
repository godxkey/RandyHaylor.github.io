using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class RandomizeLetters : MonoBehaviour {

	public Button randomizeButton;
	List<string> boggleCubeContents;
	public Button[] boggleCubes;
	System.Random rndObj;
	Quaternion[] rotations;


	// Use this for initialization
	void Start () {
		rndObj = new System.Random ();
		boggleCubeContents = new List<string>{"AACIOT","AHMORS","EGKLUY","ABILTY","ACDEMP","EGINTV","GILRUW","ELPSTU","DENOSW","ACELRS","ABJMOQ","EEFHIY","EHINPS","DKNOTU","ADENVZ","BIFORX"};

		randomizeButton.onClick.AddListener(RandomizeButtonClicked);
	}

	public void RandomizeButtonClicked()
	{
		//randomize list of boggle cube characters:
		Shuffle(boggleCubeContents, rndObj); 
		//randomize letter:
		for (int i = 0; i < 16; i++) {
			boggleCubes[i].GetComponentInChildren<Text>().text = boggleCubeContents [i][UnityEngine.Random.Range(0,6)].ToString();
		}
		//randomize rotation

		for (int i = 0; i < 16; i++) {
			boggleCubes [i].GetComponentInParent<Transform> ().rotation *= Quaternion.Euler (0, 0, 90*UnityEngine.Random.Range (0, 4));
		}
	}

	public static void Shuffle<T>(IList<T> list, System.Random rnd)
	{
		for(var i=0; i < list.Count; i++)
			Swap(list, i, rnd.Next(i, list.Count));
	}

	public static void Swap<T>(IList<T> list, int i, int j)
	{
		var temp = list[i];
		list[i] = list[j];
		list[j] = temp;
	}
   
}
