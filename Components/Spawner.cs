using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BowieCode;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

	/// <summary>
	/// Instantiates prefabs in a random location within a predefined shape. It can set to do this every frame and spawn multiples.
	/// </summary>
	[AddComponentMenu("BowieCode/Spawner")]
	public class Spawner : MonoBehaviour {

		public enum SpawnShape {
			Circlar,
			Square,
			Cube,
			Sphere
		}

		/// <summary>
		/// The shape of the spawn from area.
		/// </summary>
		public SpawnShape shape;

		public enum SpawnMode {
			RandomFrame,
			Start,
			Manual
		}
		/// <summary>
		/// When node are spawned.
		/// </summary>
		public SpawnMode spawnMode = SpawnMode.RandomFrame;

		/// <summary>
		/// Prefab to be cloned
		/// </summary>
		public GameObject prefab;

		/// <summary>
		/// How oftens prefabs are spawned when the SpawnMode is SpawnMode.RandomFrame
		/// </summary>
		public ShapedRange spawnEveryRange;

		float _nextSpawnTime = -1.000f;

		/// <summary>
		/// Where instances are added.
		/// </summary>
		public ParentingMode container;

		/// <summary>
		/// Size of the spawn area.
		/// </summary>
		public float size = 5.0f;

		/// <summary>
		/// The random
		/// </summary>
		public ShapedRange perSpawnRange = new ShapedRange( 1.0f );

		Transform _transform;

		[InspectorButton(MethodName="DoSpawn", ButtonText="Spawn")]
		public InspectorButton spawnButton;

		[InspectorButton(MethodName="DoSpawnOne", ButtonText="SpawnOne")]
		public InspectorButton spawnOneButton;

		void OnValidate () {
			// Apply changes to the random range
			UpdateNextSpawnTime();
		}

		void Start () {

			_transform = GetComponent<Transform>();

			if ( spawnMode == SpawnMode.RandomFrame ) {
				DoSpawn();
			}
		}

		void Update () {
			if ( spawnMode == SpawnMode.RandomFrame && ShouldSpawn() ) {
				DoSpawn();
				UpdateNextSpawnTime();
			}
		}

		void OnDrawGizmosSelected() { 
			switch ( shape ) {
				case SpawnShape.Circlar:
					DrawCircularGizmo();
					break;
				case SpawnShape.Cube:
					DrawCubeGizmo();
					break;
				case SpawnShape.Sphere:
					DrawSphereGizmo();
					break;
				case SpawnShape.Square:
				default:
					DrawSquareGizmo();
					break;
			}
		}

		public void DoSpawn () {
			var numberToSpawn = perSpawnRange.GetRandom();

			for ( int i = 0; i < numberToSpawn; i++ ) {
				DoSpawnOne();
			}
		}

		public void DoSpawnOne () {
			var clone = EditorSafe.CreateFromPrefab( prefab );
			clone.transform.position = transform.position + GetRandomSpawnOffset();
			container.DoParent( _transform, clone.transform );

		}

		bool ShouldSpawn () {
			return Time.time > _nextSpawnTime;
		}

		void UpdateNextSpawnTime () {
			_nextSpawnTime = Time.time + spawnEveryRange.GetRandom();
		}

		Vector3 GetRandomSpawnOffset () {
			switch ( shape ) {
				case SpawnShape.Circlar:
					return GetRandomCirclarOffset();
				case SpawnShape.Cube:
					return GetRandomCubeOffset();
				case SpawnShape.Sphere:
					return GetRandomSphereOffset();
				case SpawnShape.Square:
				default:
					return GetRandomSquareOffset();
			}
		}

		Vector3 GetRandomCirclarOffset () {
			var offsetRotation = Quaternion.Euler( 0.0f, Random.Range( 0.0f, 360.0f ), 0.0f );
			var offsetPosition = offsetRotation * new Vector3( Random.Range( 0.0f, size / 2.0f ), 0.0f, 0.0f );
			return offsetPosition;
		}

		void DrawCircularGizmo () {
#if UNITY_EDITOR
			Handles.color = Color.cyan;
			Handles.CircleCap( 0, transform.position, transform.rotation * Quaternion.Euler( 90.0f, 0.0f, 0.0f ), size / 2.0f );
#endif
		}
			
		Vector3 GetRandomSphereOffset () {
			var offsetRotation = Quaternion.Euler( Random.Range( 0.0f, 360.0f ), Random.Range( 0.0f, 360.0f ), 0.0f );
			var offsetPosition = offsetRotation * new Vector3( Random.Range( 0.0f, size / 2.0f ), 0.0f, 0.0f );
			return offsetPosition;
		}

		void DrawSphereGizmo () {
#if UNITY_EDITOR
			Handles.color = Color.cyan;
			Handles.CircleCap( 0, transform.position, transform.rotation * Quaternion.Euler( 90.0f, 0.0f, 0.0f ), size / 2.0f );
			Handles.CircleCap( 0, transform.position, transform.rotation * Quaternion.Euler( 0.0f, 0.0f, 0.0f ), size / 2.0f );
			Handles.CircleCap( 0, transform.position, transform.rotation * Quaternion.Euler( 0.0f, 90.0f, 0.0f ), size / 2.0f );
#endif
		}

		Vector3 GetRandomSquareOffset () {
			return new Vector3( Random.Range( -size / 2.0f, size / 2.0f ), 0.0f, Random.Range( -size / 2.0f, size / 2.0f ) );
		}

		void DrawSquareGizmo () {
#if UNITY_EDITOR
			Handles.color = Color.cyan;
			Handles.RectangleCap( 0, transform.position, transform.rotation * Quaternion.Euler( 90.0f, 0.0f, 0.0f ), size / 2.0f );
#endif
		}
			
		Vector3 GetRandomCubeOffset () {
			return new Vector3( Random.Range( -size / 2.0f, size / 2.0f ), Random.Range( -size / 2.0f, size / 2.0f ), Random.Range( -size / 2.0f, size / 2.0f ) );
		}

		void DrawCubeGizmo () {
#if UNITY_EDITOR
			Handles.color = Color.cyan;
			Handles.DrawWireCube( transform.position, new Vector3( size, size, size ) );
#endif
		}

	}

}
