using IngredientLib.Util;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.VFX;

namespace SoupsPlus.Utils
{
    internal static class MaterialHelper
    {

        public static void ApplyMaterial<T>(this GameObject gameObject, Material[] materials) where T : Renderer
        {
            var comp = gameObject.GetComponent<T>();
            if (comp == null)
                return;

            comp.materials = materials;
        }
        public static void ApplyMaterial(this GameObject gameObject, Material[] materials)
        {
            ApplyMaterial<MeshRenderer>(gameObject, materials);
        }
        public static void ApplyMaterial(this GameObject gameObject, params string[] materials)
        {
            ApplyMaterial<MeshRenderer>(gameObject, GetMaterialArray(materials));
        }

        public static void ApplyMaterialToChildren<T>(this GameObject gameObject, string nameMatch, Material[] materials) where T : Renderer
        {
            for (int i = 0; i < gameObject.GetChildCount(); i++)
            {
                GameObject child = gameObject.GetChild(i);
                if (!child.name.ToLower().Contains(nameMatch.ToLower()))
                    continue;
                child.ApplyMaterial<T>(materials);
            }
        }
        public static void ApplyMaterialToChildren(this GameObject gameObject, string nameMatch, Material[] materials)
        {
            ApplyMaterialToChildren<MeshRenderer>(gameObject, nameMatch, materials);
        }
        public static void ApplyMaterialToChildren(this GameObject gameObject, string nameMatch, params string[] materials)
        {
            ApplyMaterialToChildren<MeshRenderer>(gameObject, nameMatch, GetMaterialArray(materials));
        }

        public static void ApplyMaterialToChild<T>(this GameObject gameObject, string childName, Material[] materials) where T : Renderer
        {
            gameObject.GetChild(childName).ApplyMaterial<T>(materials);
        }
        public static void ApplyMaterialToChild(this GameObject gameObject, string childName, Material[] materials)
        {
            gameObject.GetChild(childName).ApplyMaterial(materials);
        }
        public static void ApplyMaterialToChild(this GameObject gameObject, string childName, params string[] materials)
        {
            gameObject.GetChild(childName).ApplyMaterial(GetMaterialArray(materials));
        }

        public static Material[] GetMaterialArray(params string[] materials)
        {
            List<Material> materialList = new List<Material>();
            foreach (string matName in materials)
            {
                string formatted = $"IngredientLib - \"{matName}\"";
                bool flag = CustomMaterials.CustomMaterialsIndex.ContainsKey(formatted);
                if (flag)
                {
                    materialList.Add(CustomMaterials.CustomMaterialsIndex[formatted]);
                }
                else
                {
                    materialList.Add(MaterialUtils.GetExistingMaterial(matName));
                }
            }
            return materialList.ToArray();
        }
    }
}