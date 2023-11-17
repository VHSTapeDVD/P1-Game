using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovment : MonoBehaviour
{
    private MeshRenderer _backgroundMeshRenderer;
    private Vector2 _textureOffset = Vector2.zero;
    [SerializeField] private float _speed = 1f;

    private float _timer = 0f;
    [SerializeField] private float _switchInterval = 240f; // 4 minutes in seconds

    [SerializeField] private Material[] _backgroundMaterials; // Add your background materials here

    void Start()
    {
        _backgroundMeshRenderer = GetComponent<MeshRenderer>();

    }


    // Update is called once per frame
    void Update()
    {
        _textureOffset.x += _speed * Time.deltaTime;
        _backgroundMeshRenderer.material.mainTextureOffset = _textureOffset;

        // Update the timer
        _timer += Time.deltaTime;

        // Check if it's time to switch background material
        if (_timer >= _switchInterval)
        {
            SwitchBackgroundMaterial();
            _timer = 0f; // Reset the timer
        }
    }

    void SwitchBackgroundMaterial()
    {
        // Randomly select a new background material
        Material newMaterial = _backgroundMaterials[Random.Range(0, _backgroundMaterials.Length)];

        // Apply the new material
        _backgroundMeshRenderer.material = newMaterial;
    }

}
