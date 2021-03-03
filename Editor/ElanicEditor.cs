using System.IO;
using _0G.Legacy;
using UnityEngine;
using UnityEditor;

namespace _0G
{
    // ELANIC (Experimental Lossless Animation Compression)
    public class ElanicEditor : EditorWindow
    {
        // FIELDS

        private RasterAnimation m_RasterAnimation;

        // METHODS

        [MenuItem("0G/ELANIC Editor")]
        public static void ShowWindow()
        {
            _ = GetWindow(typeof(ElanicEditor), false, "ELANIC Editor");
        }

        private void OnGUI()
        {
            GUILayout.Space(4);

            m_RasterAnimation = (RasterAnimation)EditorGUILayout.ObjectField("Raster Animation", m_RasterAnimation, typeof(RasterAnimation), false);

            using (new EditorGUI.DisabledScope(m_RasterAnimation == null))
            {
                if (GUILayout.Button("Convert to ELANIC")) ConvertToElanic();
            }
        }

        private void ConvertToElanic()
        {
            string assetPath = AssetDatabase.GetAssetPath(m_RasterAnimation);
            string dirPath = Path.GetDirectoryName(assetPath);
            
            // modify texture import settings
            foreach (string texPath in Directory.EnumerateFiles(dirPath, "*.png"))
            {
                TextureImporter textureImporter = (TextureImporter)AssetImporter.GetAtPath(texPath);
                textureImporter.npotScale = TextureImporterNPOTScale.None; // do not scale to power of 2
                textureImporter.isReadable = true; // read/write enabled
                textureImporter.maxTextureSize = 8192;
                textureImporter.crunchedCompression = false;
                textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
                textureImporter.SaveAndReimport();
            }
            Debug.LogFormat("Modified all PNG files in {0}.", dirPath);

            // create the ELANIC data scriptable object asset
            ElanicData data = CreateInstance<ElanicData>();
            string folderName = Path.GetFileName(dirPath);
            string dataPath = string.Format("{0}/{1}_ElanicData.asset", dirPath, folderName);
            if (Directory.Exists(dataPath)) AssetDatabase.DeleteAsset(dataPath);
            AssetDatabase.CreateAsset(data, dataPath);
            EditorUtility.SetDirty(data);
            m_RasterAnimation.ConvertToElanic(data);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.LogFormat("Created ELANIC Data at {0}.", dataPath);
        }
    }
}