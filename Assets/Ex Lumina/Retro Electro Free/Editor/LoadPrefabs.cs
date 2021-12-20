using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LoadPrefabs
{
    private static string[] paths;

    [MenuItem("ExLumina/Replace Selected Object", true)]

    private static bool ValidateReplaceSelectedObject()
    {
        return ValidateReplace();
    }

    [MenuItem("ExLumina/Replace Selected Object")]

    private static void ReplaceSelectedObject()
    {
        var transforms = Selection.GetTransforms(
               SelectionMode.Editable
             | SelectionMode.ExcludePrefab);

        var transform = transforms[0];

        Preload();

        List<Transform> children = new List<Transform>();

        int prefabs = 0;
        int noPrefabs = 0;
        int replacements = 0;
        int ambiguities = 0;

        Transform parent = transform.parent;

        Replace(transform,
                children,
                ref prefabs,
                ref noPrefabs,
                ref replacements,
                ref ambiguities);
        

        children[0].SetParent(parent);

        Debug.LogFormat(   "Replaced: {0}  "
                         + "Prefabs: {1}  "
                         + "No replacement: {2}  "
                         + "Ambiguous: {3}.",
                         replacements,
                         prefabs,
                         noPrefabs,
                         ambiguities);
    }

    [MenuItem("ExLumina/Replace Child Objects", true)]

    private static bool ValidateReplaceChildObjects()
    {
        return ValidateReplace();
    }

    private static bool ValidateReplace()
    {
        var transforms = Selection.GetTransforms(
               SelectionMode.Editable
             | SelectionMode.ExcludePrefab);

        if (transforms.Length != 1)
        {
            return false;
        }

        return
               PrefabUtility.GetPrefabAssetType(transforms[0].gameObject)
            == PrefabAssetType.NotAPrefab;
    }

    [MenuItem("ExLumina/Replace Child Objects")]

    private static void ReplaceChildObjects()
    {
        var transforms = Selection.GetTransforms(
               SelectionMode.Editable
             | SelectionMode.ExcludePrefab);

        var transform = transforms[0];

        Preload();

        List<Transform> children = new List<Transform>();

        int limit = transform.childCount;

        int prefabs = 0;
        int noPrefabs = 0;
        int replacements = 0;
        int ambiguities = 0;

        while(transform.childCount > 0 && limit-- > 0)
        {
            Transform child = transform.GetChild(0);

            Replace(child,
                children,
                ref prefabs,
                ref noPrefabs,
                ref replacements,
                ref ambiguities);
        }

        foreach(Transform newChild in children)
        {
            newChild.SetParent(transform);
        }

        Debug.LogFormat(   "Replaced: {0}  "
                         + "Prefabs: {1}  "
                         + "No replacement: {2}  "
                         + "Ambiguous: {3}.",
                         replacements,
                         prefabs,
                         noPrefabs,
                         ambiguities);
    }

    private static void Preload()
    {
        var assetGUIDs = AssetDatabase.FindAssets(
            "t:GameObject",
            new[]
            {
                "Assets/Ex Lumina/RetroElectroFree/Prefabs"
            });

        paths = new string[assetGUIDs.Length];

        for (int p = 0; p < paths.Length; ++p)
        {
            paths[p] = AssetDatabase.GUIDToAssetPath(assetGUIDs[p]);
        }
    }

    private static void Replace(
                Transform child,
                List<Transform> children,
                ref int prefabs,
                ref int noPrefabs,
                ref int replacements,
                ref int ambiguities)
    {
        if (PrefabUtility.GetPrefabAssetType(child)
      != PrefabAssetType.NotAPrefab)
        {
            //Debug.Log(child.name + " is a prefab");
            SaveForLater(child, children);
            ++prefabs;
            return;
        }

        var name = TrimName(child.name);

        var filteredPaths =
            paths.Where(n => Path.GetFileName(n) == name + ".prefab");

        switch (filteredPaths.Count())
        {
            case 0:
                //Debug.Log("No prefab for " + name);
                SaveForLater(child, children);
                ++noPrefabs;
                break;

            case 1:
                //Debug.Log("Replacing " + name + " with " + filteredPaths.First());
                ReplaceAndDestroy(child, filteredPaths.First(), children);
                ++replacements;
                break;

            default:
                //Debug.LogWarning("Found " + filteredPaths.Count() + " prefabs for " + name);
                SaveForLater(child, children);
                ++ambiguities;
                break;
        }
    }

    private static void ReplaceAndDestroy(
        Transform model,
        string path,
        List<Transform> children)
    {
        GameObject prefab =
            AssetDatabase.LoadAssetAtPath<GameObject>(path);

        Transform newModel =
            ((GameObject)PrefabUtility.InstantiatePrefab(prefab)).transform;

        newModel.localPosition = model.localPosition;
        newModel.localRotation = model.localRotation;
        newModel.localScale = model.localScale;
        newModel.name = model.name;

        GameObject.DestroyImmediate(model.gameObject);

        children.Add(newModel);
    }

    private static void SaveForLater(Transform child, List<Transform> children)
    {
        children.Add(child);
        child.SetParent(null);
    }

    private static string TrimName(string name)
    {
        string[] delimiters =
        {
            " ",
            "#"
        };

        foreach (string delimiter in delimiters)
        {
            if (name.Contains(delimiter))
            {
                name = name.Substring(0, name.IndexOf(delimiter));
            }
        }

        return name;
    }
}
