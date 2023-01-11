using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Servises
{
    [RequireComponent(typeof(Button))]
    public class SceneLodeButton : MonoBehaviour
    {
        public string SceneName;
        private void Start() => GetComponent<Button>().onClick.AddListener(OpenScene);
        public void OpenScene() =>SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}