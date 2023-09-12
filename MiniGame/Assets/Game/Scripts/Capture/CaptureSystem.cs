// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.ForMiniGame.ForCapture.ForUI;
using System.IO;
using UnityEditor;

namespace InGame.ForMiniGame.ForCapture
{
    public class CaptureSystem : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private Camera      _gameCamera    = null;
        [SerializeField] private Camera      _captureCamera = null;
        [SerializeField] private Canvas      _canvas        = null;
        [SerializeField] private CaptureView _captureView   = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Private
        private string    _capturePath      = null;
        private int       _widthResolution  = 512;
        private int       _heightResolution = 512;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Start()
        {
            _capturePath = Application.dataPath + "/CaptureImage/";
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public Sprite Capture()
        {
            _captureView.gameObject.SetActive(true);
            _captureView.PlayBlackOut();

            if (_capturePath == null)
                return null;

            if (!Directory.Exists(_capturePath)) Directory.CreateDirectory(_capturePath);

            var captureFiles  = Directory.GetFiles(_capturePath);
            var fileCount     = captureFiles.Length / 2;
            var renderTexture = new RenderTexture(_widthResolution, _heightResolution, 24);
            var writeTexture  = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, true);

            _canvas.worldCamera = _captureCamera;
            _captureCamera.targetTexture = renderTexture;
            _captureCamera.Render();

            RenderTexture.active = renderTexture;
            writeTexture.ReadPixels(new Rect(0, 0, _widthResolution, _heightResolution), 0, 0);
            writeTexture.Apply();

            _canvas.worldCamera = _gameCamera;
            _captureCamera.targetTexture = null;
            _captureCamera.Render();

            var resultResolution = _widthResolution / 2;
            var pos              = resultResolution / 2;
            Sprite captureSprite = Sprite.Create(writeTexture, new Rect(pos, pos, resultResolution, resultResolution), Vector2.one);
            byte[] bytes         = captureSprite.texture.EncodeToPNG();
            string fileName      = $"CaptureSystem_{fileCount}.png";

            File.WriteAllBytes(Path.Combine(_capturePath, fileName), bytes);
            AssetDatabase.Refresh();

            _captureView.VisiableToContents(true);
            return captureSprite;
        }
    }
}