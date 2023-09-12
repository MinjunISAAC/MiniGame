// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForMiniGame.ForControl
{
    public class DrawControl : MiniGameControlBase
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Line Draw Group")]
        [SerializeField] private Image     _IMG_Line      = null;
        [SerializeField] private Transform _uiTransform   = null;
        [SerializeField] private Material  _lineMaterial  = null;
        [SerializeField] private float     _lineThickness = 0.01f;
        [SerializeField] private int       _lineVertices  = 5;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------

        private LineRenderer _lineRenderer = null;
        
        private LineCollider _lineCollider = null;

        private Vector3      _inputPos     = Vector3.zero;
        private Vector3      _prevPos      = Vector3.zero;

        private GameObject   _line         = null;

        private bool         _isStart      = false;

        private int          _lineCount    = 2;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Protected
        protected override void UpdateToPlay() 
        {
            _DrawLine();
        }

        // ----- Public
        public void SetToStart(bool isStart) => _isStart = isStart;
        public void DeleteLine()
        {
            _prevPos      = Vector3.zero;
            _inputPos     = Vector3.zero;
            _lineCount    = 2;
            _lineRenderer = null;

            if (_line != null) Destroy(_line.gameObject);
        }

        // ----- Private
        private void _DrawLine()
        {
            _inputPos.z = _uiTransform.position.z - _camera.transform.position.z * 0.9f;
            _inputPos.x = Input.mousePosition.x;
            _inputPos.y = Input.mousePosition.y;

            var mousePos = _camera.ScreenToWorldPoint(_inputPos);

            if (Input.GetMouseButtonDown(0))
            {
                _CreateLine(mousePos);
            }

            if (Input.GetMouseButton(0) && _isStart)
            {
                _ConnectLine(mousePos);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _prevPos      = Vector3.zero;
                _inputPos     = Vector3.zero;
                _lineCount    = 2;
                _lineRenderer = null;
                
                Destroy(_line.gameObject);
            }
        }

        private void _CreateLine(Vector3 mousePosition)
        {
            var line         = new GameObject("Line");
            var lineRenderer = line.AddComponent<LineRenderer>();

            _line = line;

            GameObject collider       = new GameObject("Collider");
            collider.transform.parent = _line.transform;
            line.transform.parent     = _IMG_Line.transform;
            line.transform.position   = mousePosition;

            _lineCollider = collider.AddComponent<LineCollider>();
            _lineCollider.OnInit(0.05f, true);

            lineRenderer.startWidth        = _lineThickness;
            lineRenderer.endWidth          = _lineThickness;
            lineRenderer.numCornerVertices = _lineVertices;
            lineRenderer.numCapVertices    = _lineVertices;
            lineRenderer.material          = _lineMaterial;
            lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            lineRenderer.SetPosition(0, mousePosition);
            lineRenderer.SetPosition(1, mousePosition);

            _lineRenderer = lineRenderer;
        }

        private void _ConnectLine(Vector3 mousePosition)
        {
            _IMG_Line.gameObject.SetActive(true);

            if (_prevPos != null && Mathf.Abs(Vector3.Distance(_prevPos, mousePosition)) >= 0.0001f)
            {
                _prevPos = mousePosition;
                _lineCount++;
                _lineRenderer.positionCount = _lineCount;
                _lineRenderer.SetPosition(_lineCount - 1, mousePosition);

                _lineCollider.transform.position = mousePosition;
            }
        }
    }
}