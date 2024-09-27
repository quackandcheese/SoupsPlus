using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.VFX;

namespace SoupsPlus.Utils
{
    internal static class MaterialHelper
    {
        private static Dictionary<string, VisualEffectAsset> visualEffects = new Dictionary<string, VisualEffectAsset>();

        public static VisualEffect ApplyVisualEffect(this GameObject gameObject, string effectName)
        {
            visualEffects.TryGetValue(effectName, out var value);
            VisualEffect visualEffect = gameObject.TryAddComponent<VisualEffect>();
            visualEffect.visualEffectAsset = value;
            return visualEffect;
        }


        public static VisualEffectAsset GetVisualEffect(string name)
        {
            if (!visualEffects.TryGetValue(name, out var value))
            {
                return null;
            }

            return value;
        }

        public static void SetupEffectIndex()
        {
            if (visualEffects.Count > 0)
            {
                return;
            }

            VisualEffectAsset[] array = Resources.FindObjectsOfTypeAll<VisualEffectAsset>();
            foreach (VisualEffectAsset visualEffectAsset in array)
            {
                if (!visualEffects.ContainsKey(visualEffectAsset.name))
                {
                    visualEffects.Add(visualEffectAsset.name, visualEffectAsset);
                }
            }
        }

        // Misc Helper Utils
        internal static void SetupGenericCrates(GameObject prefab)
        {
            prefab.GetChild("GenericStorage").ApplyMaterialToChildren("Cube", "Wood - Default");
        }

        internal static void SetupGenericFlourSack(GameObject prefab, string material)
        {
            prefab.ApplyMaterialToChild("FlourSack", "Sack", material);
        }
    }
}