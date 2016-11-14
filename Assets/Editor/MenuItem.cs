using UnityEngine;
using UnityEditor;
using System.Collections;

public class MyHierarchyMenu
{
    [MenuItem("Window/Test/yusong")]
    static void Test()
    {
    }
    [MenuItem("Window/Test/momo")]
    static void Test1()
    {
    }
    [MenuItem("Window/Test/雨松/MOMO")]
    static void Test2()
    {
    }


    [InitializeOnLoadMethod]
    static void StartInitializeOnLoadMethod()
    {
        //EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        //EditorApplication.ProjectWindowItemCallback += OnHierarchyGUI;
    }

    static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
            && Event.current.button == 1 && Event.current.type <= EventType.mouseUp)
        {
            GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            //这里可以判断selectedGameObject的条件
            if (selectedGameObject)
            {
                Vector2 mousePosition = Event.current.mousePosition;

                EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "Window/Test", null);
                Event.current.Use();
            }
        }
    }

}