﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stagger
{
    [Serializable]
    public class Dictionary
    {
        public Dictionary<string, string> Map { get; }

        public Dictionary()
        {
            Map = new Dictionary<string, string>();
        }

        public void FromStreamReader(StreamReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split('\t');

                if (!(fields.Length >= 2))
                {
                    throw new Exception("Invalid number of fields.");
                }

                Map[fields[0].ToLower()] = fields[1];
            }
            
        }

        public void FromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                FromStreamReader(reader);

                reader.Close();
            }
        }
    }
}