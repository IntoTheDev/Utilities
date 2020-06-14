using Cinemachine;
using UnityEngine;

public class CinemachinePixelPosition : CinemachineExtension
{
	[SerializeField] private float _pixelsPerUnit = 16f;

	protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
	{
		Vector3 position = state.RawPosition;

		position.x = Mathf.Floor(position.x * pixelsPerUnit) / pixelsPerUnit;
		position.y = Mathf.Floor(position.y * pixelsPerUnit) / pixelsPerUnit;

		state.RawPosition = position;
	}
}
