using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CheckProfileLoaded : MonoBehaviour
    {
        private void Start()
        {
            ProfileSetting.loadProfile();
            if (ProfileSetting.PROFILE.FirstName.Length > 0)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}