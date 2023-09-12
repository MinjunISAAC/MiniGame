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
        [Header("Camera Group")]
        [SerializeField] private Camera _camera = null;

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
        
        private SphereCollider _checkCollider = null;

        private Vector3 _inputPos = Vector3.zero;
        private Vector3 _prevPos  = Vector3.zero;

        private bool _isStart = false;
        private bool _isEnd   = false;
        private bool _isDrag  = false;

        private GameObject _line = null;

        private int _lineCount = 2;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Protected
        protected override void UpdateToPlay() 
        {
            _DrawLine();
        }
        
        protected override void UpdateToSuccess() 
        { 
        
        }
        
        protected override void UpdateToFail() 
        { 
        
        }

        // ----- Private
        private void _DrawLine()
        {
            _inputPos.z = _uiTransform.position.z - _camera.transform.position.z;
            _inputPos.x = Input.mousePosition.x;
            _inputPos.y = Input.mousePosition.y;

            var mousePos = _camera.ScreenToWorldPoint(_inputPos);

            if (Input.GetMouseButtonDown(0))
            {
                _isDrag = true;
                _CreateLine(mousePos);
            }

            if (Input.GetMouseButton(0))
            {
                _ConnectLine(mousePos);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDrag       = false;
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

            _checkCollider = collider.AddComponent<SphereCollider>();
            _checkCollider.radius = 0.05f;

            lineRenderer.startWidth        = _lineThickness;
            lineRenderer.endWidth          = _lineThickness;
            lineRenderer.numCornerVertices = _lineVertices;
            lineRenderer.numCapVertices    = _lineVertices;
            lineRenderer.material          = _lineMaterial;

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

                _checkCollider.transform.position = mousePosition;
            }
        }
    }
}