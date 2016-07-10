using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Game
{
	[CustomEditor(typeof(Gravity))]
	class GravityEditor : UnityEditor.Editor
	{
		private Gravity m_gravity;
		Gravity gravity { get { if(m_gravity == null) m_gravity = target as Gravity; return m_gravity; } }

		public void OnSceneGUI()
		{
			gravity.radiusSOI = Handles.RadiusHandle(Quaternion.identity, gravity.transform.position, gravity.radiusSOI);
		}
	}
}
