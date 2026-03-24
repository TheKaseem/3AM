using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(TriggerSceneChange))]
public class TriggerSceneChangeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TriggerSceneChange trigger = (TriggerSceneChange)target;

        // Obtiene todas las escenas en Build Settings
        int sceneCount = EditorBuildSettings.scenes.Length;
        string[] sceneNames = new string[sceneCount];
        int currentIndex = -1;

        for (int i = 0; i < sceneCount; i++)
        {
            string path = EditorBuildSettings.scenes[i].path;
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            sceneNames[i] = name;

            if (trigger.scene == name)
                currentIndex = i;
        }

        int newIndex = EditorGUILayout.Popup("Scene", currentIndex, sceneNames);
        if (newIndex >= 0 && newIndex < sceneNames.Length)
        {
            trigger.scene = sceneNames[newIndex];
        }

        trigger.tag = EditorGUILayout.TextField("Tag", trigger.tag);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(trigger);
        }
    }
}
