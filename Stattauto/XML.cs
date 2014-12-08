using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Stattauto
{
    static class XML
    {
        /// <summary>
        /// Saves a xml file
        /// </summary>
        /// <typeparam name="T">type of the object</typeparam>
        /// <param name="savePath">Save path</param>
        /// <param name="toSave">object to save</param>


        public static void Save<T>(string savePath, T toSave)
        {
            string[] splitted = savePath.Split(Path.DirectorySeparatorChar);
            string directory = savePath.Replace(splitted[splitted.Length - 1], "");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream str = new FileStream(savePath, FileMode.Create);
            ser.Serialize(str, toSave);
            str.Close();
        }

        /// <summary>
        /// Loads a xml file
        /// </summary>
        /// <typeparam name="T">type of the object</typeparam>
        /// <param name="savePath">Save path</param>
        /// <returns>The settings; or default value</returns>

        public static T Load<T>(string savePath)
        {
            if (!File.Exists(savePath))
            {
                return default(T);
            }

            XmlSerializer ser = new XmlSerializer(typeof(T));
            StreamReader sr = new StreamReader(savePath);
            T saved;

            try
            {
                saved = (T)ser.Deserialize(sr);
                sr.Close();
            }
            catch (Exception exc)
            {
                sr.Close();
                throw exc;
            }
            
            return saved;

        }

    }
}
