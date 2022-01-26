/**
 * Created by: Yao Wang
 * Date Created: 1/24/2022
 * 
 *Last Edited by: NA
 *Last Edited: 1/24/2022
 *
 *Descreption: Swap multiple cubes prefabs into the secen.
 * */




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new game object
    public float scalinFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; // Total number of cubes instatied
    
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instates the list

    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cubes instance

        gObj.name = "cube" + numberOfCubes; //name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); //add new color
        gObj.GetComponent<Renderer>().material.color = randColor;

        gObj.transform.position = Random.insideUnitSphere; //random loactions inside a sphere readius of 1 out form 0,0,0,

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>(); //list for remove

        foreach (GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x;
            scale *= scalinFactor; //scale multipled by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if (scale <= 0.1f)
            {
                removeList.Add(goTemp);
            } //end if (scale <= 0.1f)
        } //end of for each (GameObject goTemp in gameObjectList)

        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove form game object list
            Destroy(goTemp); //destroy game object
        } //end foreach(GameObject goTemp in removelist)
        Debug.Log(removeList.Count);    
    }


}
