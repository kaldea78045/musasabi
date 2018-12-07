using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_seni : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "goalg")
        {
            SceneManager.LoadScene("GoodEnding");
        }
        else if(col.gameObject.tag == "goalb")
        {
            SceneManager.LoadScene("BadEnding");
        }
        else if(col.gameObject.tag =="goalc")
        {
            SceneManager.LoadScene("ClashEnding");
        }
        else
        { }
    }
}