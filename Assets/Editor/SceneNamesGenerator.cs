using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using LearnProgrammingAcademy.Utils;

namespace LearnProgrammingAcademy.Editor
{

    public class SceneNamesGenerator
    {
        // == Constants == 
        private const string NamespaceName = " LearnProgrammingAcademy.Generated";
        private const string GeneratedFolderPath = "__Scripts/Generated/";
        private const string SceneNamesClassName = "SceneNames";

        private const string DotCs = ".cs";
        //This will be the file name of the class
        private const string SceneNamesFileName = SceneNamesClassName + DotCs;// "SceneNames.cs"
        private const string WarningComment = "// This class is auto generated, DO NOT MODIFY";
        private const string ConstantsComment = "// == Constants ==";

        // == Public Methods ==
        [MenuItem("LPA/GenerateSceneNames")]
        public static void GenerateSceneNames()
        {
            Debug.Log("GenerateSceneNames called");

            //dataPath is in editor Assets folder
            // Assets/__Scripts/Generated
            var folderPath = Path.Combine(Application.dataPath, GeneratedFolderPath);

           //Check if folder exists, if not, create it
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //Assets/__Scripts/Generated/SceneNames.cs
            var filePath = Path.Combine(folderPath, SceneNamesFileName);

            // Write all texts to file
            File.WriteAllText(filePath, BuildSceneNamesContent());

            //Refresh Assets
            AssetDatabase.Refresh();

        }

        // == Private Methods ==
        private static string BuildSceneNamesContent()
        {
            var sb = new StringBuilder(); // build all the strings

            sb.AppendLine(WarningComment);
            sb.AppendLine($"namespace{NamespaceName} {{");// double {{ to escape it
            sb.AppendLine(); // Append the empty line
            sb.AppendTab().AppendLine($"public static class  {SceneNamesClassName} {{");
            sb.AppendLine();
            sb.AppendTab(2).AppendLine(ConstantsComment);

            //Loop through all of the scenes
            foreach(var scene in EditorBuildSettings.scenes)
            {
                if(scene.enabled)
                {
                    var sceneName = Path.GetFileNameWithoutExtension(scene.path);
                    var variableName = GetValidVariableName(sceneName);
                    var line = $"public const string {variableName} = \"{sceneName}\";"; 
                    sb.AppendTab(2).AppendLine(line);
                }

            }


            sb.AppendTab().AppendLine("}"); // Close class
            sb.AppendLine("}");// Close namespace

            return sb.ToString();
        }


        private static string GetValidVariableName(string name)
        {
            name = name.Replace(" ", "_"); // replaces string with "_"

            var firstCharacter = name[0];

            //if starts with digit prepend    
            if(char.IsDigit(firstCharacter))
            {
                name = "_" + name;
            }

            return name;
        }

    }


}
