using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class MenuButton : MonoBehaviour
    {
        public event Action<MenuButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


        [SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
        [SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
                                                                            //プレイヤーを取得
        [SerializeField] private Transform m_Pl;
        [SerializeField] private GameObject Pll;
        [SerializeField] private bool scene_seni;
        [SerializeField] private bool st_anime;
        float m_Speed ;
        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

        Rigidbody m_Rigidbody;

        [SerializeField] private int button;


        [SerializeField] private bool seni_okure;
        [SerializeField] Animator anime;
        private Animator animatoraa;

        void Start()
        {
            //Fetch the Rigidbody component you attach from your GameObject
            m_Rigidbody = Pll.GetComponent<Rigidbody>();
            //Set the speed of the GameObject
            m_Speed = 1f;
            Pll.transform.Rotate(0, 0, 0);

            animatoraa = anime;
            
        }

        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
        }


        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();

            m_GazeOver = true;
        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;
        }


        private void HandleSelectionComplete()
        {
            // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
            if (m_GazeOver&&(scene_seni))
            {
                if (st_anime)
                {
                    Debug.Log("aaaaaaaaaaaa");
                    anime.SetTrigger("aa");
                }
                StartCoroutine (ActivateButton());
              
            }
        }


        private IEnumerator ActivateButton()
        {
            // If the camera is already fading, ignore.
            if (m_CameraFade.IsFading)
                yield break;

            // If anything is subscribed to the OnButtonSelected event, call it.
            if (OnButtonSelected != null)
                OnButtonSelected(this);

            // Wait for the camera to fade out.
            yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

            // Load the level.
            if (seni_okure)
            {

                Invoke("DelayMethod", 4f);
            }
            else
            {
                SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
            }
        }

        void DelayMethod()
        {
            SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
        }


        private void Update()
        {
            

            var a = m_Pl.transform.localEulerAngles.x;
            if (a>= -5)
            {
                m_Speed = 20f;
               
            }
            else
            {
                m_Speed = 1f;
            }
            m_Rigidbody.transform.position += Vector3.forward * Time.deltaTime;
            m_Rigidbody.drag = 10;

            // m_Pl.transform.position += Vector3.down * Time.deltaTime*5f;
            // Vector3 force = new Vector3(0.0f, 0.0f, 4.0f);    // 力を設定
            // m_Rigidbody.AddForce(force);

            if (m_GazeOver&&(!scene_seni))
            {
                if (button == 1)
                {
                    m_Pl.transform.Rotate(new Vector3(0, 2, 0) * Time.deltaTime * m_Speed, Space.Self);//プレイヤーを動かす
                  //  m_Rigidbody.velocity = Pll.transform.forward * m_Speed;
                  //  Vector3 force1 = new Vector3(0.0f, 20.0f, 0.0f);    // 力を設定
                    // m_Rigidbody.AddForce(force1);
                }
                else if (button == 2)
                {
                     m_Pl.transform.Rotate(new Vector3(0, -2, 0) * Time.deltaTime * m_Speed, Space.Self);//プレイヤーを動かす
                   // m_Rigidbody.velocity = Pll.transform.forward * m_Speed;
                    //   Vector3 force2 = new Vector3(0.0f, -20.0f, 0.0f);    // 力を設定
                    //
                    //  m_Rigidbody.AddForce(force2);
                }
                else if (button == 3)
                {
                    m_Speed = 5f;
                    m_Pl.transform.Rotate(new Vector3(-2, 0, 0) * Time.deltaTime * m_Speed, Space.Self);//プレイヤーを動かす
                    m_Rigidbody.drag = 100;                                                                                     //m_Rigidbody.velocity = transform.forward * m_Speed * 2f;

                   // force = new Vector3(0.0f, 0.0f, -1.0f);    // 力を設定
                   // m_Rigidbody.AddForce(force);

                }
                else if (button == 4)
                {
                    m_Speed = 30f;
                    m_Pl.transform.Rotate(new Vector3(2, 0, 0) * Time.deltaTime * m_Speed, Space.Self);//プレイヤーを動かす
                    m_Rigidbody.velocity = Pll.transform.forward * m_Speed;                                                                                   //m_Rigidbody.velocity = transform.forward * m_Speed * 500f;
                                                                                                                                                              //   force = new Vector3(0.0f, 0.0f, 10.0f);    // 力を設定
                    m_Rigidbody.drag = 1;                                                                                                                                          //   m_Rigidbody.AddForce(force);
                }
                else if(button ==0)
                {

                   
                }
            }
        }
    }
}