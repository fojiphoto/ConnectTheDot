using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Connect.Core
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] TMP_Text _levelText;
        [SerializeField] private Color _inactiveColor;

        private bool isLevelUnlocked;
        private int currentLevel;

        private void Awake()
        {
            _button.onClick.AddListener(Clicked);
        }

        private void OnEnable()
        {
            MainMenuManager.Instance.LevelOpened += LevelOpened;
        }

        private void OnDisable()
        {
            MainMenuManager.Instance.LevelOpened -= LevelOpened;
        }

        private void LevelOpened()
        {

            string gameObjectName = gameObject.name;
            string[] parts = gameObjectName.Split('_');
            _levelText.text = parts[parts.Length - 1];
            currentLevel = int.Parse(_levelText.text);
            isLevelUnlocked = DotConnectGameManager.Instance.IsLevelUnlocked(currentLevel);

            _image.color = isLevelUnlocked ? MainMenuManager.Instance.CurrentColor : _inactiveColor;
        }

        [SerializeField]
        private TMP_Text _levelIsLock;
        private void Clicked()
        {
            if (!isLevelUnlocked)
            {
                DotConnectAudioController.Instance.PlaySound(DotConnectAudioController.Instance.cantclick);
               
                StartCoroutine(ActiveText());
                return;
            }
            DotConnectAudioController.Instance.PlaySound(DotConnectAudioController.Instance.click);

            DotConnectGameManager.Instance.CurrentLevel = currentLevel;
            DotConnectGameManager.Instance.GoToGameplay();


        }

        IEnumerator ActiveText()
        {
            _levelIsLock.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            _levelIsLock.gameObject.SetActive(false);

        }
    }
}
