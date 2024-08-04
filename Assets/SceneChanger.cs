using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneZero()
    {
        SceneManager.LoadScene(0);
    }
    public void SceneOne()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void SceneThree()
    {
        SceneManager.LoadScene(3);
    }

}
