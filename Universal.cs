using GorillaGameModes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace GRewind
{
    // for the future: never EVER change the names of these, as old mods may depend on them.
    public static class Universal
    {
        public static GorillaLocomotion.GTPlayer Player()
        {
            return GorillaTagPlayer.Instance;
        }
    }
    public class GorillaTagPlayer
    {
        public static GorillaLocomotion.GTPlayer Instance => GorillaLocomotion.GTPlayer.Instance;

        public static Type GorillaTagPlayerType => typeof(GorillaLocomotion.GTPlayer);

        public static LayerMask LocomotionEnabledLayers => GorillaLocomotion.GTPlayer.LocomotionEnabledLayers;

        public static bool hasInstance => GorillaLocomotion.GTPlayer.hasInstance;
    }
    public class VRRigCompatibility
    {
        public static IReadOnlyList<VRRig> activeRigs = VRRigCache.ActiveRigs;

        public static VRRig LocalRig => GorillaTagger.Instance.offlineVRRig;
    }
    public class ReflectionHelpers
    {
        // old utilla depends on field info and it could also be used for mods without assembly publicizers
        public static FieldInfo GetFieldInfoSafe(Type t, string name, BindingFlags flags, bool tryNonStatic = false)
        {
            FieldInfo f = t.GetField(name, flags);
            if (f == null)
            {
                if (flags.HasFlag(BindingFlags.Static) && flags.HasFlag(BindingFlags.NonPublic) && !tryNonStatic)
                {
                    return GetFieldInfoSafe(t, name, BindingFlags.Static | BindingFlags.Public, true);
                }
                if (flags.HasFlag(BindingFlags.Static) && flags.HasFlag(BindingFlags.Public) && !tryNonStatic)
                {
                    return GetFieldInfoSafe(t, name, BindingFlags.Static | BindingFlags.NonPublic, true);
                }
                if (flags.HasFlag(BindingFlags.Static) && flags.HasFlag(BindingFlags.Public) && tryNonStatic)
                {
                    return GetFieldInfoSafe(t, name, BindingFlags.Public, true);
                }
                if (flags.HasFlag(BindingFlags.Static) && flags.HasFlag(BindingFlags.NonPublic) && tryNonStatic)
                {
                    return GetFieldInfoSafe(t, name, BindingFlags.NonPublic, true);
                }
                Debug.Log("null reference for " + t.Name + " " + name);
            }
            return f;
        }
    }
    public class GameModeTypes
    {
        public static GameModeType Casual = GameModeType.Casual;
        public static GameModeType Infection = GameModeType.Infection;
        public static GameModeType Hunt = GameModeType.HuntDown;
        public static GameModeType Battle = GameModeType.Paintbrawl;
    }
}
