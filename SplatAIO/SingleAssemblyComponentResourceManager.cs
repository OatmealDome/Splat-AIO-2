using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Resources;

// from http://stackoverflow.com/a/28855377
// thanks to Tao and Marwie
// all x.Designer.cs classes will need any instances of ComponentResourceManager replaced with this
internal class SingleAssemblyComponentResourceManager : ComponentResourceManager
{
    private readonly Type _contextTypeInfo;
    private CultureInfo _neutralResourcesCulture;

    public SingleAssemblyComponentResourceManager(Type t) : base(t)
    {
        _contextTypeInfo = t;
    }

    protected override ResourceSet InternalGetResourceSet(CultureInfo culture,
        bool createIfNotExists, bool tryParents)
    {
        var rs = (ResourceSet) ResourceSets[culture];
        if (rs == null)
        {
            Stream store = null;
            string resourceFileName = null;

            //lazy-load default language (without caring about duplicate assignment in race conditions, no harm done);
            if (_neutralResourcesCulture == null)
                _neutralResourcesCulture =
                    GetNeutralResourcesLanguage(MainAssembly);

            // if we're asking for the default language, then ask for the
            // invariant (non-specific) resources.
            if (_neutralResourcesCulture.Equals(culture))
                culture = CultureInfo.InvariantCulture;
            resourceFileName = GetResourceFileName(culture);

            store = MainAssembly.GetManifestResourceStream(
                _contextTypeInfo, resourceFileName);

            // Try looking for the neutral culture if the specific culture was not found
            if (store == null && !culture.IsNeutralCulture)
            {
                resourceFileName = GetResourceFileName(culture.Parent);

                store = MainAssembly.GetManifestResourceStream(
                    _contextTypeInfo, resourceFileName);
            }

            // If we found the appropriate resources in the local assembly
            if (store != null)
            {
                rs = new ResourceSet(store);
                // save for later.
                AddResourceSet(ResourceSets, culture, ref rs);
            }
            else
            {
                rs = base.InternalGetResourceSet(culture, createIfNotExists, tryParents);
            }
        }
        return rs;
    }

    // private method in framework, had to be re-specified here.
    private static void AddResourceSet(Hashtable localResourceSets, CultureInfo culture, ref ResourceSet rs)
    {
        lock (localResourceSets)
        {
            var objA = (ResourceSet) localResourceSets[culture];
            if (objA != null)
            {
                if (!Equals(objA, rs))
                {
                    rs.Dispose();
                    rs = objA;
                }
            }
            else
            {
                localResourceSets.Add(culture, rs);
            }
        }
    }
}