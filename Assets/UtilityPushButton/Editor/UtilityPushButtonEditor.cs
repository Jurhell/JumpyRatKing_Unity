using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UtilityPushButton))]
public class UtilityPushButtonEditor : Editor
{
    [MenuItem("GameObject/Utility/UtilityPushButton", false, 10)]
    static void CreateUtilityButton(MenuCommand menuCommand)
    {
        //Get path to prefab
        string prefabPath = "Assets/Prefab/UtilityPushButton.prefab";

        //Load prefab
        GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));

        //Instantiate prefab
        GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

        //Ensure it gets reparented if this was a context click
        GameObjectUtility.SetParentAndAlign(obj, (GameObject)menuCommand.context);

        //Register creation in the undo system
        Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);

        //Select this object
        Selection.activeObject = obj;
    }

    public override void OnInspectorGUI()
    {
        //Show normal inspector
        base.OnInspectorGUI();

        //Get access to script
        UtilityPushButton utilityPushButton = target as UtilityPushButton;

        //Button to invoke the event from script
        if (GUILayout.Button("Invoke"))
            utilityPushButton.Event.Invoke();
    }
}
