using UnityEngine;
using VRStandardAssets.Utils;

public class GazeInput3 : MonoBehaviour
{

    private VRInput vrInput;
   
    void Start()
    {

        var vrObjects = FindObjectsOfType<VRInteractiveItem>();　//シーン中のVRInteractiveItemをすべて見つける。

        foreach (var vrObject in vrObjects)
        {
            vrObject.OnOver += OnOver; //GazeInputのOnOver()をサブスクライブ
            vrObject.OnOut += OnOut;　 //GazeInputのOnOut()をサブスクライブ
        }

        vrInput = FindObjectsOfType<VRInput>()[0];//シーン中のVRInputを見つける。一つのはずだが、複数なら最初のを。

    }

    void OnOver()
    {
        vrInput.DoOnDown();
      
    }

    void OnOut()
    {
        vrInput.DoOnUp();
      
    }

  
}